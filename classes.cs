using System;

namespace CharacterClasses
{
    public class CharacterClassList
    {
        private string[] CharacterClasses = {"bard", "barbarian", "cleric", "fighter", "monk", "paladin", "ranger",
                                             "rogue", "sorcerer", "warlock", "wizard", "druid"};

        public string GetRandomClass()
        {
            Random r = new Random();
            int i = r.Next(0,CharacterClasses.Length);
            return CharacterClasses[i];
        }
    }
}