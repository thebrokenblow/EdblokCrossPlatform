using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdblockClient;
using Grpc.Core;
using Grpc.Net.Client;

namespace EdblokCrossPlatform.Model;

public class Service
{
    private readonly AsyncDuplexStreamingCall<RequestSymbol,ResponseSymbol> _call;
    public Service()
    {
        var grpcChannel = GrpcChannel.ForAddress("http://localhost:5071");
        
        var client = new EdblockEditor.EdblockEditorClient(grpcChannel);
        var headers = new Metadata
        {
            { "client-id", Guid.NewGuid().ToString() }
        };
        _call = client.DataStream(headers);
    }

    public async Task WriteSymbolsChangesAsync(Symbol symbol)
    {
        var requestSymbol = new RequestSymbol
        {
            X = symbol.X,
            Y = symbol.Y,
        };
            
        await _call.RequestStream.WriteAsync(requestSymbol);
    }

    public IAsyncEnumerable<ResponseSymbol> ReadSymbolsChangesAsync()
    {
        return _call.ResponseStream.ReadAllAsync();
    }

    public async Task CompleteStream()
    {
        await _call.RequestStream.CompleteAsync();
    }
}