using HeroesOfTheStormChooser.Configuration.Logic;
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
        Hero _hero;
        dynamic _jsonObject;

        public HeroConfiguration()
        {
            InitializeComponent();
        }

        public HeroConfiguration(Hero hero, object jsonObject) : this()
        {
            _heroConfigurationLogic = new HeroConfigurationLogic(hero, jsonObject);
            _hero = hero;
            _jsonObject = jsonObject;

            Initialize();
        }

        private void Initialize()
        {
            uiPbPhoto.Image = _heroConfigurationLogic.GetHeroImage();
            uiTxtName.Text = _heroConfigurationLogic.GetHeroName();
        }

        private void uiBtnSynergizes_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            foreach (var jsonObj in _jsonObject)
            {
                if (jsonObj.Name == _hero.Name)
                {
                    List<string> jsonSynergizes = JsonManager.GetDataListFromJson(jsonObj.Synergizes.ToString());
                    using (var addHeroToList = new AddHeroesToList(control.Text, _hero.Name, jsonSynergizes))
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
                if (jsonObj.Name == _hero.Name)
                {
                    List<string> jsonStrongs = JsonManager.GetDataListFromJson(jsonObj.Strongs.ToString());
                    using (var addHeroToList = new AddHeroesToList(control.Text, _hero.Name, jsonStrongs))
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
                if (jsonObj.Name == _hero.Name)
                {
                    List<string> jsonCounters = JsonManager.GetDataListFromJson(jsonObj.Counters.ToString());
                    using (var addHeroToList = new AddHeroesToList(control.Text, _hero.Name, jsonCounters))
                    {
                        if (addHeroToList.ShowDialog() == DialogResult.OK)
                        {
                            jsonObj.Counters = JsonConvert.SerializeObject(addHeroToList.Result);
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
            string path = Directory.GetCurrentDirectory();
            string fileName = "Heroes.json";
            string filePath = $"{path}\\{fileName}";

            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                streamWriter.Write(_jsonObject);
            }

            Close();
        }
    }
}
