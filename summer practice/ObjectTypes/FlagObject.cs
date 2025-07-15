using summer_practice;
using System.Drawing;

namespace summer_practice
{
    public class FlagObject : PlanetObject
    {
        public override string ObjectType => "Flag";

        public override void Draw(Graphics g, Point center)
        {
            double angle = Math.Atan2(Position.Y - center.Y, Position.X - center.X);

            g.TranslateTransform(Position.X, Position.Y);
            g.RotateTransform((float)(angle * 180 / Math.PI + 90));

            // flagpole
            g.DrawLine(Pens.Black, 0, 0, 0, -20);
            // flag
            g.FillRectangle(Brushes.Red, 0, -20, 12, 6);

            g.ResetTransform();
        }
    }
}
