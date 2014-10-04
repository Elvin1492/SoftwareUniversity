namespace Shape.Shapes
{
    using System;

    class ShapesTest
    {
        static void Main()
        {
            IShape[] shapes = new IShape[]
            {
                new Triangle(6, 4, 5),
                new Rectangle(5.6, 0.97),                
                new Circle(7.7777)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
