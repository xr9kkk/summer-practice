using summer_practice.ObjectTypes;
using System.Drawing;
using System.Media;

namespace  summer_practice

{
    public static class ObjectFactory
    {
        public static PlanetObject Create(string type, Point pos)
        {
            PlanetObject obj = type switch
            {
                "Tree" => new TreeObject { Position = pos },
                "House" => new HouseObject { Position = pos },
                "Flag" => new FlagObject { Position = pos },
                "Antenna" => new AntennaObject { Position = pos },
                _ => null
            };

            if (obj != null)
            {
                var sound = type switch
                {
                    "Tree" => Properties.Resources.tree,
                    "House" => Properties.Resources.house,
                    "Flag" => Properties.Resources.flag,
                    "Antenna" => Properties.Resources.antenna,
                    _ => null
                };

                new SoundPlayer(sound).Play();
            }

            return obj;
        }
    }
}
