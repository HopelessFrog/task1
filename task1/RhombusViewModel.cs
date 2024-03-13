using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace task1
{
    public partial class RhombusViewModel : ObservableObject
    {
       
       
        private bool isDrawing = false;
        


        [ObservableProperty] private string cordinates = "";
        [ObservableProperty] private float scale = 1;
        [ObservableProperty] private int angle = 45;
        [ObservableProperty] private double diagonal1 = 100;
        [ObservableProperty] private double diagonal2 = 150;
        [ObservableProperty] 
        private Point startPoint;
        [ObservableProperty] private PointCollection rPoint = new PointCollection();
        [ObservableProperty] private PointCollection points = new PointCollection();





        public RhombusViewModel()
        {
            rPoint.Add(startPoint);
        }



        public void AddPoint(Point point)
        {
            startPoint = point;
            isDrawing = true;
            OnPropertyChanged(nameof(RPoint));
        }

        
       
        private List<Point> CalculateRhombusPoints(Point centerPoint, double diagonal1, double diagonal2, double angle)
        {
            List<Point> rhombusPoints = new List<Point>();

            double halfDiagonal1 = diagonal1 / 2;
            double halfDiagonal2 = diagonal2 / 2;

            for (int i = 0; i < 4; i++)
            {
                double angleInRadians = (angle + i * 90) * Math.PI / 180;
                double x = centerPoint.X + Math.Cos(angleInRadians) * (i % 2 == 0 ? halfDiagonal1 : halfDiagonal2);
                double y = centerPoint.Y + Math.Sin(angleInRadians) * (i % 2 == 0 ? halfDiagonal1 : halfDiagonal2);
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
}
