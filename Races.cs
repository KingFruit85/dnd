using System;
using System.Collections.Generic;

namespace Races
{
    public class GenericRace
    {
        private string Name;
        private Dictionary<string,int> AbilityScoreIncrease = new Dictionary<string, int>();
        private int Age {get; set;}
        private string Alignment {get; set;}
        private string Size {get; set;}
        private int Speed {get; set;}
        private List<string> Languages = new List<string>();
        private string SubRace {get; set;}
        private Dictionary<string,string> RacePerks = new Dictionary<string, string>();

        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public Dictionary<string,int> GetAbilityScoreIncrease()
        {
            return AbilityScoreIncrease;
        }
        public void SetAbilityScoreIncrease(string attribute, int modifier)
        {
            this.AbilityScoreIncrease.Add(attribute, modifier);
        }
        public int GetAge()
        {
            return Age;
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

        public string GetAlignment()
        {
            return Alignment;
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

        public string GetSize()
        {
            return Size;
        }
        public void SetSize(string size)
        {
            Size = size;
        }

        public int GetSpeed()
        {
            return Speed;
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

        public Dictionary<string,string> GetRacePerks()
        {
            return RacePerks;
        }
        public void AddRacePerk(string name, string description)
        {
            this.RacePerks.Add(name, description);
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

        public string getSubRace()
        {
            return SubRace;
        }

        public void SetSubRace(string subRace)
        {
            SubRace = subRace;
        }
    }

    public class Human : GenericRace
    {
        public Human()
        {
        SetName("Human");
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
        public struct DraconicAncestryDetails
        {
            public string DamageType;
            public string BreathWeapon;

        }

        public Dragonborn()
        {
            SetName("Dragonborn");

            AddRacePerk("Ability Score Increase", "Your Strength score increases by 2, and your Charisma score increases by 1.");
            SetAbilityScoreIncrease("STR", 2);
            SetAbilityScoreIncrease("CHA", 1);

            AddRacePerk("Age"," Young dragonborn grow quickly. They walk hours after hatching, attain the size and development of a 10-year-old human child by the age of 3, and reach adulthood by 15. They live to be around 80.");
            SetAge(Tools.GetRandomNumberInRange(15,80));

            AddRacePerk("Alignment","Dragonborn tend to extremes, making a conscious choice for one side or the other in the cosmic war between good and evil. Most dragonborn are good, but those who side with evil can be terrible villains.");
            SetAlignment();

            AddRacePerk("Size","Dragonborn are taller and heavier than humans, standing well over 6 feet tall and averaging almost 250 pounds. Your size is Medium.");
            SetSize("Medium");

            AddRacePerk("Speed","Your base walking speed is 30 feet.");
            SetSpeed(30);

            AddRacePerk("Draconic Ancestry","You have draconic ancestry. Choose one type of dragon from the Draconic Ancestry table. Your breath weapon and damage resistance are determined by the dragon type.");
            
            var DraconicAncestry = new Dictionary<string, DraconicAncestryDetails>()
            {
                {"Black", new DraconicAncestryDetails(){DamageType = "Acid", BreathWeapon = "5 by 30 ft. line (Dex. save)"}},
                {"Blue", new DraconicAncestryDetails(){DamageType = "Lightning", BreathWeapon = "5 by 30 ft. line (Dex. save)"}},
                {"Brass", new DraconicAncestryDetails(){DamageType = "Fire", BreathWeapon = "5 by 30 ft. line (Dex. save)"}},
                {"Bronze", new DraconicAncestryDetails(){DamageType = "Lightning", BreathWeapon = "5 by 30 ft. line (Dex. save)"}},
                {"Copper", new DraconicAncestryDetails(){DamageType = "Acid", BreathWeapon = "5 by 30 ft. line (Dex. save)"}},
                {"Gold", new DraconicAncestryDetails(){DamageType = "Fire", BreathWeapon = "15 ft. cone (Dex. save)"}},
                {"Green", new DraconicAncestryDetails(){DamageType = "Poison", BreathWeapon = "15 ft. cone (Dex. save)"}},
                {"Red", new DraconicAncestryDetails(){DamageType = "Fire", BreathWeapon = "15 ft. cone (Dex. save)"}},
                {"Silver", new DraconicAncestryDetails(){DamageType = "Cold", BreathWeapon = "15 ft. cone (Dex. save)"}},
                {"White", new DraconicAncestryDetails(){DamageType = "Cold", BreathWeapon = "15 ft. cone (Dex. save)"}}  
            };
            
            AddRacePerk("Breath Weapon","You can use your action to exhale destructive energy. Your draconic ancestry determines the size, shape, and damage type of the exhalation. When you use your breath weapon, each creature in the area of the exhalation must make a saving throw, the type of which is determined by your draconic ancestry. The DC for this saving throw equals 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increases to 3d6 at 6th level, 4d6 at 11th level, and 5d6 at 16th level. After you use your breath weapon, you can’t use it again until you complete a short or long rest.");
            AddRacePerk("Damage Resistance","You have resistance to the damage type associated with your draconic ancestry.");
            AddRacePerk("Languages","You can speak, read, and write Common and Draconic. Draconic is thought to be one of the oldest languages and is often used in the study of magic. The language sounds harsh to most other creatures and includes numerous hard consonants and sibilants.");
            AddLangugage("Common");
            AddLangugage("Draconic");
        }
        

    }

    public class Dwarf : GenericRace
    {
        public Dwarf()
        {

            SetName("Dwarf");

            AddRacePerk("Ability Score Increase", "Your Constitution score increases by 2.");
            SetAbilityScoreIncrease("CON", 2);

            AddRacePerk("Age", "Dwarves mature at the same rate as humans, but they’re considered young until they reach the age of 50. On average, they live about 350 years.");
            SetAge(Tools.GetRandomNumberInRange(50,350));

            AddRacePerk("Alignment","Most dwarves are lawful, believing firmly in the benefits of a well-­‐‑ordered society. They tend toward good as well, with a strong sense of fair play and a belief that everyone deserves to share in the benefits of a just order.");
            SetAlignment();

            AddRacePerk("Size", "Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium.");
            SetSize("Medium");

            AddRacePerk("Speed", "Your base walking speed is 25 feet. Your speed is not reduced by wearing heavy armor.");
            SetSpeed(25);

            AddRacePerk("Darkvision", "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can’t discern color in darkness, only shades of gray.");
            AddRacePerk("Dwarven Resilience","You have advantage on saving throws against poison, and you have resistance against poison damage.");
            AddRacePerk("Dwarven Combat Training","You have proficiency with the battleaxe, handaxe, light hammer, and warhammer.");
            AddRacePerk("Tool Proficiency", "You gain proficiency with the artisan’s tools of your choice: smith’s tools, brewer’s supplies, or mason’s tools.");
            AddRacePerk("Stonecunning","Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus.");
            AddRacePerk("Languages","You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds, and those characteristics spill over into whatever other language a dwarf might speak.");
            AddLangugage("Common");
            AddLangugage("Dwarvish");

            SetSubRace("Hill Dwarf");
            AddRacePerk("Ability Score Increase(Hill Dwarf)", "Your Wisdom score increases by 1.");
            SetAbilityScoreIncrease("WIS", 1);
            AddRacePerk("Dwarven Toughness", "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level.");
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
        public Halfling()
        {
            SetName("Halfling");

            AddRacePerk("Ability Score Increase", "Your Dexterity score increases by 2.");
            SetAbilityScoreIncrease("DEX",2);

            AddRacePerk("Age", "A halfling reaches adulthood at the age of 20 and generally lives into the middle of his or her second century.");
            SetAge(Tools.GetRandomNumberInRange(20,250));

            AddRacePerk("Alignment", "Most halflings are lawful good. As a rule, they are good-hearted and kind, hate to see others in pain, and have no tolerance for oppression. They are also very orderly and traditional, leaning heavily on the support of their community and the comfort of their old ways.");
            SetAlignment();

            AddRacePerk("Size", "Halflings average about 3 feet tall and weigh about 40 pounds. Your size is Small.");
            SetSize("Small");

            AddRacePerk("Speed", "Your base walking speed is 25 feet.");
            SetSpeed(25);

            AddRacePerk("Lucky", "When you roll a 1 on the d20 for an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll.");

            AddRacePerk("Brave", "You have advantage on saving throws against being frightened.");

            AddRacePerk("Halfling Nimbleness", "You can move through the space of any creature that is of a size larger than yours.");

            AddRacePerk("Languages","You can speak, read, and write Common and Halfling. The Halfling language isn’t secret, but halflings are loath to share it with others. They write very little, so they don’t have a rich body of literature. Their oral tradition, however, is very strong. Almost all halflings speak Common to converse with the people in whose lands they dwell or through which they are traveling.");
            AddLangugage("Common");
            AddLangugage("Halfling");

            SetSubRace("Lightfoot");
            AddRacePerk("Ability Score Increase (Lightfoot)", "Your Charisma score increases by 1.");
            SetAbilityScoreIncrease("CHA", 1);

            AddRacePerk("Naturally Stealthy", "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you.");
        }
        

    }

    public class Tiefling : GenericRace
    {
        

    }

        public class RaceLists 
    {
        // private string[] Races = {"Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling"};
        private GenericRace[] Races = {new Dwarf(), new Human(), new Halfling(), new Dragonborn()};
        public GenericRace GetRandomRace()
        {
            return Tools.GetRandomRaceArrayElement(Races);
        }

    }
}