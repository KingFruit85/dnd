using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class ClassFeatures
    {
        public string Name {get;set;}
        public int HitPoints {get;set;}
        public int ProficiencyBonus {get;set;}
        
        public Dictionary<string,List<string>> Proficiencies{get;set;}
        public List<Equipment> Equipment{get;set;} = new List<Equipment>();
        public Dictionary<string,string> Spells{get;set;}
        public Dictionary<string,string> Features{get;set;}
        public List<string> Tools {get;set;}

        public List<string> Skills = new List<string>()
        {
            "athletics",
            "acrobatics",
            "sleightOfHand",
            "arcana",
            "stealth",
            "history",
            "nature",
            "religion",
            "animalHandling",
            "insight",
            "medicine",
            "perception",
            "survival",
            "deception",
            "intimidation",
            "investigation",
            "performance",
            "persuasion"
        };

        public void SetName(string name){Name = name;} 
        public string GetName(){return Name;}
        public void SetHitPoints(int hitpoints){HitPoints = hitpoints;}
        public int GetHitPoints(){return HitPoints;}
        public void SetProficiencyBonus(int pb){ProficiencyBonus = pb;}
        public int GetProficiencyBonus(){return ProficiencyBonus;}

        public void SetProficiencies(Dictionary<string,List<string>> profs)
        {
            Proficiencies = profs;
        }
        public Dictionary<string,List<string>> GetProficiencies()
        {
            return Proficiencies;
        }
        
        // /// <summary>Add a specific instument to the equipment collection</summary>
        // /// <param name="instrument">the instrument to add as a string</param>
        // public void AddMusicalinstrumentToEquipment(string instrument)
        // {
        //     Equipment.Add(instrument);
        // }

        
        /// <summary>Add a random instument to the equipment collection</summary>
        public void AddMusicalinstrumentToEquipment()
        {
            var instrumentList = new Equipment().MusicalInstrument().MusicalInstruments;
            
            // Get random instrument from list above
            Random r = new Random();
            var instrument = instrumentList[r.Next(0,instrumentList.Count)];

            // Add it to equipment
            Equipment.Add(instrument);
        }

        public void SetTools(List<string> tools){Tools = tools;}
        public List<string> GetTools(){return Tools;}
        

    }
    public class Bard : ClassFeatures
    {
        public Bard()
        {
            SetName("Bard");
            SetProficiencyBonus(2);

            // Propulate Proficiencies
            var bardProfs = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){"Light Armor"}},
                {"Weapons",new List<string>(){"Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Dexterity", "Charisma"}},
                {"Skills", new List<string>(){}}
            
            };

            // Get 3 random instrument profs
            var instrumentList = new Equipment().MusicalInstrument().MusicalInstruments;
            Random r = new Random();
            var randomizedInstrumentList = instrumentList.OrderBy(i => r.Next()).ToArray();
            bardProfs["Tools"].Add(randomizedInstrumentList[0].Name);
            bardProfs["Tools"].Add(randomizedInstrumentList[1].Name);
            bardProfs["Tools"].Add(randomizedInstrumentList[2].Name);

            // Get 3 ransom skill profs
            var randomizedSkillList = Utils.Tools.ShuffleList(Skills);
            bardProfs["Skills"].Add(randomizedSkillList[0]);
            bardProfs["Skills"].Add(randomizedSkillList[1]);
            bardProfs["Skills"].Add(randomizedSkillList[2]);

            SetProficiencies(bardProfs);
            AddMusicalinstrumentToEquipment();

            // Add weapons //

            // All bards get a dagger
            var dagger = new Equipment().Weapons().SimpleWeapons.Where(w => w.Name == "Dagger").ToList()[0];
            Equipment.Add(dagger);

            // They also get either a Rapier, Longsword or a any simple weapon
            var option = r.Next(1,3);

            switch (option)
            {
                default: throw new Exception("option no valid");
                case 1:
                    
                    var rapier = new Equipment().Weapons().MartialMeleeWeapons.Where(w => w.Name == "Rapier").ToList()[0];
                    Equipment.Add(rapier);
                    break;

                case 2:

                    var Longsword = new Equipment().Weapons().MartialMeleeWeapons.Where(w => w.Name == "Longsword").ToList()[0];
                    Equipment.Add(Longsword);
                    break;

                case 3:
                    
                    var randomSimpleWeapon = new Equipment().Weapons().SimpleWeapons.ToList();
                    randomSimpleWeapon = Utils.Tools.ShuffleList(randomSimpleWeapon);
                    Equipment.Add(randomSimpleWeapon[0]);

                    break;
            }



        }

    } 
    
}