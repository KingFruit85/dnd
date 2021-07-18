using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Barbarian : GenericCharacterClass
    {
        public Barbarian()
        {
            SetName("Barbarian");
            SetProficiencyBonus(2);
            HitDie = "1d12";

            // Populate Proficiencies
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){"Light Armor", "Medium Armor", "Shields"}},
                {"Weapons",new List<string>(){"Simple Weapons", "Martial Weapons"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Strength", "Constitution"}},
                {"Skills", new List<string>(){}}
            };

            // Barbarians can select two skills from the following list
            var barbSkillProfs = new List<string>()
            {
                "Animal Handling",
                "Athletics",
                "Intimidation",
                "Nature",
                "Perception",
                "Survival"
            };
            // Shuffle list and add the top two
            barbSkillProfs = Tools.ShuffleList(barbSkillProfs);
            Proficiencies["Skills"].Add(barbSkillProfs[0]);
            Proficiencies["Skills"].Add(barbSkillProfs[1]);

            SetProficiencies(Proficiencies);

            // Barbarians start with with a greataxe or any martial melee weapon
            switch (new Random().Next(0,1))
            {
                default: throw new Exception("invalid option");
                case 0:
                    PrimaryWeapon = GetWeapons().Where(w => w.Name == "Greataxe").ToList()[0];
                    break;
                case 1:
                    var MartialMeleeWeapons = GetWeapons().Where(w => w.WeaponType == "Martial Melee").ToList();
                    MartialMeleeWeapons = Tools.ShuffleList(MartialMeleeWeapons);
                    PrimaryWeapon = MartialMeleeWeapons[0];
                    break;
            }

            // Barbarians start also start with either 2 x handaxes or any simple weapon
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new Exception("number not in range");
                case 0:
                    // Add Simple Weapon
                    var simpleWeaponList = GetWeapons().Where(w => w.WeaponType == "Simple Melee").ToList();
                    Tools.ShuffleList(simpleWeaponList);
                    var randomWeapon = simpleWeaponList[0];
                    AdditionalWeapons.Add(randomWeapon);
                    break;
                case 1: 
                    // Add 2xHand axes
                    for (int i = 0; i < 1; i++)
                    {
                        AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Handaxe").ToList()[0]);
                    }
                    break;
            }

            // barbarians also start with an explorers pack and 4 x javelin
            EquipmentPack = GetPacks().Where(p => p.Name == "Explorer's Pack").ToList()[0];

            for (int i = 0; i <= 3; i++)
            {
                AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Javelin").ToList()[0]);
            }

            // Add Barbarian features
            Features.Add(new Feature("Rage","",1));
            Features.Add(new Feature("Unarmored Defense","",1));

        }
    }
}