using System;
using System.Drawing;

namespace summer_practice
{
    public class AntennaObject : PlanetObject
    {
        public override string ObjectType => "Antenna";

        public override void Draw(Graphics g, Point center, int radius)
        {
            Point pos = new(
                center.X + (int)(radius * Math.Cos(AngleRadians)),
                center.Y + (int)(radius * Math.Sin(AngleRadians))
            );

            g.TranslateTransform(pos.X, pos.Y);
            g.RotateTransform((float)(AngleRadians * 180 / Math.PI + 90));

            // основание антенны
            g.DrawLine(Pens.Gray, 0, 0, 0, -20);
            // "тарелка"
            g.FillEllipse(Brushes.LightGray, -5, -30, 10, 10);
            g.DrawEllipse(Pens.Silver, -5, -30, 10, 10);
            // радиосигналы
            g.DrawArc(Pens.DarkBlue, -10, -35, 20, 20, 0, 180);
            g.DrawArc(Pens.DarkBlue, -15, -40, 30, 30, 0, 180);

            g.ResetTransform();
        }
    }
}
