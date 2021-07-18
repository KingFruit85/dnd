using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Paladin : GenericCharacterClass
    {
        public Paladin()
        {
            SetName("Paladin");
            HitDie = "1d10";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){ "Light Armor", "Medium Armor", "Shields"}},
                {"Weapons",new List<string>(){"Simple Weapons", "Martial Weapons"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Wisdom", "Charisma"}},
                {"Skills", new List<string>(){}}
            };

            // Paladins can select two skills from the following list
            var paladinSkillProfs = new List<string>()
            {
                "Athletics", 
                "Insight", 
                "Intimidation", 
                "Medicine", 
                "Persuasion",
                "Religion"
            };

            // Shuffle list and add the top two
            paladinSkillProfs = Tools.ShuffleList(paladinSkillProfs);
            Proficiencies["Skills"].Add(paladinSkillProfs[0]);
            Proficiencies["Skills"].Add(paladinSkillProfs[1]);

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // Paladins start with a martial weapon and a shield or two martial weapons
            List<Weapon> martialWeapons = GetWeapons().Where(w => w.WeaponType == "Martial Melee").ToList();
            List<Weapon> simpleWeapons = GetWeapons().Where(w => w.WeaponType == "Simple Melee").ToList();
            
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    Weapon weapon = Tools.ShuffleList(martialWeapons)[0];
                    PrimaryWeapon = weapon;
                    Shield = new Shield("Shield");
                    break; 
                case 1:
                    // I assume the two weapons imply duel-weilding
                    List<Weapon> OneHandedMartialWeapons = martialWeapons.Where(w => w.Twohanded == false).ToList();
                    Weapon weapon1 = Tools.ShuffleList(OneHandedMartialWeapons)[0];
                    Weapon weapon2 = Tools.ShuffleList(OneHandedMartialWeapons)[0];
                    PrimaryWeapon = weapon1;
                    OffHandWeapon = weapon2;
                    break;
            }

            // Paladins also get five javelins or any simple melee weapon
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    for (int i = 0; i <= 4; i++)
                    {
                        AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Javelin").ToList()[0]);
                    }
                    break;

                case 1:
                    AdditionalWeapons.Add(Tools.ShuffleList(simpleWeapons)[0]);
                    break;
            }

            // And a priest’s pack or an explorer’s pack
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Priest's Pack").ToList()[0];
                    break;
                case 1:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Explorer's Pack").ToList()[0];
                    break;
            }

            // Chain mail and a holy symbol
            Armor = GetArmor().Where(a => a.Name == "Chain Mail").ToList()[0];
            HolySymbol = new HolySymbol("Holy Symbol");

            //////////////
            // FEATURES //
            //////////////

            Features.Add(new Feature("Divine Sense","",1));
            Features.Add(new Feature("Lay on Hands","",1));

        }
    }
}