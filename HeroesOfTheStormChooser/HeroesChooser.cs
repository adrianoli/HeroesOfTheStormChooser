using HeroesOfTheStormChooser.Configuration;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeroesOfTheStormChooser
{
    public partial class HeroesChooser : Form
    {
        private GenerateHeroAndMap _generateHeroAndMap;

        public HeroesChooser()
        {
            InitializeComponent();
            List<PictureBox> ally = new List<PictureBox>
            {
                uiPcbAlly1,
                uiPcbAlly2,
                uiPcbAlly3,
                uiPcbAlly4
            };

            List<PictureBox> opponents = new List<PictureBox>
            {
                uiPcbOpponent1,
                uiPcbOpponent2,
                uiPcbOpponent3,
                uiPcbOpponent4,
                uiPcbOpponent5
            };

            _generateHeroAndMap = new GenerateHeroAndMap(uiGpYourAlly, this, ally, uiPcbMap, opponents);
            _generateHeroAndMap.Initialize();
        }

        private void uiPcbAlly1_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbAlly2_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbAlly3_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbAlly4_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbMap_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbOpponent1_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbOpponent2_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbOpponent3_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbOpponent4_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiPcbOpponent5_Click(object sender, EventArgs e)
        {
            ClearPictureBox(sender);
        }

        private void uiBtnChangeAllyOpponent_Click(object sender, EventArgs e)
        {
        }

        private void uiBtnAnalyze_Click(object sender, EventArgs e)
        {
            _generateHeroAndMap.ResetPoints();

            string map = uiPcbMap.Tag?.ToString();

            if(string.IsNullOrEmpty(map))
            {
                map = string.Empty;
            }

            List<Hero> ally = new List<Hero>();
            List<Hero> opponents = new List<Hero>();

            Hero hero = uiPcbAlly1.Tag as Hero;

            if(hero != null)
            {
                ally.Add(hero);
            }

            hero = uiPcbAlly2.Tag as Hero;

            if (hero != null)
            {
                ally.Add(hero);
            }

            hero = uiPcbAlly3.Tag as Hero;

            if (hero != null)
            {
                ally.Add(hero);
            }

            hero = uiPcbAlly4.Tag as Hero;

            if (hero != null)
            {
                ally.Add(hero);
            }

            hero = uiPcbOpponent1.Tag as Hero;

            if (hero != null)
            {
                opponents.Add(hero);
            }

            hero = uiPcbOpponent2.Tag as Hero;

            if (hero != null)
            {
                opponents.Add(hero);
            }

            hero = uiPcbOpponent3.Tag as Hero;

            if (hero != null)
            {
                opponents.Add(hero);
            }

            hero = uiPcbOpponent4.Tag as Hero;

            if (hero != null)
            {
                opponents.Add(hero);
            }

            hero = uiPcbOpponent5.Tag as Hero;

            if (hero != null)
            {
                opponents.Add(hero);
            }

            _generateHeroAndMap.Analyze(ally, opponents, map);
        }

        private void uiTxtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void HeroesChooser_Resize(object sender, EventArgs e)
        {
            _generateHeroAndMap.ResizeControl();
        }

        private void ClearPictureBox(object sender)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if(pictureBox.Image != null)
            {
                pictureBox.Image = null;
            }

            pictureBox.Tag = null;
        }

        private void uiBtnReset_Click(object sender, EventArgs e)
        {
            uiPcbAlly1.Image = null;
            uiPcbAlly1.Tag = null;

            uiPcbAlly2.Image = null;
            uiPcbAlly2.Tag = null;

            uiPcbAlly3.Image = null;
            uiPcbAlly3.Tag = null;

            uiPcbAlly4.Image = null;
            uiPcbAlly4.Tag = null;

            uiPcbMap.Image = null;
            uiPcbMap.Tag = null;

            uiPcbOpponent1.Image = null;
            uiPcbOpponent1.Tag = null;

            uiPcbOpponent2.Image = null;
            uiPcbOpponent2.Tag = null;

            uiPcbOpponent3.Image = null;
            uiPcbOpponent3.Tag = null;

            uiPcbOpponent4.Image = null;
            uiPcbOpponent4.Tag = null;

            uiPcbOpponent5.Image = null;
            uiPcbOpponent5.Tag = null;
        }

        private void uiTsmConfiguration_Click(object sender, EventArgs e)
        {
            
        }

        private void uiTsmHeroConfiuration_Click(object sender, EventArgs e)
        {
            using (var configurationForm = new ConfigurationForm())
            {
                configurationForm.ShowDialog();
            }
        }

        private void uiTsmiAddNewHero_Click(object sender, EventArgs e)
        {
            object jsonFile = JsonManager.LoadJsonFile("Heroes.json");

            using (var heroAddForm = new HeroConfiguration(jsonFile))
            {
                heroAddForm.ShowDialog();
            }
        }
    }
}
