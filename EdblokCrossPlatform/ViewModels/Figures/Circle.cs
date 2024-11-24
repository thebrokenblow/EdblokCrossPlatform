using System.ComponentModel;
using EdblokCrossPlatform.ViewModels.Figures.Interfaces;

namespace EdblokCrossPlatform.ViewModels.Figures;

public class Circle : ViewModelBase, IFigure,  INotifyPropertyChanged
{
    private double x;

    public double X
    {
        get => x;
        set
        {
            x = value;
            OnPropertyChanged(nameof(X));
        }
    }

    private double y;
    public double Y
    {
        get => y;
        set
        {
            y = value;
            OnPropertyChanged(nameof(Y));
        }
    }
    public double Width { get; init; }
    public double Height { get; init; }
    public string? Color { get; init; }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}