using EdblokCrossPlatform.ViewModels.Figures.Interfaces;

namespace EdblokCrossPlatform.ViewModels.Figures;

public class Circle : IFigure
{
    public double X { get; init; }
    public double Y { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }
    public string? Color { get; init; }
}