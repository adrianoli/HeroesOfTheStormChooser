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

namespace HeroesOfTheStormChooser.Configuration
{
    public partial class AddHeroesToList : Form
    {
        public List<string> Result { get; private set; }
        private List<Hero> _heroes;
        private CreateControlClass _createControl;

        private const int StartPosition = 5;

        private string groupBoxResultName = "ResultGroupBox";


        public AddHeroesToList(string groupBoxName, string heroName, List<string> heroes)
        {
            InitializeComponent();
            this.Text = heroName;
            Initialize(groupBoxName, heroName, heroes);
        }

        private void Initialize(string groupBoxName, string heroName, List<string> heroes)
        {
            Result = new List<string>();
            _heroes = new List<Hero>();

            _createControl = new CreateControlClass();
            _createControl.RemoveHero(heroName);

            int count = heroes.Count == 0 ? 1 : heroes.Count;

            int verticalAmount = (int)Math.Ceiling((double)count / (double)_createControl.GetHorizontalFromMainForm(this));
            Control groupBox = _createControl.CreateGroupBoxControl(new Control { Location = new Point(StartPosition, StartPosition), Size = new Size(StartPosition, StartPosition) },
                this, groupBoxResultName, groupBoxName, verticalAmount);

            foreach(string name in heroes)
            {
                AddHero(name, groupBox);
            }

            this.Controls.Add(groupBox);

            _createControl.CreateHeroes(this, groupBox);

            AddEvents();
        }

        private void AddHero(string heroName, Control groupBoxResult)
        {
            Hero hero = FindHero(heroName);

            if(hero == null)
            {
                return;
            }

            if(Result.Any(x => x == hero.Name))
            {
                return;
            }

            Result.Add(hero.Name);
            CreatePictureBoxControl(hero, groupBoxResult, FindNewLocation(groupBoxResult));
        }

        private Point FindNewLocation(Control groupControl)
        {
            Point locationTheLastControl = FindLocationTheLastControl(groupControl);
            Point newLocation;

            if (locationTheLastControl.X == int.MinValue)
            {
                newLocation = new Point(_createControl.MarginWidth, _createControl.MarginHeight);
                return newLocation;
            }

            newLocation = new Point(locationTheLastControl.X + _createControl.MarginWidth + _createControl.PictureBoxWidth, locationTheLastControl.Y);

            if(newLocation.X + _createControl.PictureBoxWidth > groupControl.Width)
            {
                int moveValue = _createControl.MarginHeight + _createControl.PictureBoxHeight;
                groupControl.Height = groupControl.Height + moveValue;

                newLocation = new Point(_createControl.MarginWidth, newLocation.Y + moveValue);
                MoveOtherGroupBox(moveValue, groupControl.Name);              
            }

            return newLocation;
        }

        private Point FindLocationTheLastControl(Control groupBoxControl)
        {
            Point theLastLocationPictureBox = new Point(int.MinValue, int.MinValue);

            foreach(Control control in groupBoxControl.Controls)
            {
                PictureBox pictureBox = control as PictureBox;

                if(pictureBox == null)
                {
                    continue;
                }

                if (pictureBox.Location.Y == theLastLocationPictureBox.Y)
                {
                    if (pictureBox.Location.X > theLastLocationPictureBox.X)
                    {
                        theLastLocationPictureBox = pictureBox.Location;
                    }
                }

                if (pictureBox.Location.Y > theLastLocationPictureBox.Y)
                {
                    theLastLocationPictureBox = pictureBox.Location;         
                }
                
            }

            return theLastLocationPictureBox;
        }

        private void MoveOtherGroupBox(int moveValue, string exceptionGroupBoxName)
        {
            foreach(Control control in this.Controls)
            {
                GroupBox groupBox = control as GroupBox;

                if(groupBox == null)
                {
                    continue;
                }

                if(groupBox.Name == exceptionGroupBoxName)
                {
                    continue;
                }

                groupBox.Location = new Point(groupBox.Location.X, groupBox.Location.Y + moveValue);
            }
        }

        private void CreatePictureBoxControl(Hero hero, Control groupBox, Point location)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = hero.Name;
            pictureBox.Tag = hero;
            pictureBox.Location = location;
            pictureBox.Size = new Size(_createControl.PictureBoxWidth, _createControl.PictureBoxHeight);
            pictureBox.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\{"HeroesIcons"}\\{hero.Name}.png");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            new ToolTip().SetToolTip(pictureBox, hero.Name);

            pictureBox.Click += RemoveHero;

            groupBox.Controls.Add(pictureBox);
        }

        private Hero FindHero(string heroName)
        {
            foreach(Hero hero in _createControl.Heroes)
            {
                if(hero.Name == heroName)
                {
                    return hero;
                }
            }

            return null;
        }

        private void AddEvents()
        {
            foreach (Control control in this.Controls)
            {
                GroupBox groupBox = control as GroupBox;

                if (groupBox == null)
                {
                    continue;
                }

                if (groupBox.Name == groupBoxResultName)
                {
                    continue;
                }
                
                foreach(Control pictureBox in groupBox.Controls)
                {
                    pictureBox.Click += HeroAddClick;
                }
            }
        }

        private void HeroAddClick(object sender, EventArgs eventArgs)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Hero hero = (Hero)pictureBox.Tag;
            AddHero(hero.Name, FindResultGroupBox());
        }

        private Control FindResultGroupBox()
        {
            foreach (Control control in this.Controls)
            {
                GroupBox groupBox = control as GroupBox;

                if (groupBox == null)
                {
                    continue;
                }

                if (groupBox.Name == groupBoxResultName)
                {
                    return groupBox;
                }
            }

            return null;
        }

        private void RemoveHero(object sender, EventArgs eventArgs)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Hero hero = (Hero)pictureBox.Tag;

            Result.RemoveAt(Result.FindIndex(x => x == hero.Name));
            Control parent = pictureBox.Parent;
            parent.Controls.Remove(pictureBox);
        }

        private void uiBtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddHeroesToList_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
