using HeroesOfTheStormChooser.Enums;
using System.Collections.Generic;

namespace HeroesOfTheStormChooser
{
    public class CorrectTemplate
    {
        List<Hero> _ally;

        List<eRole> specialistsTemplate;
        List<eRole> assasinsTemplate;
        List<eRole> warriorTemplate;

        public CorrectTemplate(List<Hero> ally)
        {
            _ally = ally;

            specialistsTemplate = new List<eRole>
            {
                eRole.Warrior, eRole.Specialist, eRole.Support, eRole.Assasin, eRole.Assasin
            };

            assasinsTemplate = new List<eRole>
            {
                eRole.Warrior, eRole.Support, eRole.Assasin, eRole.Assasin, eRole.Assasin
            };

            warriorTemplate = new List<eRole>
            {
                eRole.Warrior, eRole.Warrior, eRole.Assasin, eRole.Assasin, eRole.Support
            };

        }


        public bool IsInTemplate(Hero hero)
        {
            if(CheckCorrectTemplate(specialistsTemplate, hero))
            {
                return true;
            }

            if(CheckCorrectTemplate(assasinsTemplate, hero))
            {
                return true;
            }

            if(CheckCorrectTemplate(warriorTemplate, hero))
            {
                return true;
            }

            return false;
        }

        private bool CheckCorrectTemplate(List<eRole> roles, Hero hero)
        {
            List<eRole> tempRoles = new List<eRole>();
            tempRoles.AddRange(roles);

            foreach(var ally in _ally)
            {
                for(int i = 0; i < tempRoles.Count; i++)
                {
                    if(ally.Role == tempRoles[i])
                    {
                        tempRoles.RemoveAt(i);
                        break;
                    }
                }
            }

            foreach(var ally in _ally)
            {
                for(int i = 0; i < tempRoles.Count; i++)
                {
                    if(ally.Role == eRole.Multiclass && (tempRoles[i] == eRole.Assasin || tempRoles[i] == eRole.Warrior))
                    {
                        tempRoles.RemoveAt(i);
                        break;
                    }
                }
            }

            if(_ally.Count == 4 && tempRoles.Count > 1)
            {
                bool isSupportRole = false;

                foreach(var role in tempRoles)
                {
                    if(role == eRole.Support)
                    {
                        isSupportRole = true;
                    }
                }

                if(isSupportRole)
                {
                    for(int i = tempRoles.Count - 1; i >= 0; i--)
                    {
                        if(tempRoles[i] != eRole.Support)
                        {
                            tempRoles.RemoveAt(i);
                        }
                    }
                }
            }

            foreach(var role in tempRoles)
            {
                if(role == hero.Role)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
