using HeroesOfTheStormChooser.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroesOfTheStormChooser.Configuration
{
    public class CreateControlClass
    {
        public int MarginHeight { get; }
        public int MarginWidth { get; }
        public int PictureBoxWidth { get; }
        public int PictureBoxHeight { get; }

        public List<Hero> Heroes { get; set; }

        public CreateControlClass()
        {
            MarginHeight = 16;
            MarginWidth = 5;
            PictureBoxWidth = 63;
            PictureBoxHeight = 59;

            Heroes = JsonManager.LoadHeroesJson();
        }

        public void CreateHeroes(Control mainForm, Control lastControl)
        {
            int groupBoxWidth = GetMainFormWidth(mainForm, MarginHeight);
            int horizontalAmount = GetHorizontalAmount(groupBoxWidth, PictureBoxWidth + MarginWidth);
            int verticalAmount = 0;

            var groupedHeroRoleList = Heroes.GroupBy(u => u.Role).Select(grp => grp.ToList()).ToList();

            Control heroesGroupBox = lastControl;

            foreach (var groupRole in groupedHeroRoleList)
            {
                verticalAmount = (int)Math.Ceiling((double)groupRole.Count / (double)horizontalAmount);
                Hero hero = groupRole[0];
                heroesGroupBox = CreateGroupBoxControl(heroesGroupBox, mainForm, hero.Role.ToString(), $"Wybór bohaterów dla: {hero.Role.ToString()}", verticalAmount);
                heroesGroupBox.ForeColor = GetColorForRole(hero.Role);
                mainForm.Controls.Add(heroesGroupBox);
                CreateHeroControl(heroesGroupBox, horizontalAmount, groupRole);
            }
        }

        public Control CreateGroupBoxControl(Control lastControl, Control mainForm, string name, string text, int amountVertical)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Name = name;
            groupBox.Text = text;
            groupBox.Location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + MarginHeight);
            groupBox.Size = new Size(GetMainFormWidth(mainForm, MarginHeight), amountVertical * (MarginHeight + PictureBoxHeight));

            return groupBox;
        }

        public static int GetMainFormWidth(Control mainForm, int marginHeight)
        {
            return mainForm.Width - 2 * marginHeight;
        }

        public static int GetHorizontalAmount(int width, int oneControlSizeWithMargin)
        {
            return width / oneControlSizeWithMargin;
        }

        public int GetHorizontalFromMainForm(Control mainForm)
        {
            return GetHorizontalAmount(GetMainFormWidth(mainForm, MarginHeight), PictureBoxWidth + MarginWidth);
        }

        public static Color GetColorForRole(eRole role)
        {
            switch (role)
            {
                case eRole.Tank:
                    return Color.Gray;
                case eRole.Bruiser:
                    return Color.Brown;
                case eRole.Support:
                    return Color.Orange;
                case eRole.MeleeAssasin:
                    return Color.Violet;
                case eRole.RangedAssasin:
                    return Color.Red;
                case eRole.Healer:
                    return Color.Green;
                default:
                    return Color.Black;
            }
        }

        private void CreateHeroControl(Control heroGroupBox, int horizontalAmount, List<Hero> heroes)
        {
            int actualHeight = MarginHeight;
            int actualWidth = MarginWidth;

            int counter = 0;

            foreach (var hero in heroes)
            {
                if (counter % horizontalAmount == 0 && counter != 0)
                {
                    actualHeight = actualHeight + PictureBoxHeight + MarginHeight;
                    actualWidth = MarginWidth;
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = hero.Name;
                pictureBox.Tag = hero;
                pictureBox.Location = new Point(actualWidth, actualHeight);
                pictureBox.Size = new Size(PictureBoxWidth, PictureBoxHeight);
                pictureBox.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\{"Assets\\HeroesIcons"}\\{hero.Name}.png");
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;               

                new ToolTip().SetToolTip(pictureBox, hero.Name);
     
                heroGroupBox.Controls.Add(pictureBox);
                actualWidth = actualWidth + MarginWidth + PictureBoxWidth;

                counter++;
            }
        }

        public void RemoveHero(string heroName)
        {
            for(int i = 0; i < Heroes.Count; i++)
            {
                if(Heroes[i].Name == heroName)
                {
                    Heroes.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
