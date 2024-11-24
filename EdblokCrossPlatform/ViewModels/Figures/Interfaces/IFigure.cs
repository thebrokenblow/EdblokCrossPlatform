namespace EdblokCrossPlatform.ViewModels.Figures.Interfaces;

public interface IFigure
{ 
    double X { get; set; }
    double Y { get; set; }
    double Width { get; init; }
    double Height { get; init; }
    string? Color { get; init; }
}