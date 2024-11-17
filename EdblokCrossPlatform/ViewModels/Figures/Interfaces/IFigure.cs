namespace EdblokCrossPlatform.ViewModels.Figures.Interfaces;

public interface IFigure
{ 
    double X { get; init; }
    double Y { get; init; }
    double Width { get; init; }
    double Height { get; init; }
    string? Color { get; init; }
}