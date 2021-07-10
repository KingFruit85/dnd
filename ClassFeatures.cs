using System;
using System.Collections.Generic;

namespace Character
{
    public class GenericCharacterClass
    {
        private List<Weapon> weaponList = new Equipment().ReturnWeaponList().weapon;
        private List<Armor> armorList = new Equipment().ReturnArmorList().Armor;
        private List<EquipmentPack> packList = new Equipment().EquipmentPacks().EquipmentPacks;

        public List<Weapon> GetWeapons()
        {
            return weaponList;
        }

        public List<Armor> GetArmor()
        {
            return armorList;
        }

        public List<EquipmentPack> GetPacks()
        {
            return packList;
        }


        public string Name {get;set;}
        public int ProficiencyBonus {get;set;}
        public string HitDie { set; get;}        
        public Dictionary<string,List<string>> Proficiencies{get;set;}
        public Armor Armor {get; set;} = new Armor();
        public Shield Shield {get; set;}
        public Weapon PrimaryWeapon {get; set;} = new Weapon();
        public List<Weapon> AdditionalWeapons { get; set; } = new List<Weapon>();
        public List<Ammunition> Ammunition { get; set; } = new List<Ammunition>();
        public List<MusicalInstrument> MusicalInstruments { get; set; } = new List<MusicalInstrument>();
        public EquipmentPack EquipmentPack { get; set; }
        public HolySymbol HolySymbol { get; set; }
        public List<Spells> Cantrips { get; set; } = new List<Spells>();
        public List<Spells> Level1Spells { get; set; } = new List<Spells>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public int SpellSlots = 0;

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
        
        /// <summary>Add a specific instument to the equipment collection</summary>
        /// <param name="instrument">the instrument to add as a string</param>
        public void AddMusicalinstrumentToEquipment(MusicalInstrument instrument)
        {
            MusicalInstruments.Add(instrument);
        }

        /// <summary>Add a random instument to the equipment collection</summary>
        public void AddRandomMusicalinstrumentToEquipment()
        {
            var instrumentList = new Equipment().MusicalInstrument().MusicalInstruments;
            // Get random instrument from list above and add it to character sheet
            Random r = new Random();
            MusicalInstruments.Add(instrumentList[r.Next(0,instrumentList.Count)]);
        }

        public GenericCharacterClass ReturnClassFeatures(string characterClass)
        {
            switch (characterClass)
            {
                default: throw new Exception("Invalid character class provided");
                case "Bard": return new Bard();
                case "Barbarian": return new Barbarian();
            }
        }
    }
}