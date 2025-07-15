using System.Drawing;

namespace summer_practice
{
    public abstract class PlanetObject
    {
        public Point Position { get; set; }
        public abstract string ObjectType { get; }
        public abstract void Draw(Graphics g, Point planetCenter);
    }
}
