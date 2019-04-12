using HeroesOfTheStormChooser.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeroesOfTheStormChooser
{
    public class JsonManager
    {
        public static List<Hero> LoadHeroesJson()
        {
            List<Hero> heroes = new List<Hero>();
            string path = Directory.GetCurrentDirectory();
            string fileName = "Heroes.json";

            string json = File.ReadAllText($"{path}\\{fileName}");
            dynamic jsonObjects = JsonConvert.DeserializeObject(json);

            foreach (var jsonObj in jsonObjects)
            {
                Hero hero = new Hero(jsonObj.Name.ToString());
                hero.AttackType = Enum.Parse(typeof(eAttackType), jsonObj.AttackType.ToString());
                hero.Role = Enum.Parse(typeof(eRole), jsonObj.Role.ToString());
                hero.Synergizes = GetDataListFromJson(jsonObj.Synergizes.ToString());
                hero.Strongs = GetDataListFromJson(jsonObj.Strongs.ToString()); 
                hero.Counters = GetDataListFromJson(jsonObj.Counters.ToString());
                hero.GoodMaps = GetDataListFromJson(jsonObj.GoodMaps.ToString());
                hero.WeakMaps = GetDataListFromJson(jsonObj.WeakMaps.ToString());
                hero.CrowdControls = GetDataListFromJson(jsonObj.CrowdControl.ToString());

                heroes.Add(hero);
            }

            return heroes;
        }

        public static List<string> GetDataListFromJson(string jsonData)
        {
            List<string> data = new List<string>();
            string pattern = "\"[\\w ]*\"";
            Regex r = new Regex(pattern);
            MatchCollection mc = r.Matches(jsonData);
            foreach (Match m in mc)
            {
                data.Add(m.Value.Substring(1, m.Value.Length - 2));
            }

            return data;
        }

        public static object LoadJsonFile(string pfileName)
        {
            List<Hero> heroes = new List<Hero>();
            string path = Directory.GetCurrentDirectory();
            string fileName = pfileName;

            string json = File.ReadAllText($"{path}\\{fileName}");
            object jsonObjects = JsonConvert.DeserializeObject(json);

            return jsonObjects;
        }
    }
}
