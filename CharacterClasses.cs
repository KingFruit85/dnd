using System;

namespace CharacterClasses
{
    public class CharacterClassList
    {
        // private string[] CharacterClasses = {"Bard", "Barbarian", "Cleric", "Fighter", "Monk", "Paladin", "Ranger",
        //                                      "Rogue", "Sorcerer", "Warlock", "Wizard", "Druid"};

        // DONE List :- Bard | Barbarian |

        public string GetRandomClass()
        {
            // int i = new Random().Next(0,CharacterClasses.Length);
            // return CharacterClasses[i];

            return "Cleric";
        }
    }
}