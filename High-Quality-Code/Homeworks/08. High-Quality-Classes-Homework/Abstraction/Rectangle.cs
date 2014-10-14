using System;

namespace Abstraction
{
    public class Rectangle : Figure
    {

        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Width 
        { 
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width", "Width can not be zero or a negative number.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height", "Height can not be zero or a negative number.");
                }

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override double CalcArea()
        {
            double surface = this.Width * this.Height;

            return surface;
        }

    }
}
