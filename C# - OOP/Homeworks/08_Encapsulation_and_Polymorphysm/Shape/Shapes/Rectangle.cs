namespace Shape.Shapes
{
    using System;

    public class Rectangle : BasicShape, IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width" , "Width can not be a negative number.");
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

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height", "Height can not be a negative number");
                }

                this.height = value;
            }
        }

        public override double CalculateArea()
        {
            return this.width * this.height;
        }

        public override double CalculatePermeter()
        {
            return  2 * (this.width + this.height);
        }
    }
}
