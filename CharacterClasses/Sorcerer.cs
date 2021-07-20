using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Sorcerer : GenericCharacterClass
    {
        public Sorcerer()
        {
            SetName("Sorcerer");
            HitDie = "1d8";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){}},
                {"Weapons",new List<string>(){"Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows"}},
                {"Tools", new List<string>(){}},
                {"Saving Throws", new List<string>(){"Constitution", "Charisma"}},
                {"Skills", new List<string>(){}}
            };

            // Sorcerers can select two skills from the following list
            var sorcererSkillProfs = new List<string>()
            {
                 "Arcana", 
                 "Deception", 
                 "Insight", 
                 "Intimidation", 
                 "Persuasion",
                 "Religion"
            };

            // Shuffle list and add the top two
            sorcererSkillProfs = Tools.ShuffleList(sorcererSkillProfs);
            Proficiencies["Skills"].Add(sorcererSkillProfs[0]);
            Proficiencies["Skills"].Add(sorcererSkillProfs[1]);


            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // Sorcerers start with a light crossbow and 20 bolts or any simple weapon
            var simpleWeapons = GetWeapons().Where(w => w.WeaponType == "Simple Melee").ToList();

            switch (Tools.GetRandomNumberInRange(0,1))
                        {
                            default: throw new System.Exception("number not in range");
                            case 0:
                                PrimaryWeapon = GetWeapons().Where(w => w.Name == "Light Crossbow").ToList()[0];
                                Ammunition.Add(new Ammunition("light crossbow bolts",20,"A quiver of light crossbow bolts")) ;
                                break;
                            case 1:
                                 Tools.ShuffleList(simpleWeapons);
                                 PrimaryWeapon = simpleWeapons[0];
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

            // A dungeoneer’s pack or an explorer’s pack
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Dungeoneer's Pack").ToList()[0];
                    break;
                case 1:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Explorer's Pack").ToList()[0];
                    break;
            }

            // Two daggers
            AdditionalWeapons.Add(GetWeapons().Where(w =>w.Name == "Dagger").ToList()[0]);
            AdditionalWeapons.Add(GetWeapons().Where(w =>w.Name == "Dagger").ToList()[0]);

            //////////////
            //  SPELLS  //
            //////////////

            // At level 1 sorcerers get
            // 4 x Cantrips
            // 2 x 2 First level spells 

            List<string> sorcererCantrips = new List<string>()
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

            Cantrips = Tools.ReturnXSpellsFromList(sorcererCantrips,4);

            List<string> sorcererLevel1Spells = new List<string>()
            {
                "Burning Hands",
                "Charm Person",
                "Color Spray",
                "Comprehend Languages",
                "Detect Magic",
                "Disguise Self",
                "Expeditious Retreat",
                "False Life",
                "Feather Fall",
                "Fog Cloud",
                "Jump",
                "Mage Armor",
                "Magic Missile",
                "Shield",
                "Silent Image",
                "Sleep",
                "Thunderwave"
            };

            Level1Spells = Tools.ReturnXSpellsFromList(sorcererLevel1Spells,2);

            //////////////
            // FEATURES //
            //////////////

            Features.Add(new Feature("Spellcasting","",1));

            Features.Add(new Feature("Sorcerous Origin","",1));
            // SRD only contains draconic bloodline
            SorcerousOrigin = "Draconic";
            
            

            Dictionary<string,string> DA = new Dictionary<string, string>()
            {
                {"Black","Acid"},
                {"Blue","Lightning"},
                {"Brass","Fire"},
                {"Bronze","Lightning"},
                {"Copper","Acid"},
                {"Gold","Fire"},
                {"Green","Poison"},
                {"Red",	"Fire"},
                {"Silver","Cold"},
                {"White","Cold"}
            };
            
            int index = Tools.GetRandomNumberInRange(0,DA.Count -1);
            KeyValuePair<string, string> pair = DA.ElementAt(index);
            DraconicAncestry = pair;

            // Hitpoint +1 per level added in Character.cs SetLevel1HitPoints()
            // Unarmored AC = 13 + Dex mod added in Character.cs CalculateArmorClass()
        }
    }
}