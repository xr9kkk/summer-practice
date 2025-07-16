using System.Drawing;

namespace summer_practice
{
    public abstract class PlanetObject
    {
        public abstract string ObjectType { get; }
        public double AngleRadians { get; set; }

        public abstract void Draw(Graphics g, Point center, int radius);
    }

}
