using System;
using Names;
using CharacterClasses;
using System.Linq;
using System.Collections.Generic;
using Races;

namespace Character
{
    [Serializable]
    public abstract class CharacterTemplate
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string CharacterClass {get;set;}
        public string Gender {get;set;}
        public int HitPoints {get; set;}
        public int ArmorClass {get; set;}
        public GenericRace Race {get;set;}
        public AbilityScore AbilityScores {get;set;} = new AbilityScore();
        public ClassFeatures ClassFeatures {get;set;}
        public Dictionary<string, int> Skills {get; set;}
        public Dictionary<string, int> SavingThrows {get; set;}


        // Getters & Setters
        public GenericRace GetRace(){return Race;}
        public void SetRace(GenericRace race){Race = race;}

        public string GetFirstName(){return FirstName;}
        public void SetFirstName(string name){FirstName = name;}

        public string GetLastName(){return LastName;}
        public void SetLastName(string name){LastName = name;}

        public string GetCharacterClass(){return CharacterClass;}
        public void SetCharacterClass(string className){CharacterClass = className;}

        public string GetGender(){return Gender;}
        public void SetGender(string gender){Gender = gender;}
    
        public AbilityScore GetAbilityScores()
        {
            return AbilityScores;
        }

        public AbilityScore GetAbilityScores(string score)
        {
            return AbilityScores;
        }

        public void SetAbilityScore(AbilityScore abilityScore)
        {
            AbilityScores = abilityScore;
        }

