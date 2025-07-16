using System.Drawing;

namespace summer_practice.ObjectTypes
{
    public class TreeObject : PlanetObject
    {
        public override string ObjectType => "Tree";

        public override void Draw(Graphics g, Point center, int radius)
        {
            // Вычисляем позицию по углу
            Point pos = new(
                center.X + (int)(radius * Math.Cos(AngleRadians)),
                center.Y + (int)(radius * Math.Sin(AngleRadians))
            );

            // Поворот объекта к центру
            g.TranslateTransform(pos.X, pos.Y);
            g.RotateTransform((float)(AngleRadians * 180 / Math.PI + 90));

            // Рисуем как раньше
            using var trunk = new SolidBrush(Color.SaddleBrown);
            g.FillEllipse(trunk, -4, 0, 8, -20);
            using var leaf = new SolidBrush(Color.ForestGreen);
            g.FillEllipse(leaf, -12, -35, 24, 20);
            g.FillEllipse(leaf, -18, -30, 18, 18);
            g.FillEllipse(leaf, 0, -30, 18, 18);

            g.ResetTransform();
        }
    }
}
