using System.Collections.Generic;
using System.Linq;

namespace Character
{
    public class Monk : GenericCharacterClass
    {
        public Monk()
        {
            SetName("Monk");
            HitDie = "1d8";

            ///////////////////
            // PROFICIENCIES //
            ///////////////////

            SetProficiencyBonus(2);

            var Proficiencies = new Dictionary<string,List<string>>()
            {
                {"Armor", new List<string>(){}},
                {"Weapons",new List<string>(){"Simple Weapons", "Shortswords"}},
                {"Tools", new List<string>()},
                {"Saving Throws", new List<string>(){"Strength", "Dexterity"}},
                {"Skills", new List<string>(){}}
            };

            // Monks can select either one musical instrument or one artisan tool to be proficient in
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    var toolList = new Equipment().ReturnArtisansToolList().artisansTools;
                    toolList = Tools.ShuffleList(toolList);
                    Proficiencies["Tools"].Add(toolList[0].Name);
                    break;
                case 1:
                    var instrumentList = new Equipment().MusicalInstrument().MusicalInstruments;
                    instrumentList = Tools.ShuffleList(instrumentList);
                    Proficiencies["Tools"].Add(instrumentList[0].Name);
                    break;
            }

            // Monks can select two skills from the following list
            var fighterSkillProfs = new List<string>()
            {
                "Acrobatics",
                "Athletics",
                "History",
                "Insight",
                "Religion",
                "Stealth"
            };

            // Shuffle list and add the top two
            fighterSkillProfs = Tools.ShuffleList(fighterSkillProfs);
            Proficiencies["Skills"].Add(fighterSkillProfs[0]);
            Proficiencies["Skills"].Add(fighterSkillProfs[1]);

            SetProficiencies(Proficiencies);

            ///////////////
            // EQUIPMENT //
            ///////////////

            // Monks get either a shortsword or any simple weapon
            
            switch (Tools.GetRandomNumberInRange(0,1))
            {
                default: throw new System.Exception("number not in range");
                case 0:
                    PrimaryWeapon = GetWeapons().Where(w => w.Name == "Shortsword").ToList()[0];
                    break;
                case 1:
                    var simpleWeapons = GetWeapons().Where(w => w.WeaponType == "Simple Melee").ToList();
                    PrimaryWeapon = Tools.ShuffleList(simpleWeapons).ToList()[0];
                    break;
            }

            // They also get a dungeoneer’s pack or an explorer’s pack
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
            

            // And 10 darts
            // This is a bit shit, perhaps darts should be treated as ammo?
            
            for (int i = 0; i <= 10; i++)
            {
                AdditionalWeapons.Add(GetWeapons().Where(w => w.Name == "Dart").ToList()[0]);
            }

            //////////////
            // FEATURES //
            //////////////

            Features.Add(new Feature("Unarmored Defense","",1));
            Features.Add(new Feature("Martial Arts","",1));




           
        }
    }
}