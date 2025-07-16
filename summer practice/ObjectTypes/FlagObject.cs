using System;
using System.Drawing;

namespace summer_practice
{
    public class FlagObject : PlanetObject
    {
        public override string ObjectType => "Flag";

        public override void Draw(Graphics g, Point center, int radius)
        {
            // вычисляем положение на окружности
            Point pos = new(
                center.X + (int)(radius * Math.Cos(AngleRadians)),
                center.Y + (int)(radius * Math.Sin(AngleRadians))
            );

            g.TranslateTransform(pos.X, pos.Y);
            g.RotateTransform((float)(AngleRadians * 180 / Math.PI + 90));

            // флагшток
            g.DrawLine(Pens.Black, 0, 0, 0, -20);
            // флаг
            g.FillRectangle(Brushes.Red, 0, -20, 12, 6);

            g.ResetTransform();
        }
    }
}
