using System;
using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Warlock : GenericCharacterClass
    {
        public Warlock()
        {
            SetName("Warlock");
            HitDie = "1d8";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);

            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){"Light Armor"}},
                {"Weapons",new List<string>(){"Simple Weapons"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Wisdom", "Charisma"}},
                {"Skills", new List<string>(){}}
            };

            // Warlocks can select two skills from the following list
            var warlockSkillProfs = new List<string>()
            {
                "Arcana", 
                "Deception", 
                "History", 
                "Intimidation", 
                "Investigation", 
                "Nature",
                "Religion"
            };

            Proficiencies["Skills"].Add(warlockSkillProfs[0]);
            Proficiencies["Skills"].Add(warlockSkillProfs[1]);

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // Warlocks get a light crossbow and 20 bolts or any simple weapon
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

            // A component pouch or  an arcane focus
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

            // A scholar’s pack or a dungeoneer’s pack
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Dungeoneer's Pack").ToList()[0];
                    break;
                case 1:
                    EquipmentPack = GetPacks().Where(p => p.Name == "Scholar's Pack").ToList()[0];
                    break;
            }


            // Leather armor, any simple weapon, and two daggers
            Armor = GetArmor().Where(a => a.Name == "Leather Armor").ToList()[0];

            Tools.ShuffleList(simpleWeapons);
            PrimaryWeapon = simpleWeapons[0];

            AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Dagger").ToList()[0]);
            AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Dagger").ToList()[0]);

            //////////////
            //  SPELLS  //
            //////////////

            // At level 1 warlocks get
            // 2 x Cantrips
            // 2 x First level spells 

            List<string> warlockCantrips = new List<string>()
            {
                "Chill Touch",
                "Mage Hand",
                "Minor Illusion",
                "Prestidigitation",
                "True Strike"
            };

            Cantrips = Tools.ReturnXSpellsFromList(warlockCantrips,2);
            SpellSlots = 1;

            List<string> warlockLevel1Spells = new List<string>()
            {
                "Charm Person",
                "Comprehend Languages",
                "Expeditious Retreat",
                "Illusory Script",
                "Protection from Evil and Good",
                "Unseen Servant"
            };

            Level1Spells = Tools.ReturnXSpellsFromList(warlockLevel1Spells,SpellSlots);

            //////////////
            // FEATURES //
            //////////////

            // Only details for the Fiend were released as Open Game Content by Wizards of the Coast
            Features.Add(new Feature("Otherworldly Patron","",1));
            WarlockPatron = "Fiend";
            Features.Add(new Feature("Pact Magic","",1));
        }
    }
}