using System.Collections.Generic;
using EdblokCrossPlatform.ViewModels.Figures;
using EdblokCrossPlatform.ViewModels.Figures.Interfaces;

namespace EdblokCrossPlatform.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<IFigure> Figures { get; } = new()
    {
        new Circle
        {
            X = 100,
            Y = 150,
            Width = 50,
            Height = 50,
            Color = "Red"
        },
        new Circle
        {
            X = 300,
            Y = 300,
            Width = 70,
            Height = 70,
            Color = "Black"
        },
        new Rectangle
        {
            X = 500,
            Y = 500,
            Width = 140,
            Height = 70,
            Color = "Blue"
        }
    };
}