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

            // Ствол
            using var trunkBrush = new SolidBrush(Color.SaddleBrown);
            g.FillEllipse(trunkBrush, -4, 0, 8, -20);

            // Крона — 3 "шара" (листья)
            using var leafBrush = new SolidBrush(Color.ForestGreen);
            g.FillEllipse(leafBrush, -12, -35, 24, 20);   // центральная
            g.FillEllipse(leafBrush, -18, -30, 18, 18);   // левая
            g.FillEllipse(leafBrush, 0, -30, 18, 18);     // правая

            g.ResetTransform();
        }
    }
}
