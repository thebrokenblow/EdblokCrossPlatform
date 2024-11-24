using EdblokCrossPlatform.ViewModels.Figures.Interfaces;

namespace EdblokCrossPlatform.ViewModels.Figures;

public class Rectangle : IFigure
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; init; }
    public double Height { get; init; }
    public string? Color { get; init; }
}