namespace Shape.Shapes
{
    using System;

    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        {
            get
            {
                return this.radius;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Radius", "Radius can not be a negative number");
                }

                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            return 2 * Math.PI * this.radius;
        }

        public double CalculatePermeter()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override string ToString()
        {
            return String.Format("{0}: Area: {1:0.##} Perimeter: {2:0.##}",
                this.GetType().Name, this.CalculateArea(), this.CalculatePermeter());
        }
    }
}
