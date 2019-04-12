using System.Collections.Generic;
using System.Linq;

namespace HeroesOfTheStormChooser
{
    public class Analyzer
    {
        private List<Hero> _heroes;

        public Analyzer(List<Hero> heroes)
        {
            _heroes = heroes;
        }


        public List<List<Hero>> Analyze(List<Hero> ally, List<Hero> opponents, string map)
        {
            foreach (var hero in _heroes)
            {
                if(IsSkipHero(ally, opponents, hero))
                {
                    continue;
                }

                AddHeroPoints(hero, ally, opponents, map);
            }

            List<List<Hero>> groupedHeroList = GetGroupedHeroList();

            if (groupedHeroList.Count == 0)
            {
                return null;
            }

            return SortedHeroList(ref groupedHeroList);
        }

        private bool IsSkipHero(List<Hero> ally, List<Hero> opponents, Hero hero)
        {
            if (ally.Any(x => x.Name.ToUpper() == hero.Name.ToUpper()) ||
                   opponents.Any(x => x.Name.ToUpper() == hero.Name.ToUpper()))
            {
                return true;
            }

            CorrectTemplate correctTemplate = new CorrectTemplate(ally);
            return !correctTemplate.IsInTemplate(hero);
        }

        private void AddHeroPoints(Hero hero, List<Hero> ally, List<Hero> opponents, string map)
        {
            foreach (var friend in ally)
            {
                if (hero.Synergizes.Any(x => x.ToUpper() == friend.Name.ToUpper()))
                {
                    hero.Points++;
                }
            }

            foreach (var opponent in opponents)
            {
                if (hero.Counters.Any(x => x.ToUpper() == opponent.Name.ToUpper()))
                {
                    hero.Points = hero.Points - 2;
                }
            }

            foreach (var opponent in opponents)
            {
                if (opponent.Counters.Any(x => x.ToUpper() == hero.Name.ToUpper()))
                {
                    hero.Points = hero.Points + 2;
                }
            }

            foreach (var opponent in opponents)
            {
                if (hero.Strongs.Any(x => x.ToUpper() == opponent.Name.ToUpper()))
                {
                    hero.Points = hero.Points++;
                }
            }

            if (hero.GoodMaps.Any(x => x.ToUpper() == map.ToUpper()))
            {
                hero.Points++;
            }

            if (hero.WeakMaps.Any(x => x.ToUpper() == map.ToUpper()))
            {
                hero.Points--;
            }
        }

        private List<List<Hero>> GetGroupedHeroList()
        {
            var groupedHeroList = _heroes.GroupBy(u => u.Points).Select(grp => grp.ToList()).ToList();
            List<List<Hero>> heroList = new List<List<Hero>>();

            foreach (var heroes in groupedHeroList)
            {
                Hero hero = heroes[0];

                if (hero.Points > 0)
                {
                    heroList.Add(heroes);
                }
            }

            return heroList;
        }

        private List<List<Hero>> SortedHeroList(ref List<List<Hero>> groupedHeroList)
        {
            List<List<Hero>> sortedHeroes = new List<List<Hero>>();
            List<Hero> morePointsHeroes = null;

            do
            {
                morePointsHeroes = TakeTheMorePoints(ref groupedHeroList);

                if (morePointsHeroes != null)
                {
                    sortedHeroes.Add(morePointsHeroes);
                }

            } while (morePointsHeroes != null);

            return sortedHeroes;
        }

        private List<Hero> TakeTheMorePoints(ref List<List<Hero>> heroes)
        {
            List<Hero> heroList = null;
            int theBiggestValue = 0;
            int indexToTake = -1;

            for (int i = 0; i < heroes.Count; i++)
            {
                Hero hero = heroes[i][0];

                if (hero.Points > theBiggestValue)
                {
                    theBiggestValue = hero.Points;
                    indexToTake = i;
                }
            }

            if (indexToTake > -1)
            {
                heroList = heroes[indexToTake];
                heroes.RemoveAt(indexToTake);
            }

            return heroList;
        }
    }
}
