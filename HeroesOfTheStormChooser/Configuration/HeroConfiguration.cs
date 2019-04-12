using HeroesOfTheStormChooser.Configuration.Logic;
using HeroesOfTheStormChooser.Enums;
using Newtonsoft.Json;
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
    public partial class HeroConfiguration : Form
    {
        private HeroConfigurationLogic _heroConfigurationLogic;
        dynamic _jsonObject;

        public HeroConfiguration()
        {
            InitializeComponent();
        }

        public Hero HeroObj { get; private set; }

        public HeroConfiguration(object jsonObject) : this()
        {
            Hero hero = new Hero();

            _heroConfigurationLogic = new HeroConfigurationLogic(hero, jsonObject);
            HeroObj = hero;
            _jsonObject = jsonObject;

            Initialize();
            InitializeFormToAddMode();
        }

        public HeroConfiguration(Hero hero, object jsonObject) : this()
        {
            _heroConfigurationLogic = new HeroConfigurationLogic(hero, jsonObject);
            HeroObj = hero;
            _jsonObject = jsonObject;

            Initialize();
            InitializeFormToSaveMode();
        }

        private void Initialize()
        {
            uiCmbRole.Items.AddRange(typeof(eRole).GetEnumNames());
        }

        private void InitializeFormToSaveMode()
        {
            uiBtnAdd.Visible = false;
            uiLblPathPicture.Visible = false;
            uiTxtPathToPicture.Visible = false;
            uiBtnBrowse.Visible = false;

            uiTxtName.Enabled = false;

            for(int i = 0; i < uiCmbRole.Items.Count; i++)
            {
                if(uiCmbRole.Items[i].ToString().ToUpper() == HeroObj.Role.ToString().ToUpper())
                {
                    uiCmbRole.SelectedIndex = i;
                    break;
                }
            }
            
            uiPbPhoto.Image = _heroConfigurationLogic.GetHeroImage();
            uiTxtName.Text = _heroConfigurationLogic.GetHeroName();
        }

        private void InitializeFormToAddMode()
        {
            uiBtnSave.Visible = false;
            uiBtnCounters.Visible = false;
            uiBtnCrowdControl.Visible = false;
            uiBtnGoodMaps.Visible = false;
            uiBtnWeakMaps.Visible = false;
            uiBtnStrong.Visible = false;
            uiBtnSynergizes.Visible = false;

            uiCmbRole.SelectedIndex = 0;
        }

        private void uiBtnSynergizes_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            foreach (var jsonObj in _jsonObject)
            {
                if (jsonObj.Name == HeroObj.Name)
                {
                    List<string> jsonSynergizes = JsonManager.GetDataListFromJson(jsonObj.Synergizes.ToString());
                    using (var addHeroToList = new AddHeroesToList(control.Text, HeroObj.Name, jsonSynergizes))
                    {
                        if (addHeroToList.ShowDialog() == DialogResult.OK)
                        {
                            jsonObj.Synergizes = JsonConvert.SerializeObject(addHeroToList.Result);
                        }
                    }

                    break;
                }
            } 
        }

        private void uiBtnStrong_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            foreach (var jsonObj in _jsonObject)
            {
                if (jsonObj.Name == HeroObj.Name)
                {
                    List<string> jsonStrongs = JsonManager.GetDataListFromJson(jsonObj.Strongs.ToString());
                    using (var addHeroToList = new AddHeroesToList(control.Text, HeroObj.Name, jsonStrongs))
                    {
                        if (addHeroToList.ShowDialog() == DialogResult.OK)
                        {
                            jsonObj.Strongs = JsonConvert.SerializeObject(addHeroToList.Result);
                        }
                    }

                    break;
                }
            }
        }

        private void uiBtnCounters_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            foreach (var jsonObj in _jsonObject)
            {
                if (jsonObj.Name == HeroObj.Name)
                {
                    List<string> jsonCounters = JsonManager.GetDataListFromJson(jsonObj.Counters.ToString());
                    using (var addHeroToList = new AddHeroesToList(control.Text, HeroObj.Name, jsonCounters))
                    {
                        if (addHeroToList.ShowDialog() == DialogResult.OK)
                        {
                            HeroObj.Counters = addHeroToList.Result;
                        }
                    }

                    break;
                }
            }
        }

        private void uiBtnCrowdControl_Click(object sender, EventArgs e)
        {

        }

        private void uiBtnGoodMaps_Click(object sender, EventArgs e)
        {

        }

        private void uiBtnWeakMaps_Click(object sender, EventArgs e)
        {

        }



        private void uiBtnSave_Click(object sender, EventArgs e)
        {
            HeroObj.Role = (eRole)Enum.Parse(typeof(eRole), uiCmbRole.Items[uiCmbRole.SelectedIndex].ToString());

            string path = Directory.GetCurrentDirectory();
            string fileName = "Heroes.json";
            string filePath = $"{path}\\Assets\\{fileName}";

            List<Hero> heroes = JsonManager.LoadHeroesJson();

            for(int i = 0; i < heroes.Count; i++)
            {
                if(heroes[i].Name == HeroObj.Name)
                {
                    heroes[i] = HeroObj;
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                streamWriter.Write(JsonConvert.SerializeObject(heroes));
            }

            Close();
        }

        private void uiBtnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void uiBtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files(*.png)|*.png";
                open.Multiselect = false;
                open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (open.ShowDialog() == DialogResult.OK)
                {
                    var splitName = open.SafeFileName.Split('.');
                    string name = splitName[0];

                    if(name.ToUpper() != uiTxtName.Text.ToUpper())
                    {
                        MessageBox.Show("Nazwa zdjęcia musi się zgadzać z nazwą bohatera.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    uiTxtPathToPicture.Text = open.FileName;
                    uiPbPhoto.Image = Image.FromFile(open.FileName);
                }
            }
            
       }
    }
}
