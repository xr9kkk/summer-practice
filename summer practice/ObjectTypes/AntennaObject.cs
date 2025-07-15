
namespace summer_practice
{
    public class AntennaObject : PlanetObject
    {
        public override string ObjectType => "Antenna";

        public override void Draw(Graphics g, Point center)
        {
            double angle = Math.Atan2(Position.Y - center.Y, Position.X - center.X);

            g.TranslateTransform(Position.X, Position.Y);
            g.RotateTransform((float)(angle * 180 / Math.PI + 90));

            // base
            g.DrawLine(Pens.Gray, 0, 0, 0, -20);
            // antenna dish
            g.DrawEllipse(Pens.Silver, -5, -30, 10, 10);
            g.FillEllipse(Brushes.LightGray, -5, -30, 10, 10);
            // signal lines
            g.DrawArc(Pens.DarkBlue, -10, -35, 20, 20, 0, 180);
            g.DrawArc(Pens.DarkBlue, -15, -40, 30, 30, 0, 180);

            g.ResetTransform();
        }
    }
}
