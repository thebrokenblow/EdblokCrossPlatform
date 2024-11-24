using Avalonia.Controls;
using Avalonia.Input;
using EdblokCrossPlatform.ViewModels;

namespace EdblokCrossPlatform.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel? _viewModel;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        var point = e.GetCurrentPoint(this);
        var x = point.Position.X;
        var y = point.Position.Y;

        _viewModel ??= (MainWindowViewModel) DataContext!;
        _viewModel.ChangeCoordinateSymbol(x, y);
    }
}