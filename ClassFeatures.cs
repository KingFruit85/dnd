using System;
using System.Collections.Generic;

namespace Character
{
    [Serializable]
    public class ClassFeatures
    {
        public string Name {get;set;}
        public int HitPoints {get;set;}
        public int ProficiencyBonus {get;set;}
        
        public Dictionary<string,string[]> Proficiencies{get;set;}
        public List<string> Equipment{get;set;} = new List<string>();
        public Dictionary<string,string> Spells{get;set;}
        public Dictionary<string,string> Features{get;set;}
        public List<string> Tools {get;set;}

        public void SetName(string name){Name = name;} 
        public string GetName(){return Name;}
        public void SetHitPoints(int hitpoints){HitPoints = hitpoints;}
        public int GetHitPoints(){return HitPoints;}
        public void SetProficiencyBonus(int pb){ProficiencyBonus = pb;}
        public int GetProficiencyBonus(){return ProficiencyBonus;}

        public void SetProficiencies(Dictionary<string,string[]> profs)
        {
            Proficiencies = profs;
        }
        public Dictionary<string,string[]> GetProficiencies()
        {
            return Proficiencies;
        }
        
        /// <summary>Add a specific instument to the equipment collection</summary>
        /// <param name="instrument">the instrument to add as a string</param>
        public void AddMusicalinstrumentToEquipment(string instrument)
        {
            Equipment.Add(instrument);
        }

        

        
        /// <summary>Add a random instument to the equipment collection</summary>
        public void AddMusicalinstrumentToEquipment()
        {
            List<string> avalibleInstruments = new List<string>()
            {
                "Bagpipes",
                "Drum",
                "Dulcimer",
                "Flute",
                "Lute",
                "Lyre",
                "Horn",
                "Pan Flute",
                "Shawm",
                "Viol"
            };
            // Get random instrument from list above
            Random r = new Random();
            var instrument = avalibleInstruments[r.Next(0,avalibleInstruments.Count)];

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
            var bardProfs = new Dictionary<string,string[]>()
            {
                {"Armor", new string[]{"Light Armor"}},
                {"Weapons",new string[]{"Simple weapons", "hand crossbows", "longswords", "rapiers", "shortswords"}},
                {"Tools", new string[]{}},
                {"Saving Throws", new string[]{"Dexterity", "Charisma"}},
                {"Skills", new string[]{}}
            
            };
            SetProficiencies(bardProfs);
            AddMusicalinstrumentToEquipment();

        }

    } 
    
}