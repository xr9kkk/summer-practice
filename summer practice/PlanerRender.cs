using System.Collections.Generic;
using System.Drawing;

namespace summer_practice
{
    public class PlanetRenderer
    {
        public Color PlanetColor { get; set; } = Color.LightBlue;
        public List<PlanetObject> Objects { get; private set; } = new();

        public void Draw(Graphics g, Size canvasSize)
        {
            Point center = new(canvasSize.Width / 2, canvasSize.Height / 2);
            int radius = Math.Min(canvasSize.Width, canvasSize.Height) / 3;

            using var brush = new SolidBrush(PlanetColor);
            g.FillEllipse(brush, center.X - radius, center.Y - radius, radius * 2, radius * 2);

            foreach (var obj in Objects)
                obj.Draw(g, center);
        }
    }
}
