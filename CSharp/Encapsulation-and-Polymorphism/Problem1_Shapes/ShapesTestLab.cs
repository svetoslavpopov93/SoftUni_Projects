using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Shapes
{
    class ShapesTestLab
    {
        static void Main(string[] args)
        {
            // Triangles
            Triangle triangleA = new Triangle(21, 5);
            Triangle triangleB = new Triangle(23, 52);

            // Rectangles
            Rectangle rectangleA = new Rectangle(8, 7);
            Rectangle rectangleB = new Rectangle(28, 78);

            // Circles
            Circle circleA = new Circle(5);
            Circle circleB = new Circle(14);

            List<IShape> figures = new List<IShape>()
            {
                triangleA,
                triangleB,
                rectangleA,
                rectangleB,
                circleA,
                circleB
            };

            foreach (IShape figure in figures)
            {
                Console.WriteLine("{0}: Area = {1}, Perimeter = {2}", figure.GetType().Name, figure.CalculateArea(), figure.CalculatePerimeter());
            }
        }
    }
}
