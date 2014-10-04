namespace Shape.Shapes
{
    using System;

    public abstract class BasicShape : IShape
    {
        public abstract double CalculateArea();

        public abstract double CalculatePermeter();
    
        public override string ToString()
        {
            return String.Format("{0}: Area: {1:0.##} Perimeter: {2:0.##}", 
                this.GetType().Name, this.CalculateArea(), this.CalculatePermeter());
        }
    }
}
