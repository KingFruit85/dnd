using System;
using System.Collections.Generic;

namespace Races
{
    public class GenericRace
    {
        public string Name;
        private Dictionary<string,int> AbilityScoreIncrease = new Dictionary<string, int>();
        private int Age {get; set;}
        public string Alignment {get; private set;}
        private string Size {get; set;}
        private int Speed {get; set;}
        private List<string> Languages = new List<string>();
        private string SubRace {get; set;}

        public void SetAbilityScoreIncrease(string attribute, int modifier)
        {
            this.AbilityScoreIncrease.Add(attribute, modifier);
        }

        public void SetAge(int age)
        {
            if (age == 0)
            {
                throw new Exception("Age cannot be 0!");
            }
            else
            {
                Age = age;
            }
            
        }

        public void SetAlignment()
        {
            var Alignments = new string[]{"Lawful Good", 
                              "Neutral Good",
                              "Chaotic Good",
                              "Lawful Neutral",
                              "True Neutral",
                              "Chaotic Neutral",
                              "Lawful Evil",
                              "Neutral Evil",
                              "Chaotic Evil"};

            Alignment = Tools.GetRandomStringArrayElement(Alignments);
        }

        public void SetSize(string size)
        {
            Size = size;
        }

        public void SetSpeed(int speed)
        {
            Speed = speed;
        }

        public List<string> GetLanguages()
        {
            return Languages;
        }

        public void AddLangugage(string lang)
        {
            if (this.Languages.Contains(lang))
            {
                throw new Exception($"Character already knows {lang}");
            }
            else
            {
                this.Languages.Add(lang);
            }
        }

        public void AddLangugage(int count = 1)
        {
            // Initialise standard languages
            var StandardLanguages = new List<string>{"Common","Dwarvish","Elvish","Giant","Gnomish","Goblin","Halfling","Orc"};
            // Select a random language    
            var Pick = Tools.GetRandomStringListElement(StandardLanguages);
                // Loop through arguement count
                for(var i = 0; i< count; i++)
                {
                // Check if character already knows random pick
                var AlreadyPresent = this.Languages.Contains(Pick);

                if(AlreadyPresent == true) 
                {
                    Pick = Tools.GetRandomStringListElement(StandardLanguages);
                    i--;
                }
                else
                {
                    this.Languages.Add(Pick);
                }

                }
  

        }


    }

    public class Human : GenericRace
    {
        public Human()
        {
        Name = "Human";
        // Humans reach adulthood in their late teens and live less than a century.
        SetAge(Tools.GetRandomNumberInRange(18,65));
        // Human ability scores each increase by 1.
        SetAbilityScoreIncrease("STR", 1);
        SetAbilityScoreIncrease("DEX", 1);
        SetAbilityScoreIncrease("CON", 1);
        SetAbilityScoreIncrease("INT", 1);
        SetAbilityScoreIncrease("CHA", 1);
        SetAbilityScoreIncrease("WIS", 1);
        // Humans tend toward no particular alignment. The best and the worst are found among them.
        SetAlignment();
        // Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. 
        // Regardless of your position in that range, your size is Medium.
        SetSize("Medium");
        // Human base walking speed is 30 feet.
        SetSpeed(30);
        // Humans know Common by default
        AddLangugage("Common");
        // Humans also know one additional language other than common
        AddLangugage(1);
        }
    }

    public class Dragonborn : GenericRace
    {
        

    }

    public class Dwarf : GenericRace
    {
        public Dwarf()
        {
            // Dwarves considered young until they reach the age of 50. On average, they live about 350 years.
            SetAge(Tools.GetRandomNumberInRange(50,330));
            // Dwarves Constitution score increases by 2.
            SetAbilityScoreIncrease("CON", 2);
            SetAlignment();
            SetSize("Medium");
        }
    }

    public class Elf : GenericRace
    {
        

    }

    public class Gnome : GenericRace
    {
        

    }

    public class HalfElf : GenericRace
    {
        

    }

    public class HalfOrc : GenericRace
    {
        

    }

    public class Halfling : GenericRace
    {
        

    }

    public class Tiefling : GenericRace
    {
        

    }

        public class RaceLists 
    {
        private string[] Races = {"Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling"};

        public GenericRace GetRandomRace()
        {
            return new Human();
        }

    }
}