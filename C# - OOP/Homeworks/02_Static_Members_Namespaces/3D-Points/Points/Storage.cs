
namespace Points
{
using System;
using System.Collections.Generic;
using System.IO;

    //define a static class storage
    static class Storage
    {
        //define a static method which writes in a file the point coordinates from a List of points
        public static void SavePoints(List<Point3D> pointsList)
        {
            //create a new stream writer
            StreamWriter writer = new StreamWriter("../../data.txt", true);
            using(writer)
            {
                //foreach all points in the list and save each point's coordinate in the "data.txt" file
                foreach (var point in pointsList)
                {
                    string line = String.Format("X: {0} Y: {1} Z: {1}", point.coordinateX, point.coordinateY, point.coordinateZ);
                    writer.WriteLine(line);
                }
            }
        }

        //define a static method which writes loads point coordinates from a data file 'data.txt' and returns them in a list 
        public static List<Point3D> LoadPoints()
        {
            //create a new StreamReader and a list to store the points in it
            List<Point3D> pointsList = new List<Point3D>();
            StreamReader reader = new StreamReader("../../data.txt", true);

            using(reader)
            {
                string currentLline;

                //read from the fie while we have lines
                while ((currentLline = reader.ReadLine()) != null)
                {
                    //split the string we read from the file(X: 1.1 Y: 2.3  Z: 2.3) by " "(whitespce) to get the 
                    //values of the coordinats which  will assigning to the points in our list
                    string[] values = currentLline.Split(' ');
                    object coordinateX = Convert.ChangeType(values[1], typeof(double));
                    object coordinateY = Convert.ChangeType(values[3], typeof(double));
                    object coordinateZ = Convert.ChangeType(values[5], typeof(double));

                    //create a new point with the coordinates and add it tho the list
                    Point3D currentPoint  = new Point3D((double)coordinateX, (double)coordinateY, (double)coordinateZ);
                    pointsList.Add(currentPoint);
                }
                
            }
            return pointsList;
        }
    }
}
