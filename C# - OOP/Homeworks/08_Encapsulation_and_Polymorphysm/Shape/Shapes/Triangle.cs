  namespace Shape.Shapes
{
    using System;

    public class Triangle : BasicShape, IShape
    {
        private double sizeA;
        private double sizeB;
        private double sizeC;

        public Triangle(double sizeA, double sizeB, double sizeC)
        {
            this.SizeA = sizeA;
            this.SizeB = sizeB;
            this.SizeC = sizeC;

            if (!TriangleIsValid(this.SizeA, this.SizeB, this.SizeC))
            {
                throw new ArgumentException("These three sides can not form a triangle.");  
            }
        }

        public double SizeA
        {
            get
            {
                return this.sizeA;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("sizeA", "sizeA can not be a negative number.");
                }

                this.sizeA = value;
            }
        }

        public double SizeB
        {
            get
            {
                return this.sizeB;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("sizeB", "sizeA can not be a negative number.");
                }

                this.sizeB = value;
            }
        }

        public double SizeC
        {
            get
            {
                return this.sizeC;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("sizeB", "sizeA can not be a negative number.");
                }

                this.sizeC = value;
            }
        }

        public override double CalculateArea()
        {
            double halfPerimeter = (this.sizeA + this.sizeB + this.sizeC) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - this.sizeA) * (halfPerimeter - this.sizeB) * (halfPerimeter - this.sizeC));
        }
 
        public override double CalculatePermeter()
        {
            return this.sizeA + this.sizeB + this.sizeC;
        }

        // a private method to check if the three sides can forma a triange
        private bool TriangleIsValid(double sizeA, double sizeB, double sizeC)
        {
            return sizeA + sizeB > sizeC && sizeB + sizeC > sizeA && sizeA + sizeC > sizeB;
        }
    }
}
