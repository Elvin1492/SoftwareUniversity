
namespace Points
{
    using System;

    //define a static class
    public static class DistanceCalculator
    {
        //define a static method to calculate the distance between two 3D points
        public static string CalculateDistance(Point3D point1, Point3D point2)
        {
            double distance =  Math.Sqrt(Math.Pow((point2.coordinateX - point1.coordinateX), 2) + 
                Math.Pow((point2.coordinateY - point1.coordinateY), 2) + Math.Pow((point2.coordinateZ - point1.coordinateZ), 2));
            return String.Format("The distance betwen {0} and {1} is: {2}",point1,point2, distance);
        }
    }
}
