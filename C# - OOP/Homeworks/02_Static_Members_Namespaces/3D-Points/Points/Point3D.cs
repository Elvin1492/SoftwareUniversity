
namespace Points
{
    using System;

    public class Point3D
    {
        //define staic field holding the start coordinates 
        private static readonly Point3D STARTING_POINT = new Point3D(0.00d, 0.00d, 0.00d);

        //define auto properties
        public double coordinateX { get; set; }
        public double coordinateY { get; set; }
        public double coordinateZ { get; set; }

        //define a constructor with mandatory all three cooridnates
        public Point3D(double x, double y, double z)
        {
            this.coordinateX = x;
            this.coordinateY = y;
            this.coordinateZ = z;
        }

        //define a static property to return the StartingPoint
        public static Point3D StartingPoint
        {
            get { return Point3D.STARTING_POINT; }
        }

        //implement the ToString() method to enable printing a 3D Point
        public override string ToString()
        {
            return String.Format("Point with coordinates X: {0}, Y: {1}, Z: {2}", this.coordinateX, this.coordinateY, this.coordinateZ);
        }

    }
}
