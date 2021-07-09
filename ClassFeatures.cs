using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class ClassFeatures
    {
        public string Name {get;set;}
        public int ProficiencyBonus {get;set;}
        public string HitDie { set; get;}        
        public Dictionary<string,List<string>> Proficiencies{get;set;}
        public Armor Armor {get; set;} = new Armor();
        public Weapon PrimaryWeapon {get; set;} = new Weapon();
        public List<Weapon> AdditionalWeapons { get; set; } = new List<Weapon>();
        public List<MusicalInstrument> MusicalInstruments { get; set; } = new List<MusicalInstrument>();
        public EquipmentPack EquipmentPack { get; set; }

        public List<Spells> Cantrips { get; set; } = new List<Spells>();
        public List<Spells> Level1Spells { get; set; } = new List<Spells>();
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
        public void AddMusicalinstrumentToEquipment()
        {
            var instrumentList = new Equipment().MusicalInstrument().MusicalInstruments;
            // Get random instrument from list above and add it to character sheet
            Random r = new Random();
            MusicalInstruments.Add(instrumentList[r.Next(0,instrumentList.Count)]);
        }

        
    }
    public class Bard : ClassFeatures
    {
        public Bard()
        {
            SetName("Bard");
            SetProficiencyBonus(2);
            HitDie = "1d8";

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

            // All bards get a dagger and leather armor
            var dagger = new Equipment().ReturnWeaponList().weapon.Where(w => w.Name == "Dagger").ToList()[0];
            AdditionalWeapons.Add(dagger);

            Armor = new Equipment().ReturnArmorList().Armor.Where(a => a.Name == "Leather Armor").ToList()[0];

            // They also get either a Diplomat's pack or and entertainer's pack
            switch (r.Next(1,2))
            {
                default: throw new Exception("Option no valid");
                case 1:

                    EquipmentPack = new Equipment().EquipmentPacks().EquipmentPacks.Where(p => p.Name == "Diplomat's Pack").ToList()[0];
                    break;

                case 2:

                    EquipmentPack= new Equipment().EquipmentPacks().EquipmentPacks.Where(p => p.Name == "Entertainer's Pack").ToList()[0];
                    break;

            }

            // They also get either a Rapier, Longsword or a any simple weapon
            switch (r.Next(1,3))
            {
                default: throw new Exception("Option no valid");
                case 1:
                    
                    PrimaryWeapon = new Equipment().ReturnWeaponList().weapon.Where(w => w.Name == "Rapier").ToList()[0];
                    break;

                case 2:

                    PrimaryWeapon = new Equipment().ReturnWeaponList().weapon.Where(w => w.Name == "Longsword").ToList()[0];
                    break;

                case 3:
                    
                    var randomSimpleWeapon = new Equipment().ReturnWeaponList().weapon.Where(w => w.Properties == "Simple Melee").ToList();
                    randomSimpleWeapon = Utils.Tools.ShuffleList(randomSimpleWeapon);
                    PrimaryWeapon = randomSimpleWeapon[0];
                    break;

            }

            // Spells

            // At level 1 bards get 
            // 2 cantrips
            // 2 1st level spells

            List<string> bardCantrips = new List<string>()
            {
                "Dancing Lights",
                "Light",
                "Mage Hand",
                "Mending",
                "Message",
                "Minor Illusion",
                "Prestidigitation",
                "True Strike"
            };

            for (int i = 0; i <= 1; i++)
            {
                var pickedSpell = Utils.Tools.ReturnRandomSpell(bardCantrips);

                if (Cantrips.Contains(pickedSpell))
                {
                    i--;
                }
                else
                {
                    Cantrips.Add(pickedSpell);
                }
            }

            List<string> bardLevel1Spells = new List<string>()
            {
                "Bane",
                "Charm Person",
                "Comprehend Languages",
                "Cure Wounds",
                "Detect Magic",
                "Disguise Self",
                "Faerie Fire",
                "Feather Fall",
                "Healing Word",
                "Heroism",
                "Hideous Laughter",
                "Identify",
                "Illusory Script",
                "Longstrider",
                "Silent Image",
                "Sleep",
                "Speak with Animals",
                "Thunderwave",
                "Unseen Servant"
            };

            for (int i = 0; i <= 1; i++)
            {
                var pickedSpell = Utils.Tools.ReturnRandomSpell(bardLevel1Spells);

                if (Level1Spells.Contains(pickedSpell))
                {
                    i--;
                }
                else
                {
                    Level1Spells.Add(pickedSpell);
                }
            }


            



        }

    } 
    
}