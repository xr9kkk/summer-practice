using summer_practice;
using System.Drawing;

namespace summer_practice
{
    public class HouseObject : PlanetObject
    {
        public override string ObjectType => "House";

        public override void Draw(Graphics g, Point center)
        {
            double angle = Math.Atan2(Position.Y - center.Y, Position.X - center.X);

            g.TranslateTransform(Position.X, Position.Y);
            g.RotateTransform((float)(angle * 180 / Math.PI + 90));

            // walls
            g.FillRectangle(Brushes.SandyBrown, -10, -15, 20, 15);
            // roof
            Point[] roof = new Point[]
            {
                new Point(-12, -15),
                new Point(0, -25),
                new Point(12, -15)
            };
            g.FillPolygon(Brushes.DarkRed, roof);

            g.ResetTransform();
        }
    }
}
