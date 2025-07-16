using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace summer_practice
{
    public static class ColorExtensions
    {
        public static Color Lighten(this Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R + (255 - color.R) * factor),
                (int)(color.G + (255 - color.G) * factor),
                (int)(color.B + (255 - color.B) * factor));
        }

        public static Color Darken(this Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R * (1 - factor)),
                (int)(color.G * (1 - factor)),
                (int)(color.B * (1 - factor)));
        }
    }



    public class PlanetRenderer
    {
        public Color PlanetColor { get; set; } = Color.LightBlue;
        public List<PlanetObject> Objects { get; private set; } = new();

        private float planetRotationAngle = 0f;


        private void DrawPlanetBase(Graphics g, Point center, int radius, Color baseColor)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(center.X - radius, center.Y - radius, radius * 2, radius * 2);

                using (var planetBrush = new PathGradientBrush(path))
                {
                    planetBrush.CenterPoint = new PointF(center.X, center.Y);
                    planetBrush.CenterColor = baseColor.Lighten(0.3f);

                    planetBrush.SurroundColors = new[] { baseColor.Darken(0.2f) };

                    planetBrush.FocusScales = new PointF(0.7f, 0.7f);

                    g.FillEllipse(planetBrush,
                                 center.X - radius,
                                 center.Y - radius,
                                 radius * 2,
                                 radius * 2);
                }
            }
        }

        public void Draw(Graphics g, Size size)
        {
            Point center = new(size.Width / 2, size.Height / 2);
            int radius = Math.Min(size.Width, size.Height) / 3;

            var state = g.Save();

            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(planetRotationAngle * 180f / (float)Math.PI);
            g.TranslateTransform(-center.X, -center.Y);

            DrawPlanetSurface(g, center, radius);

            g.Restore(state);

            foreach (var obj in Objects)
                obj.Draw(g, center, radius);
        }


        private void DrawPlanetSurface(Graphics g, Point center, int radius)
        {
            DrawPlanetBase(g, center, radius, PlanetColor);


            DrawContinents(g, center, radius);

            DrawOceans(g, center, radius);

            DrawMountains(g, center, radius);

            DrawRivers(g, center, radius);

            using (var atmosphere = new Pen(Color.FromArgb(50, 173, 216, 230), 10))
            {
                g.DrawEllipse(atmosphere, center.X - radius - 5, center.Y - radius - 5,
                             (radius + 5) * 2, (radius + 5) * 2);
            }
        }

        private void DrawContinents(Graphics g, Point center, int radius)
        {
            Random rand = new Random(center.GetHashCode());
            List<Point> continentPoints = new List<Point>();

            for (int angle = 0; angle < 360; angle += 5)
            {
                double noise = rand.NextDouble() * 0.3 + 0.7; 
                int pointRadius = (int)(radius * noise);
                double rad = angle * Math.PI / 180;

                int x = center.X + (int)(pointRadius * Math.Cos(rad));
                int y = center.Y + (int)(pointRadius * Math.Sin(rad));
                continentPoints.Add(new Point(x, y));
            }

            using (var landBrush = new SolidBrush(Color.FromArgb(220, 34, 139, 34)))
            using (var path = new GraphicsPath())
            {
                path.AddClosedCurve(continentPoints.ToArray(), 0.5f);
                g.FillPath(landBrush, path);
            }
        }

        private void DrawMountains(Graphics g, Point center, int radius)
        {
            Random rand = new Random(center.GetHashCode());
            int mountainCount = rand.Next(5, 15);

            for (int i = 0; i < mountainCount; i++)
            {
                double angle = rand.NextDouble() * Math.PI * 2;
                double distance = rand.NextDouble() * 0.6 + 0.2;
                int x = center.X + (int)(radius * distance * Math.Cos(angle));
                int y = center.Y + (int)(radius * distance * Math.Sin(angle));

                int height = rand.Next(20, 60);
                int width = rand.Next(30, 80);

                Point[] mountain = {
            new Point(x - width/2, y),
            new Point(x, y - height),
            new Point(x + width/2, y)
        };

                using (var gradient = new LinearGradientBrush(
                    new Point(x, y - height),
                    new Point(x, y),
                    Color.LightGray,
                    Color.DarkGray))
                {
                    g.FillPolygon(gradient, mountain);
                }
            }
        }

        private void DrawRivers(Graphics g, Point center, int radius)
        {
            Random rand = new Random(center.GetHashCode());
            int riverCount = rand.Next(2, 5);

            for (int i = 0; i < riverCount; i++)
            {
                List<Point> riverPoints = new List<Point>();
                double angle = rand.NextDouble() * Math.PI * 2;

                double distance = rand.NextDouble() * 0.4 + 0.3;
                int startX = center.X + (int)(radius * distance * Math.Cos(angle));
                int startY = center.Y + (int)(radius * distance * Math.Sin(angle));
                riverPoints.Add(new Point(startX, startY));

                int segments = rand.Next(5, 15);
                for (int j = 1; j <= segments; j++)
                {
                    angle += (rand.NextDouble() - 0.5) * 0.5;
                    distance = distance * 0.9 + 0.1; 

                    int x = center.X + (int)(radius * distance * Math.Cos(angle));
                    int y = center.Y + (int)(radius * distance * Math.Sin(angle));
                    riverPoints.Add(new Point(x, y));
                }

                using (var riverPen = new Pen(Color.FromArgb(180, 65, 105, 225), rand.Next(2, 5)))
                {
                    g.DrawCurve(riverPen, riverPoints.ToArray(), 0.5f);
                }
            }
        }

        private void DrawOceans(Graphics g, Point center, int radius)
        {
            using (var oceanBrush = new LinearGradientBrush(
                new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2),
                Color.FromArgb(200, 0, 105, 148),
                Color.FromArgb(220, 25, 25, 112),
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillEllipse(oceanBrush, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
        }

        public void Rotate(float deltaDegrees)
        {
            float deltaRadians = (float)(deltaDegrees * Math.PI / 180f);
            planetRotationAngle = (float)((planetRotationAngle + deltaRadians) % (2 * Math.PI));

            foreach (var obj in Objects)
                obj.AngleRadians = (obj.AngleRadians + deltaRadians) % (2 * Math.PI);
        }


    }
}
