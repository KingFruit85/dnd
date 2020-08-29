using System;

namespace Races
{
    public class RaceLists 
    {
        private string[] Races = {"dragonborn", "dwarf", "elf", "gnome", "half-elf", "half-orc", "halfling", "human", "tiefling"};

        public string GetRandomRace()
        {
            Random r = new Random();
            int i = r.Next(0,Races.Length);
            return Races[i];
        }

    }
}