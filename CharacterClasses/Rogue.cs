using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Rogue : GenericCharacterClass
    {
        public Rogue()
        {
            SetName("Rogue");
            HitDie = "1d8";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){"Light Armor"}},
                {"Weapons",new List<string>(){"Simple Weapons", "Hand Crossbow", "Longsword", "Rapiers", "Shortsword"}},
                {"Tools", new List<string>(){"Thieves’ Tools"}},
                {"Saving Throws", new List<string>(){"Dexterity", "Intelligence"}},
                {"Skills", new List<string>(){}}
            };

            // Rogues can select four skills from the following list
            var rogueSkillProfs = new List<string>()
            {
                 "Acrobatics", 
                 "Athletics", 
                 "Deception", 
                 "Insight", 
                 "Intimidation", 
                 "Investigation", 
                 "Perception", 
                 "Performance", 
                 "Persuasion", 
                 "Sleight of Hand",
                 "Stealth"
            };

            // Shuffle list and add the top four
            rogueSkillProfs = Tools.ShuffleList(rogueSkillProfs);
            Proficiencies["Skills"].Add(rogueSkillProfs[0]);
            Proficiencies["Skills"].Add(rogueSkillProfs[1]);
            Proficiencies["Skills"].Add(rogueSkillProfs[2]);
            Proficiencies["Skills"].Add(rogueSkillProfs[3]);


            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // Rogues start with a rapier or a shortsword
            Weapon rapier = GetWeapons().Where(w => w.Name == "Rapier").ToList()[0];
            Weapon longSword = GetWeapons().Where(w => w.Name == "Longsword").ToList()[0];

            switch (Tools.GetRandomNumberInRange(0,1))
                        {
                            default: throw new System.Exception("number not in range");
                            case 0:
                                PrimaryWeapon = rapier;
                                break;
                            case 1:
                                PrimaryWeapon = longSword;
                                break;
                        }

            // a shortbow and quiver of 20 arrows or a shortsword
            Weapon shortSword = GetWeapons().Where(w => w.Name == "Shortsword").ToList()[0];
            Weapon shortBow = GetWeapons().Where(w => w.Name == "Shortbow").ToList()[0];

            switch (Tools.GetRandomNumberInRange(0,1))
                        {
                            default: throw new System.Exception("number not in range");
                            case 0:
                                AdditionalWeapons.Add(shortSword);      
                                break;
                            case 1:
                                AdditionalWeapons.Add(shortBow);
                                Ammunition.Add(new Ammunition("shortbow arrows",20,"A quiver of shortbow arrows"));
                                break;   
                        }

            // a burglar’s pack, a dungeoneer’s pack, or an explorer’s pack
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

            // Leather armor, two daggers, and thieves’ tools
            Armor = GetArmor().Where(a => a.Name == "Leather Armor").ToList()[0];
            AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Dagger").ToList()[0]);
            AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Dagger").ToList()[0]);

            //////////////
            // FEATURES //
            //////////////

            Features.Add(new Feature("Expertise","",1));
            Features.Add(new Feature("Sneak Attack","",1));
            Features.Add(new Feature("Thieves’ Cant","",1));



        }
    }
}