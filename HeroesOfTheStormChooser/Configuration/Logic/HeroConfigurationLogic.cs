using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfTheStormChooser.Configuration.Logic
{
    public class HeroConfigurationLogic
    {
        private Hero _hero;
        private object _jsonConfiguration;

        public HeroConfigurationLogic(Hero hero, object jsonConfiguration)
        {
            _hero = hero;
            _jsonConfiguration = jsonConfiguration;
        }

        public Image GetHeroImage()
        {
            return Image.FromFile($"{Directory.GetCurrentDirectory()}\\{"Assets\\HeroesIcons"}\\{_hero.Name}.png");
        }

        public string GetHeroName()
        {
            return _hero.Name;
        }
    }
}
