using System;

namespace CharacterClasses
{
    public class CharacterClassList
    {
        private string[] CharacterClasses = {"Bard", "Barbarian", "Cleric", "Fighter", "Monk", "Paladin", "Ranger",
                                             "Rogue", "Sorcerer", "Warlock", "Wizard", "Druid"};

        public string GetRandomClass()
        {
            Random r = new Random();
            int i = r.Next(0,CharacterClasses.Length);
            return CharacterClasses[i];
        }
    }
}