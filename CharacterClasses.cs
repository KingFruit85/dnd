using System;

namespace CharacterClasses
{
    public class CharacterClassList
    {
        // private string[] CharacterClasses = {"Bard", "Barbarian", "Cleric", "Fighter", "Monk", "Paladin", "Ranger",
        //                                      "Rogue", "Sorcerer", "Warlock", "Wizard", "Druid"};

        private string[] CharacterClasses = {"Bard"};

        public string GetRandomClass()
        {
            int i = new Random().Next(0,CharacterClasses.Length);
            return CharacterClasses[i];
        }
    }
}