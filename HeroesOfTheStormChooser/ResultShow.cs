using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroesOfTheStormChooser
{
    public partial class ResultShow : Form
    {
        private int _marginHeight = 16;
        private int _marginWidth = 5;
        private int _pictureBoxWidth = 63;
        private int _pictureBoxHeight = 59;

        public ResultShow(List<List<Hero>> heroesList)
        {
            InitializeComponent();
            Initialize(heroesList);
        }

        private void Initialize(List<List<Hero>> heroesList)
        {
            int groupBoxWidth = GetMainFormWidth(this);
            int horizontalAmount = GetHorizontalAmount(groupBoxWidth, _pictureBoxWidth + _marginWidth);

            Control lastControl = uiLblInfo;

            foreach (var heroes in heroesList)
            {
                Hero hero = heroes[0];

                int verticalAmount = (int)Math.Ceiling((double)heroes.Count / (double)horizontalAmount);
                Control groupBox = CreateGroupBoxControl(lastControl, this, hero.Points.ToString(), $"Bohaterowie, którzy zebrali {hero.Points} punktów", verticalAmount);
                this.Controls.Add(groupBox);
                CreateHeroControl(groupBox, horizontalAmount, heroes);
                lastControl = groupBox;
            }                      
        }

        private Control CreateGroupBoxControl(Control lastControl, Control mainForm, string name, string text, int amountVertical)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Name = name;
            groupBox.Text = text;
            groupBox.Location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + _marginHeight);
            groupBox.Size = new Size(GetMainFormWidth(mainForm), amountVertical * (_marginHeight + _pictureBoxHeight));

            return groupBox;
        }

        private int GetMainFormWidth(Control mainForm)
        {
            return mainForm.Width - 2 * _marginHeight;
        }

        private int GetHorizontalAmount(int Width, int OneControlSizeWithMargin)
        {
            return Width / OneControlSizeWithMargin;
        }

        private void CreateHeroControl(Control heroGroupBox, int horizontalAmount, List<Hero> heroes)
        {
            int actualHeight = _marginHeight;
            int actualWidth = _marginWidth;

            int counter = 0;

            foreach (var hero in heroes)
            {
                if (counter % horizontalAmount == 0 && counter != 0)
                {
                    actualHeight = actualHeight + _pictureBoxHeight + _marginHeight;
                    actualWidth = _marginWidth;
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = hero.Name;
                pictureBox.Tag = hero;
                pictureBox.Location = new Point(actualWidth, actualHeight);
                pictureBox.Size = new Size(_pictureBoxWidth, _pictureBoxHeight);
                pictureBox.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\{"Assets\\HeroesIcons"}\\{hero.Name}.png");
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                new ToolTip().SetToolTip(pictureBox, hero.Name);
                heroGroupBox.Controls.Add(pictureBox);

                actualWidth = actualWidth + _marginWidth + _pictureBoxWidth;

                counter++;
            }
        }
    }
}
