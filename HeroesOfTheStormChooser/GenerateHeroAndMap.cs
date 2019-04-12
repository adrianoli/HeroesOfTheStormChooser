using HeroesOfTheStormChooser.Configuration;
using HeroesOfTheStormChooser.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HeroesOfTheStormChooser
{
    public class GenerateHeroAndMap
    {
        private int _marginHeight;
        private int _marginWidth;
        private int _pictureBoxWidth;
        private int _pictureBoxHeight;

        private Control _lastGroupBox;
        private Control _mainForm;

        private string _groupBoxMapsName;
        private string _groupBoxToDelete;

        private List<string> _maps;
        private List<Hero> _heroes;
        private object _jsonObject;

        private List<PictureBox> _allyPictureBoxes;
        PictureBox _mapPictureBox;
        private List<PictureBox> _oponentsPictureBoxes;

        public GenerateHeroAndMap(Control lastGroupBox, Control mainForm, List<PictureBox> ally, PictureBox map, List<PictureBox> opponents)
        {
            _marginHeight = 16;
            _marginWidth = 5;
            _pictureBoxWidth = 63;
            _pictureBoxHeight = 59;

            _heroes = new List<Hero>();

            _groupBoxMapsName = "Maps";
            _groupBoxToDelete = "ToDelete";

            _lastGroupBox = lastGroupBox;
            _mainForm = mainForm;
            _allyPictureBoxes = ally;
            _mapPictureBox = map;
            _oponentsPictureBoxes = opponents;
        }

        public void Initialize()
        {
            LoadMapsJson();
            _heroes = JsonManager.LoadHeroesJson();

            CreateControls();          
        }

        public void InitializeHeroConfiguration()
        {
            _heroes = JsonManager.LoadHeroesJson();
            _jsonObject = JsonManager.LoadJsonFile("Heroes.json");
            CreateControlsForConfiguration();
        }

        public void ResizeControl()
        {
            RemoveControls();
            CreateControls();
        }

        private void LoadMapsJson()
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "Maps.json";

            string json = File.ReadAllText($"{path}\\Assets\\{fileName}");
            dynamic jsonObjects = JsonConvert.DeserializeObject(json);

            _maps = jsonObjects.ToObject<List<string>>();
        }

        private void CreateControls()
        {
            int groupBoxWidth = CreateControlClass.GetMainFormWidth(_mainForm, _marginHeight);
            int horizontalAmount = CreateControlClass.GetHorizontalAmount(groupBoxWidth, _pictureBoxWidth + _marginWidth);
            int verticalAmount = (int)Math.Ceiling((double)_maps.Count / (double)horizontalAmount);

            Control mapsGroupBox = CreateGroupBoxControl(_lastGroupBox, _mainForm, _groupBoxMapsName, "Wybór mapy", verticalAmount);
            _mainForm.Controls.Add(mapsGroupBox);
            CreateMapControl(mapsGroupBox, horizontalAmount);

            var groupedHeroRoleList = _heroes.GroupBy(u => u.Role).Select(grp => grp.ToList()).ToList();
            Control heroesGroupBox = mapsGroupBox;

            foreach (var groupRole in groupedHeroRoleList)
            {
                verticalAmount = (int)Math.Ceiling((double)groupRole.Count / (double)horizontalAmount);
                Hero hero = groupRole[0];
                heroesGroupBox = CreateGroupBoxControl(heroesGroupBox, _mainForm, hero.Role.ToString(), $"Wybór bohaterów dla: {hero.Role.ToString()}", verticalAmount);
                heroesGroupBox.ForeColor = CreateControlClass.GetColorForRole(hero.Role);
                _mainForm.Controls.Add(heroesGroupBox);
                CreateHeroControl(heroesGroupBox, horizontalAmount, groupRole, false);
            }
        }

        private void CreateControlsForConfiguration()
        {
            int groupBoxWidth = CreateControlClass.GetMainFormWidth(_mainForm, _marginHeight);
            int horizontalAmount = CreateControlClass.GetHorizontalAmount(groupBoxWidth, _pictureBoxWidth + _marginWidth);
            int verticalAmount = 0;

            var groupedHeroRoleList = _heroes.GroupBy(u => u.Role).Select(grp => grp.ToList()).ToList();

            Control newControl = new Control()
            {
                Location = new Point(0, 0),
                Size = new Size(5, 5)
            };

            Control heroesGroupBox = newControl;

            foreach (var groupRole in groupedHeroRoleList)
            {
                verticalAmount = (int)Math.Ceiling((double)groupRole.Count / (double)horizontalAmount);
                Hero hero = groupRole[0];
                heroesGroupBox = CreateGroupBoxControl(heroesGroupBox, _mainForm, hero.Role.ToString(), $"Wybór bohaterów dla: {hero.Role.ToString()}", verticalAmount);
                heroesGroupBox.ForeColor = CreateControlClass.GetColorForRole(hero.Role);
                _mainForm.Controls.Add(heroesGroupBox);
                CreateHeroControl(heroesGroupBox, horizontalAmount, groupRole, true);
            }
        }

        private Control CreateGroupBoxControl(Control lastControl, Control mainForm, string name, string text, int amountVertical)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Name = name;
            groupBox.Text = text;
            groupBox.Location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + _marginHeight);
            groupBox.Size = new Size(CreateControlClass.GetMainFormWidth(mainForm, _marginHeight), amountVertical * (_marginHeight + _pictureBoxHeight));         
            groupBox.Tag = _groupBoxToDelete;

            return groupBox;
        }

        private void CreateMapControl(Control mapsGroupBox, int horizontalAmount)
        {
            int actualHeight = _marginHeight;
            int actualWidth = _marginWidth;

            int counter = 0;

            foreach(var map in _maps)
            {
                counter++;
                
                if(counter % horizontalAmount == 0)
                {
                    actualHeight = actualHeight + _pictureBoxHeight + _marginHeight;
                    actualWidth = _marginWidth;
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = map;
                pictureBox.Tag = map;
                pictureBox.Location = new Point(actualWidth, actualHeight);
                pictureBox.Size = new Size(_pictureBoxWidth, _pictureBoxHeight);
                pictureBox.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\{"Assets\\MapsIcons"}\\{map}.jpg");
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                new ToolTip().SetToolTip(pictureBox, map);
                pictureBox.Click += MapClick;

                mapsGroupBox.Controls.Add(pictureBox);

                actualWidth = actualWidth + _marginWidth + _pictureBoxWidth;
            }
        }

        private void CreateHeroControl(Control heroGroupBox, int horizontalAmount, List<Hero> heroes, bool isConfiguration)
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

                if(isConfiguration)
                {
                    pictureBox.MouseClick += HeroMousClickForConfiguration;
                }
                else
                {
                    pictureBox.MouseClick += HeroMouseClick;
                }               

                heroGroupBox.Controls.Add(pictureBox);

                actualWidth = actualWidth + _marginWidth + _pictureBoxWidth;

                counter++;
            }
        }

        private void RemoveControls()
        {
            for(int i = _mainForm.Controls.Count - 1; i >= 0; i--)
            {
                var control = _mainForm.Controls[i];
                if(control?.Tag?.ToString() == _groupBoxToDelete)
                {
                    _mainForm.Controls.RemoveAt(i);
                }
            }
        }

        private void MapClick(object sender, EventArgs eventArgs)
        {
            if(_mapPictureBox.Image != null)
            {
                _mapPictureBox.Image = null;
            }

            PictureBox pictureBox = (PictureBox)sender;

            _mapPictureBox.Image = pictureBox.Image;
            _mapPictureBox.Tag = pictureBox.Tag;
        }

        private void HeroMouseClick(object sender,  MouseEventArgs mouseEventArgs)
        {
            bool isAlly = false;

            if(mouseEventArgs.Button == MouseButtons.Left)
            {
                isAlly = true;
            }

            PictureBox pictureBox = (PictureBox)sender;
            Hero hero = (Hero)pictureBox.Tag;

            if(IsHeroInList(hero.Name))
            {
                return;
            }

            if(isAlly)
            {
                foreach(var ally in _allyPictureBoxes)
                {
                    if(ally.Tag == null)
                    {
                        ally.Image = pictureBox.Image;
                        ally.Tag = hero;
                        break;
                    }
                }
            }
            else
            {
                foreach (var opponent in _oponentsPictureBoxes)
                {
                    if (opponent.Tag == null)
                    {
                        opponent.Image = pictureBox.Image;
                        opponent.Tag = hero;
                        break;
                    }
                }
            }
        }

        private bool IsHeroInList(string name)
        {
            foreach(var ally in _allyPictureBoxes)
            {
                Hero hero = ally.Tag as Hero;

                if(hero != null && hero.Name == name)
                {
                    return true;
                }
            }

            foreach (var opponent in _oponentsPictureBoxes)
            {
                Hero hero = opponent.Tag as Hero;

                if (hero != null && hero.Name == name)
                {
                    return true;
                }
            }


            return false;
        }

        public void ResetPoints()
        {
            foreach(var hero in _heroes)
            {
                hero.Points = 0;
            }
        }

        public void Analyze(List<Hero> ally, List<Hero> opponents, string map)
        {
            Analyzer analyzer = new Analyzer(_heroes);
            List<List<Hero>> sortedHeroes = analyzer.Analyze(ally, opponents, map);

            if(sortedHeroes == null)
            {
                return;
            }

            using (var result = new ResultShow(sortedHeroes))
            {
                result.ShowDialog();
            }
        }  
        
        private void HeroMousClickForConfiguration(object sender, MouseEventArgs mouseEventArgs)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Hero hero = (Hero)pictureBox.Tag;

            using (var heroConfiguration = new HeroConfiguration(hero))
            {
                heroConfiguration.ShowDialog();
                pictureBox.Tag = heroConfiguration.HeroObj;
            }
        }

    }
}
