using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Druid : GenericCharacterClass
    {
        public Druid()
        {
            SetName("Druid");
            HitDie = "1d8";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////
            
            SetProficiencyBonus(2);
            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){"Light Armor (Non - Metal)", "Medium Armor (Non - Metal)", "Shields (Non - Metal)" }}, // (druids will not wear armor or use shields made of metal)
                {"Weapons",new List<string>(){"Clubs", "Daggers", "Darts", "Javelins", "Maces", "Quarterstaffs", "Scimitars", "Sickles", "Slings", "Spears"}},
                {"Tools", new List<string>(){"Herbalism Kit"}},
                {"Saving Throws", new List<string>(){"Intelligence", "Wisdom"}},
                {"Skills", new List<string>(){}}
            };

            // Druids can select two skills from the following list
            var druidSkillProfs = new List<string>()
            {
                 "Arcana", 
                 "Animal Handling", 
                 "Insight", 
                 "Medicine", 
                 "Nature", 
                 "Perception", 
                 "Religion",
                 "Survival"
            };

            // Shuffle list and add the top two
            druidSkillProfs = Tools.ShuffleList(druidSkillProfs);
            Proficiencies["Skills"].Add(druidSkillProfs[0]);
            Proficiencies["Skills"].Add(druidSkillProfs[1]);

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////
            var simpleWeapons = GetWeapons().Where(w => w.WeaponType == "Simple Melee").ToList();
            var martialWeapons = GetWeapons().Where(w => w.WeaponType == "Martial Melee").ToList();


            //  Druids get a wooden shield or any simple weapon
            switch (Tools.GetRandomNumberInRange(0,1))
                        {
                            default: throw new System.Exception("number not in range");
                            case 0:
                                Shield = new Shield("Wooden Shield");
                                break;
                            case 1:
                                AdditionalWeapons.Add(Tools.ShuffleList(simpleWeapons)[0]);
                                break;
                        }

            //  a scimitar or any simple melee weapon
            switch (Tools.GetRandomNumberInRange(0,1))
                        {
                            default: throw new System.Exception("number not in range");
                            case 0:
                                PrimaryWeapon = Tools.ShuffleList(simpleWeapons)[0];
                                break;
                            case 1:
                                PrimaryWeapon = martialWeapons.Where(w => w.Name == "Scimitar").ToList()[0];
                                break;
                        }


            //  Leather armor, an explorer’s pack, and a druidic focus
            Armor = GetArmor().Where(a => a.Name == "Leather Armor").ToList()[0];
            EquipmentPack = GetPacks().Where(p => p.Name == "Explorer's Pack").ToList()[0];
            DruidicFocus = new DruidicFocus("Druidic Focus");

            ///////////////
            //  Spells   //
            /////////////// 
            // Druids know 
            // 2 x Cantrips
            // 2 x level 1 spells

            SpellSlots = 2;

            List<string> clericCantrips = new List<string>()
            {
                "Guidance",
                "Mending",
                "Produce Flame",
                "Resistance",
                "Shillelagh"
            };

            Cantrips = Tools.ReturnXSpellsFromList(clericCantrips,2);

            List<string> clericLevel1Spells = new List<string>()
            {
                "Charm Person",
                "Create or Destroy Water",
                "Cure Wounds",
                "Detect Magic",
                "Detect Poison and Disease",
                "Entangle",
                "Faerie Fire",
                "Fog Cloud",
                "Healing Word",
                "Jump",
                "Longstrider",
                "Purify Food and Drink",
                "Speak with Animals",
                "Thunderwave"
            };

            Level1Spells = Tools.ReturnXSpellsFromList(clericLevel1Spells,SpellSlots);

            //////////////
            // FEATURES //
            //////////////

            Features.Add(new Feature("Druidic","",1));         
            // Add druidic language   
            Features.Add(new Feature("Spellcasting","",1));
        }
    }
}