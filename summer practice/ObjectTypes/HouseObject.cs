using System;
using System.Drawing;

namespace summer_practice
{
    public class HouseObject : PlanetObject
    {
        public override string ObjectType => "House";

        public override void Draw(Graphics g, Point center, int radius)
        {
            Point pos = new(
                center.X + (int)(radius * Math.Cos(AngleRadians)),
                center.Y + (int)(radius * Math.Sin(AngleRadians))
            );

            g.TranslateTransform(pos.X, pos.Y);
            g.RotateTransform((float)(AngleRadians * 180 / Math.PI + 90));

            // стены
            g.FillRectangle(Brushes.SandyBrown, -10, -15, 20, 15);
            // крыша
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
