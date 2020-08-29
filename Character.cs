using System;
using Names;
using Races;

namespace Character
{
    public class CharacterTemplate
    {
        public string Race;
        public string FirstName;
        public string LastName;
        public string CharacterClass;
        public int Level = 1;
    }

    public class ManualCharacter : CharacterTemplate
    {
        
        public void SetRace(string race)
        {
            this.Race = race;
        }

        public void SetName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

        }

    }

    public class RandomCharacter : CharacterTemplate
    {
        public void SetRandomRace()
        {
            var Race = new RaceLists();
            string race = Race.GetRandomRace();
            this.Race = race;
        }

        public void SetRandomName()
        {
            NameLists name = new NameLists();
            string[] FullName = name.GetRandomName();
            this.FirstName = FullName[0];
            this.LastName = FullName[1];
        }

        public void SetRandomClass()
        {
            
        }

        public void Randomise()
        {
            this.SetRandomRace();
            this.SetRandomName();
        }


    }
}