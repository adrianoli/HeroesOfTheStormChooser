using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroesOfTheStormChooser.Configuration
{
    public partial class ConfigurationForm : Form
    {
        private List<Hero> _heroes;

        public ConfigurationForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            GenerateHeroAndMap generateHeroAndMap = new GenerateHeroAndMap(null, this, null, null, null);
            generateHeroAndMap.InitializeHeroConfiguration();
        }

        
    }
}
