using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace task1;

public partial class RhombusViewModel : ObservableObject
{
    [ObservableProperty] private int angle = 45;


    [ObservableProperty] private string cordinates = "";
    [ObservableProperty] private double diagonal1 = 100;
    [ObservableProperty] private double diagonal2 = 150;


    private bool isDrawing;
    [ObservableProperty] private PointCollection points = new();
    [ObservableProperty] private float scale = 1;

    [ObservableProperty] private Point startPoint;


    public void AddPoint(Point point)
    {
        StartPoint = point;
        isDrawing = true;
    }


    private List<Point> CalculateRhombusPoints(Point centerPoint, double diagonal1, double diagonal2, double angle)
    {
        var rhombusPoints = new List<Point>();

        var halfDiagonal1 = diagonal1 / 2;
        var halfDiagonal2 = diagonal2 / 2;

        for (var i = 0; i < 4; i++)
        {
            var angleInRadians = (angle + i * 90) * Math.PI / 180;
            var x = centerPoint.X + Math.Cos(angleInRadians) * (i % 2 == 0 ? halfDiagonal1 : halfDiagonal2);
            var y = centerPoint.Y + Math.Sin(angleInRadians) * (i % 2 == 0 ? halfDiagonal1 : halfDiagonal2);
            rhombusPoints.Add(new Point(x, y));
        }

        return rhombusPoints;
    }


    [RelayCommand]
    public void DrawRhombus()
    {
        Points = new PointCollection(CalculateRhombusPoints(startPoint, 100, 150, 30));
        isDrawing = false;
    }
}