using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Cleric : GenericCharacterClass
    {
        public Cleric()
        {
            SetName("Cleric");
            HitDie = "1d8";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){ "Light Armor", "Medium Armor", "Shields"}},
                {"Weapons",new List<string>(){"Simple Weapons"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Wisdom", "Charisma"}},
                {"Skills", new List<string>(){}}
            };

            // Clerics can select two skills from the following list
            var clericSkillProfs = new List<string>()
            {
                "History",
                "Insight",
                "Medicine",
                "Persuasion",
                "Religion"
            };

            // Shuffle list and add the top two
            clericSkillProfs = Utils.Tools.ShuffleList(clericSkillProfs);
            Proficiencies["Skills"].Add(clericSkillProfs[0]);
            Proficiencies["Skills"].Add(clericSkillProfs[1]);

            // SRD Clerics can only be life domain, they are proficient in heavy armor
            Proficiencies["Armor"].Add("Heavy Armor");

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////
            // Clerics get a mace or a warhammer (if proficient)
            // Since Life domain clerics are not proficient in martial melee weapons we
            // just add a warhammer for now

            PrimaryWeapon = GetWeapons().Where(w => w.Name == "Warhammer").ToList()[0];
            
            // Life Clerics get either scale mail, leather armor, or chain mail (if proficient) at level 1
            // Since we are life clerics might as well get the best AC right?
            Armor = GetArmor().Where(a => a.Name == "Chain Mail").ToList()[0];

            // Clerics get either a light crossbow and 20 bolts or any simple weapon
            
            switch (Utils.Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    // Add light crossbow and 20 bolts
                    AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Light Crossbow").ToList()[0]);
                    Ammunition.Add(new Ammunition("bolt",20,"A simple bolt"));
                    break;
                case 1:
                    // Add a random simple weapon
                    var simpleWeapons = GetWeapons().Where(w => w.WeaponType == "Simple Melee").ToList();
                    var weapon = Utils.Tools.ShuffleList(simpleWeapons)[0];
                    AdditionalWeapons.Add(weapon);
                    break;
            }

            // Clerics also get either a priest’s pack or an explorer’s pack
            switch (Utils.Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Priest's Pack").ToList()[0];
                    break;
                case 1:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Explorer's Pack").ToList()[0];
                    break;
            }

            // Clerics get a shield and a holy symbol
            Shield = new Shield("Shield");
            HolySymbol = new HolySymbol("Holy Symbol");

            // SPELLS
            // Clerics know 
            // 3 cantrips
            // 2 level 1 spells

            List<string> clericCantrips = new List<string>()
            {
                "Guidance",
                "Light",
                "Mending",
                "Resistance",
                "Sacred Flame",
                "Thaumaturgy",
            };

            Cantrips = Utils.Tools.ReturnXSpellsFromList(clericCantrips,3);

            List<string> clericLevel1Spells = new List<string>()
            {
                "Bane",
                "Bless",
                "Command",
                "Create or Destroy Water",
                "Cure Wounds",
                "Detect Evil and Good",
                "Detect Magic",
                "Detect Poison and Disease",
                "Guiding Bolt",
                "Healing Word",
                "Inflict Wounds",
                "Protection from Evil and Good",
                "Purify Food and Drink",
                "Sanctuary",
                "Shield of Faith"
            };

            Level1Spells = Utils.Tools.ReturnXSpellsFromList(clericLevel1Spells,2);

            // Add Cleric features
            Features.Add(new Feature("Spellcasting","",1));
            Features.Add(new Feature("Divine Domain","",1));

        }
    }
}