        public void SetSkillsAndSavingThrows()
        {
            // SKILLS
            var Intelligence = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetIntelligenceScore());
            var Strength = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetStrengthScore());
            var Constitution = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetConstitutionScore());
            var Dexterity = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetDexterityScore());
            var Wisdom = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetWisdomScore());
            var Charisma = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetCharismaScore());

            var skillAndMods = new Dictionary<string, int>();

            skillAndMods["athletics"] = Strength;
            skillAndMods["acrobatics"] = Dexterity;
            skillAndMods["sleightOfHand"] = Dexterity;
            skillAndMods["arcana"] = Intelligence;
            skillAndMods["stealth"] = Dexterity;
            skillAndMods["history"] = Intelligence;
            skillAndMods["nature"] = Intelligence;
            skillAndMods["religion"] = Intelligence;
            skillAndMods["animalHandling"] = Wisdom;
            skillAndMods["insight"] = Wisdom;
            skillAndMods["medicine"] = Wisdom;
            skillAndMods["perception"] = Wisdom;
            skillAndMods["survival"] = Wisdom;
            skillAndMods["deception"] = Charisma;
            skillAndMods["intimidation"] = Charisma;
            skillAndMods["investigation"] = Intelligence;
            skillAndMods["performance"] = Charisma;
            skillAndMods["persuasion"] = Charisma;

            // Add prof bonus 

            var profBonuses = ClassFeatures.GetProficiencies()["Skills"];

            foreach (var skill in profBonuses)
            {
                if (skillAndMods.ContainsKey(skill))
                {
                    skillAndMods[skill] += ClassFeatures.GetProficiencyBonus();
                }
            }

            Skills = skillAndMods;

            // SAVING THROWS

            var savingThrowProfs = ClassFeatures.GetProficiencies()["Saving Throws"];

            var savingThrows = new Dictionary<string, int>()
            {
                {"Strength",Strength},
                {"Dexterity",Dexterity},
                {"Constitution",Constitution},
                {"Intelligence",Intelligence},
                {"Wisdom",Wisdom},
                {"Charisma",Charisma}
            };

            foreach (var savingThrow in savingThrowProfs)
            {
                if (skillAndMods.ContainsKey(savingThrow))
                {
                    savingThrows[savingThrow] += ClassFeatures.GetProficiencyBonus();
                }
            }

            SavingThrows = savingThrows;

        }

        public void SetLevel1HitPoints()
        {
            var constitutionModifier = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetConstitutionScore());

            switch (ClassFeatures.Name)
            {
                default: throw new Exception("invalid characterClass provided");
                case "Barbarian":HitPoints = 12 + constitutionModifier;break;
                case "Bard": HitPoints = 8 + constitutionModifier;break;
                case "Cleric":HitPoints = 8 + constitutionModifier;break;
                case "Druid":HitPoints = 8 + constitutionModifier;break;
                case "Fighter":HitPoints = 10 + constitutionModifier;break;
                case "Monk":HitPoints = 8 + constitutionModifier;break;
                case "Paladin":HitPoints = 10 + constitutionModifier;break;
                case "Ranger":HitPoints = 10 + constitutionModifier;break;
                case "Rogue":HitPoints = 8 + constitutionModifier;break;
                case "Sorcerer":HitPoints = 6 + constitutionModifier;break;
                case "Warlock":HitPoints = 8 + constitutionModifier;break;
                case "Wizard":HitPoints = 6 + constitutionModifier;break;
            }
        }

        public void CalculateArmorClass()
        {
            int armorClassValue = ClassFeatures.Armor.BaseArmorClass;

            if (ClassFeatures.Armor.AdditionalModifier != null)
            {
                var modValue = ClassFeatures.Armor.AdditionalModifier;
                var abilityScoreMod = AbilityScores.getAbilityScoreModifier(modValue);
                armorClassValue += (int)abilityScoreMod;
            }

            ArmorClass = armorClassValue;

        }

    }

    

    public class ManualCharacter : CharacterTemplate
    {
        

    }

    // -- Returns a character object where all character customisation steps have been randomised
    [Serializable]
    public class RandomCharacter : CharacterTemplate
    {
        public RandomCharacter()
        {
            SetRandomClass();
            GetAbilityScores().Arrange(GetCharacterClass());
            SetRandomRace();
            UpdateAbilityScores();
            SetRandomGender();
            SetRandomName(GetGender(), GetRace().GetName());

            ClassFeatures = new Bard();

            SetSkillsAndSavingThrows();
            SetLevel1HitPoints();
            CalculateArmorClass();

        }

        public void SetRandomRace()
        {
            SetRace(new RaceLists().GetRandomRace());
        }

        public void SetRandomName(string gender, string race)
        {
            NameLists name = new NameLists();
            var FullName = name.SetRandomName(gender, race);
            SetFirstName(FullName[0]);
            SetLastName(FullName[1]);
        }

        public void SetRandomClass()
        {
            SetCharacterClass(new CharacterClassList().GetRandomClass());
        }

        public void SetRandomGender()
        {
            Random r = new Random();
            int i = r.Next(1,100);
            
            if (i >= 1 && i <=39)
            {
                SetGender("Male");   
            }
            else if (i >= 40 && i <=79)
            {
                SetGender("Female");
            }
            else
            {
                SetGender("Non-Binary");
            }
        }


        public void UpdateAbilityScores()
        {
            // Grab the the scores to be added
            var ASU = GetRace().GetAbilityScoreIncrease();

            // Update the characters abilityscores
            foreach (var stat in ASU)
            {
                   GetAbilityScores().SetScore(stat.Key,stat.Value);
            }
        }

        public void PrintCharacterInfoToConsole()
        {
            Console.WriteLine("*-Character Attributes-*");
            Console.WriteLine($"Name:{GetFirstName()} {GetLastName()}");
            Console.WriteLine($"Class:{GetCharacterClass()}");
            Console.WriteLine($"Gender:{GetGender()}");
            Console.WriteLine($"Raw Scores: [{GetAbilityScores().GetRawScores()[0]}] [{GetAbilityScores().GetRawScores()[1]}] [{GetAbilityScores().GetRawScores()[2]}] [{GetAbilityScores().GetRawScores()[3]}] [{GetAbilityScores().GetRawScores()[4]}] [{GetAbilityScores().GetRawScores()[5]}]");
            Console.WriteLine($"AbilityScores: STR:[{GetAbilityScores().GetStrengthScore()}] DEX:[{GetAbilityScores().GetDexterityScore()}] CON:[{GetAbilityScores().GetConstitutionScore()}] INT:[{GetAbilityScores().GetIntelligenceScore()}] WIS:[{GetAbilityScores().GetWisdomScore()}] CHA:[{GetAbilityScores().GetCharismaScore()}]");
            Console.WriteLine();

            Console.WriteLine("*-Race Attributes-*");
            Console.WriteLine($"Race:{GetRace()}");
            Console.WriteLine("-Known Languages-");
            GetRace().GetLanguages().ForEach(i => Console.WriteLine("{0}\t", i));
            Console.WriteLine("-");
            Console.WriteLine($"Speed:{GetRace().GetSpeed()}");
            Console.WriteLine($"Age:{GetRace().GetAge()}");
            Console.WriteLine($"Alignment:{GetRace().GetAlignment()}");
            Console.WriteLine($"Size:{GetRace().GetSize()}");
            Console.WriteLine("-Ability Score Increases-");
            GetRace().GetAbilityScoreIncrease().ToList().ForEach(x => Console.WriteLine(x.Key + ": " + x.Value));



        }

    }

}