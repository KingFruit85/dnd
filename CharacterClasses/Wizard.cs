using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Wizard : GenericCharacterClass
    {
        public Wizard()
        {
            SetName("Wizard");
            HitDie = "1d6";

            ///////////////////z
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);

            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){}},
                {"Weapons",new List<string>(){"Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Intelligence", "Wisdom"}},
                {"Skills", new List<string>(){}}
            };

            // Wizards can select two skills from the following list
            var wizardSkillProfs = new List<string>()
            {
                "Arcana", 
                "History", 
                "Insight", 
                "Investigation", 
                "Medicine",
                "Religion"
            };

            Proficiencies["Skills"].Add(wizardSkillProfs[0]);
            Proficiencies["Skills"].Add(wizardSkillProfs[1]);

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // A quarterstaff or a dagger
                switch (Tools.GetRandomNumberInRange(0,1))
                            {
                                default: throw new System.Exception("number not in range");
                                case 0:
                                    PrimaryWeapon = GetWeapons().Where(w => w.Name == "Quarterstaff").ToList()[0];
                                    break;
                                case 1:
                                    PrimaryWeapon = GetWeapons().Where(w => w.Name == "Dagger").ToList()[0];
                                    break;
                            }

            // A component pouch or an arcane focus
            switch (Tools.GetRandomNumberInRange(0,1))
                        {
                            default: throw new System.Exception("number not in range");
                            case 0:
                                OtherEquipment.Add("Component Pouch");
                                break;
                            case 1:
                                OtherEquipment.Add("Arcane Focus");
                                break;
                        }

            // A scholar’s pack or an explorer’s pack
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Explorer's Pack").ToList()[0];
                    break;
                case 1:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Scholar's Pack").ToList()[0];
                    break;
            }

            // A spellbook
            OtherEquipment.Add("Spellbook");

            //////////////
            //  SPELLS  //
            //////////////

            // At level 1 Wizards get
            // 3 x Cantrips
            // 2 x First level spells 
            
            SpellSlots = 2;

            List<string> wizardCantrips = new List<string>()
            {
                "Acid Splash",
                "Chill Touch",
                "Dancing Lights",
                "Fire Bolt",
                "Light",
                "Mage Hand",
                "Mending",
                "Message",
                "Minor Illusion",
                "Prestidigitation",
                "Ray of Frost",
                "Shocking Grasp",
                "True Strike"
            };

            Cantrips = Tools.ReturnXSpellsFromList(wizardCantrips,3);

            List<string> wizardLevel1Spells = new List<string>()
            {
                "Alarm",
                "Burning Hands",
                "Charm Person",
                "Color Spray",
                "Comprehend Languages",
                "Detect Magic",
                "Disguise Self",
                "Expeditious Retreat",
                "False Life",
                "Feather Fall",
                "Floating Disk",
                "Fog Cloud",
                "Grease",
                "Hideous Laughter",
                "Identify",
                "Illusory Script",
                "Jump",
                "Longstrider",
                "Mage Armor",
                "Magic Missile",
                "Protection from Evil and Good",
                "Shield",
                "Silent Image",
                "Sleep",
                "Thunderwave",
                "Unseen Servant"
            };

            Level1Spells = Tools.ReturnXSpellsFromList(wizardLevel1Spells,SpellSlots);

            //////////////
            // FEATURES //
            //////////////

            // Only details for the Fiend were released as Open Game Content by Wizards of the Coast
            Features.Add(new Feature("Spellcasting","",1));
            Features.Add(new Feature("Arcane Recovery","",1));
        }
    }
}