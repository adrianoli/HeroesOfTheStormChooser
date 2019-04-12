using HeroesOfTheStormChooser.Enums;
using System.Collections.Generic;

namespace HeroesOfTheStormChooser
{
    public class Hero
    {
        public Hero()
        {
            Name = string.Empty;
            Initialize();
        }

        public Hero(string name)
        {
            Name = name;
            Initialize();
        }

        private void Initialize()
        {
            Synergizes = new List<string>();
            Strongs = new List<string>();
            Counters = new List<string>();
            GoodMaps = new List<string>();
            WeakMaps = new List<string>();
            CrowdControls = new List<string>();

            Points = 0;

        }

        public string Name { get; set; }
        public eRole Role { get; set; }
        public eAttackType AttackType { get; set; }

        public List<string> Synergizes { get; set; }
        public List<string> Strongs { get; set; }
        public List<string> Counters { get; set; }
        public List<string> GoodMaps { get; set; }
        public List<string> WeakMaps { get; set; }
        public List<string> CrowdControls { get; set; }

        public int Points { get; set; }
    }
}
