using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Bard : GenericCharacterClass
    {

        public Bard()
        {
            SetName("Bard");
            SetProficiencyBonus(2);
            HitDie = "1d8";

            // Populate Proficiencies
            var Proficiencies = new Dictionary<string,List<string>>()
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
            Proficiencies["Tools"].Add(randomizedInstrumentList[0].Name);
            Proficiencies["Tools"].Add(randomizedInstrumentList[1].Name);
            Proficiencies["Tools"].Add(randomizedInstrumentList[2].Name);

            // Get 3 ransom skill profs
            var randomizedSkillList = Utils.Tools.ShuffleList(Skills);
            Proficiencies["Skills"].Add(randomizedSkillList[0]);
            Proficiencies["Skills"].Add(randomizedSkillList[1]);
            Proficiencies["Skills"].Add(randomizedSkillList[2]);
 
            SetProficiencies(Proficiencies);

            // Bards get either a Lute or a random musical instrument
            // My implimentation only adds a lute if we're proficient
            // If not, then add a random instrument we are proficent in

            if (Proficiencies["Tools"].Contains("Lute"))
            {
                var lute = new Equipment().MusicalInstrument().MusicalInstruments.Where(i => i.Name == "Lute").ToList()[0];
                MusicalInstruments.Add(lute);
            }
            else
            {
                // Get a random instrument we are proficent in as a string
                var proficientInstrument = Utils.Tools.ShuffleList(Proficiencies["Tools"]).ToList()[0];
                // Reterive the instrument object
                var instument = new Equipment().MusicalInstrument().MusicalInstruments.Where(i => i.Name == proficientInstrument).ToList()[0];
                MusicalInstruments.Add(instument);
            }

            // All bards get a dagger and leather armor
            var dagger = GetWeapons().Where(w => w.Name == "Dagger").ToList()[0];
            AdditionalWeapons.Add(dagger);

            Armor = GetArmor().Where(a => a.Name == "Leather Armor").ToList()[0];

            // They also get either a Diplomat's pack or and entertainer's pack
            switch (r.Next(1,2))
            {
                default: throw new Exception("Option no valid");
                case 1:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Diplomat's Pack").ToList()[0];
                    break;
                case 2:
                    EquipmentPack= GetPacks().Where(p => p.Name == "Entertainer's Pack").ToList()[0];
                    break;
            }

            // They also get either a Rapier, Longsword or a any simple weapon
            switch (r.Next(1,3))
            {
                default: throw new Exception("Option no valid");
                case 1:
                    PrimaryWeapon = GetWeapons().Where(w => w.Name == "Rapier").ToList()[0];
                    break;
                case 2:
                    PrimaryWeapon = GetWeapons().Where(w => w.Name == "Longsword").ToList()[0];
                    break;
                case 3:
                    var randomSimpleWeapon = GetWeapons().Where(w => w.Properties == "Simple Melee").ToList();
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

            Cantrips = Utils.Tools.ReturnXSpellsFromList(bardCantrips,2);

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

            Level1Spells = Utils.Tools.ReturnXSpellsFromList(bardLevel1Spells,2);

            // Add Bard Features
            Features.Add(new Feature("Spellcasting", "", 1));
            Features.Add(new Feature("Bardic Inspiration (d6)","",1));

        }
    }
}