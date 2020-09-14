using System;

namespace Races
{
    public class RaceLists 
    {
        private string[] Races = {"Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling"};

        public string GetRandomRace()
        {
            Random r = new Random();
            int i = r.Next(0,Races.Length);
            return Races[i];
        }

    }
}