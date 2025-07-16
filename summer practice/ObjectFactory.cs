using summer_practice.ObjectTypes;
using System.Drawing;
using System.Media;

namespace  summer_practice

{
    public static class ObjectFactory
    {

        public static PlanetObject Create(string type, Point clickPos, Point center)
        {
            double dx = clickPos.X - center.X;
            double dy = clickPos.Y - center.Y;
            double angle = Math.Atan2(dy, dx);

            return CreateInternal(type, angle, playSound: true);
        }
        public static PlanetObject Create(string type, double angle)
        {
            return CreateInternal(type, angle, playSound: false); // не воспроизводим звук при загрузке
        }

        private static PlanetObject CreateInternal(string type, double angle, bool playSound)
        {
            PlanetObject obj = type switch
            {
                "Tree" => new TreeObject(),
                "House" => new HouseObject(),
                "Flag" => new FlagObject(),
                "Antenna" => new AntennaObject(),
                _ => null
            };

            if (obj != null)
            {
                obj.AngleRadians = angle;

                if (playSound)
                {
                    var sound = type switch
                    {
                        "Tree" => Properties.Resources.tree,
                        "House" => Properties.Resources.house,
                        "Flag" => Properties.Resources.flag,
                        "Antenna" => Properties.Resources.antenna,
                        _ => null
                    };

                    new SoundPlayer(sound)?.Play();
                }
            }

            return obj;
        }
    }
}
