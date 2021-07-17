using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Fighter : GenericCharacterClass
    {
        public Fighter()
        {
            SetName("Fighter");
            HitDie = "1d10";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////

            SetProficiencyBonus(2);
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){ "Light Armor", "Medium Armor", "Heavy Armor","Shields"}},
                {"Weapons",new List<string>(){"Simple Weapons", "Martial Weapons"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Strength", "Constitution"}},
                {"Skills", new List<string>(){}}
            };

            // Fighters can select two skills from the following list
            var fighterSkillProfs = new List<string>()
            {
                "Acrobatics",
                "Animal Handling",
                "Athletics",
                "History",
                "Insight",
                "Intimidation",
                "Perception",
                "Survival"
            };

            // Shuffle list and add the top two
            fighterSkillProfs = Tools.ShuffleList(fighterSkillProfs);
            Proficiencies["Skills"].Add(fighterSkillProfs[0]);
            Proficiencies["Skills"].Add(fighterSkillProfs[1]);

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // Fighters get either chain mail or leather armor, a longbow, and 20 arrows

            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:

                    Armor = GetArmor().Where(a => a.Name == "Chain Mail").ToList()[0];
                    break;
                case 1:
                    Armor = GetArmor().Where(a => a.Name == "Leather Armor").ToList()[0];
                    AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Longbow").ToList()[0]);
                    Ammunition.Add(new Ammunition("bolt",20,"A longbow arrow"));
                    break;
            }

            // They also get either a martial weapon and a shield or two martial weapons 

            var martialWeapons = GetWeapons().Where(w => w.WeaponType == "Martial Melee").ToList();
            Weapon weaponToAdd;
        
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    weaponToAdd = Tools.ShuffleList(martialWeapons)[0];
                    PrimaryWeapon = weaponToAdd;
                    Shield = new Shield("Shield");
                    break;
                case 1:
                    // Get 1-h martial weapons and add to mainhand and offhand
                    var OHMartialWeapons = martialWeapons.Where(w => w.Twohanded == false).ToList();
                    OHMartialWeapons = Tools.ShuffleList(OHMartialWeapons);

                    var index = Tools.GetRandomNumberInRange(0,OHMartialWeapons.Count);
                    PrimaryWeapon = OHMartialWeapons[index];

                    index = Tools.GetRandomNumberInRange(0,OHMartialWeapons.Count);
                    OffHandWeapon = OHMartialWeapons[index];
                    
                    break;
            }

            //  And a light crossbow and 20 bolts or two handaxes

            var handAxe = GetWeapons().Where(w => w.Name == "Handaxe").ToList()[0];

            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0: 
                    AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Light Crossbow").ToList()[0]);
                    Ammunition.Add(new Ammunition("bolt",20,"A simple bolt"));
                    break;
                case 1:
                    AdditionalWeapons.Add(handAxe);
                    AdditionalWeapons.Add(handAxe);
                    break;
            }

            // And finally a dungeoneer’s pack or an explorer’s pack

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
            
            //////////////
            // FEATURES //
            //////////////

            Features.Add(new Feature("Fighting Style","",1));
            Features.Add(new Feature("Second Wind","",1));

            var fightingstyles = new List<string>()
            {
                "Archery",
                "Defense",
                "Dueling",
                "Great Weapon Fighting",
                "Protection",
                "Two-Weapon Fighting"
            };

            FightingStyle = Tools.ShuffleList(fightingstyles)[0];

        }
    }
}