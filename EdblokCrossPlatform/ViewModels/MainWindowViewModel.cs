using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using EdblokCrossPlatform.Model;
using EdblokCrossPlatform.ViewModels.Figures;
using EdblokCrossPlatform.ViewModels.Figures.Interfaces;

namespace EdblokCrossPlatform.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    private readonly Service _service = new();
    private readonly Circle _circle1;
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(10));
    private bool IsChangeCircle1 = false;
    public List<IFigure> Figures { get; }
    
    private string x;
    public string X
    {
        get => x;
        set
        {
            x = value;
            OnPropertyChanged(nameof(X));
        }
    }

    private string y;
    public string Y
    {
        get => y;
        set
        {
            y = value;
            OnPropertyChanged(nameof(Y));
        }
    }

    public MainWindowViewModel()
    {
        _circle1 = new Circle
        {
            X = 100,
            Y = 150,
            Width = 50,
            Height = 50,
            Color = "Red"
        };
        
        Figures = new List<IFigure>
        {
            _circle1
        };

        Task.Run(WriteCoordinateSymbol);
    }

    public void ChangeCoordinateSymbol(double x, double y)
    {
        _circle1.X = x - _circle1.Width / 2;
        _circle1.Y = y - _circle1.Height / 2;

        var symbol = new Symbol
        {
            X = _circle1.X,
            Y = _circle1.Y,
        };

        //IsChangeCircle1 = true;
        
        Task.Run(() => _service.WriteSymbolsChangesAsync(symbol));
    }

    private async Task WriteCoordinateSymbol()
    {
        //IsChangeCircle1 = false;
        
        await foreach (var symbol in _service.ReadSymbolsChangesAsync())
        {
            _circle1.X = symbol.X;
            _circle1.Y = symbol.Y;
            X = symbol.X.ToString();
            Y = symbol.Y.ToString();

        }
    }

    public void CompleteStream()
    {
        Task.Run(_service.CompleteStream);
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}