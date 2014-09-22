//Create a class Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Create appropriate constructors. 
//Implement the ToString() to enable printing a 3D point.Add a private static read-only field in the Point3D class to hold the 
//start of the coordinate system – the point StartingPoint {0, 0, 0}. Add a static property to return the starting point.

using System;
using Points;
using System.Collections.Generic;

public class Path3D
{
    static void Main()
    {
        //creatae some 3D points and print them on the console
        Point3D firstPoint = new Point3D(1.10d, 2.30d, 1.65d);
        Point3D secondPoint =  new Point3D(3.55d,2.45d,34.55d);
        Point3D thirdPoint = new Point3D(4.55d, -7.45d, -934.55d);
        Point3D fourthPoint = new Point3D(-40.55d, 4.44d, 93.50d);
        Console.WriteLine(firstPoint);
        Console.WriteLine(secondPoint);
        Console.WriteLine();

        //print the starting coordinate system Point with the static property StartingPoint
        Console.WriteLine(Point3D.StartingPoint);
        Console.WriteLine();

        //print the distance between the two points using the static method CalculateDistance()
        Console.WriteLine(DistanceCalculator.CalculateDistance(firstPoint,secondPoint));
        Console.WriteLine();

        //create a list of points and save them  to the 'data.txt' file using the static method SvePoints() in the static class Storage
        List<Point3D> pointsList = new List<Point3D>() { firstPoint, secondPoint, thirdPoint, fourthPoint };
        Storage.SavePoints(pointsList);

        //read data from the file "data.txt" with the static method LoadPoints in the static class Storage
        List<Point3D> pointsFromFile = Storage.LoadPoints();
        foreach (var point in pointsFromFile)
        {
            Console.WriteLine(point);
        }



    }
}

