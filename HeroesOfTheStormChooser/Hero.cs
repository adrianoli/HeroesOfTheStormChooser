using HeroesOfTheStormChooser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfTheStormChooser
{
    public class Hero
    {
        public Hero(string name)
        {
            Name = name;
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
