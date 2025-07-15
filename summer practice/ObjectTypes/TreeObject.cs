using System.Drawing;

namespace summer_practice.ObjectTypes
{
    public class TreeObject : PlanetObject
    {
        public override string ObjectType => "Tree";

        public override void Draw(Graphics g, Point center)
        {
            double angle = Math.Atan2(Position.Y - center.Y, Position.X - center.X);
            g.TranslateTransform(Position.X, Position.Y);
            g.RotateTransform((float)(angle * 180 / Math.PI + 90));

            g.FillRectangle(Brushes.SaddleBrown, -2, 0, 4, -10);
            g.FillEllipse(Brushes.ForestGreen, -6, -20, 12, 12);

            g.ResetTransform();
        }
    }
}
