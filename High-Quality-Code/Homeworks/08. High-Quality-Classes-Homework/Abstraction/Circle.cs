using System;

namespace Abstraction
{
    public class Circle : Figure
    {
        private double radius;
        public double Radius
        { 
            get
            {
                return this.radius;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius","Radius can not be zezro or a negatie number.");
                }

                this.radius = value;
            }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double CalcArea()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
