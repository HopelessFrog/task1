using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace task1;

public partial class RhombusViewModel : ObservableObject
{
    RhombusViewModel()
    {
        Points = new PointCollection(new List<Point>()
            { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) });
    }
    private int angle = 45;


    [ObservableProperty] private string cordinates = "";
    [ObservableProperty] private double diagonal1 = 100;
    [ObservableProperty] private double diagonal2 = 150;
    [ObservableProperty] private PointCollection points = new();
    [ObservableProperty] private float scale = 1;

    [ObservableProperty] private Point startPoint;

    public int Angle
    {
        get => angle;
        set
        {
            if (value != angle)
            {
                angle = value;
                OnPropertyChanged();
                DrawRhombus();
            }
        }
    }


    public void AddPoint(Point point)
    {
        StartPoint = point;
        DrawRhombus();
        Cordinates = $"X:{StartPoint.X} Y:{StartPoint.Y}";
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
        Points = new PointCollection(CalculateRhombusPoints(startPoint, Diagonal1, Diagonal2, Angle));
    }
}