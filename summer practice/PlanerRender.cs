using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace summer_practice
{
    public class PlanetRenderer
    {
        public Color PlanetColor { get; set; } = Color.LightBlue;
        public List<PlanetObject> Objects { get; private set; } = new();

        private float planetRotationAngle = 0f;
        public void Draw(Graphics g, Size canvasSize)
        {
            Point center = new(canvasSize.Width / 2, canvasSize.Height / 2);
            int radius = Math.Min(canvasSize.Width, canvasSize.Height) / 3;

            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(planetRotationAngle);
            g.TranslateTransform(-center.X, -center.Y);

            // Океан
            using var oceanBrush = new SolidBrush(Color.SteelBlue);
            g.FillEllipse(oceanBrush, center.X - radius, center.Y - radius, radius * 2, radius * 2);

            // Материк 1
            using var landBrush = new SolidBrush(Color.ForestGreen);
            g.FillEllipse(landBrush, center.X - radius / 2, center.Y - radius / 3, radius, radius / 2);

            // Материк 2
            g.FillEllipse(landBrush, center.X - radius / 1.5f, center.Y + radius / 4, radius / 1.5f, radius / 2);

            // Озеро
            using var lakeBrush = new SolidBrush(Color.LightBlue);
            g.FillEllipse(lakeBrush, center.X - 20, center.Y - 10, 40, 20);

            // Горы


            using var mountainBrush = new SolidBrush(Color.SaddleBrown);
            Point[] mountain1 = {
        new Point(center.X - 50, center.Y - 20),
        new Point(center.X - 30, center.Y - 60),
        new Point(center.X - 10, center.Y - 20)
    };
            Point[] mountain2 = {
        new Point(center.X + 20, center.Y - 15),
        new Point(center.X + 35, center.Y - 45),
        new Point(center.X + 55, center.Y - 15)
    };
            g.FillPolygon(mountainBrush, mountain1);
            g.FillPolygon(mountainBrush, mountain2);

            // Река
            using var riverPen = new Pen(Color.CornflowerBlue, 3);
            g.DrawBezier(riverPen,
                new Point(center.X - 70, center.Y + 20),
                new Point(center.X - 40, center.Y + 10),
                new Point(center.X + 10, center.Y + 40),
                new Point(center.X + 40, center.Y + 10)
            );

            g.ResetTransform();
            // Объекты
            foreach (var obj in Objects)
                obj.Draw(g, center);
        }
        public void RotatePlanet(float deltaAngle)
        {
            planetRotationAngle = (planetRotationAngle + deltaAngle) % 360;
        }
    }
}
