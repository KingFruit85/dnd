using System;
using Names;
using System.Collections.Generic;

namespace Character
{
    public abstract class CharacterTemplate
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string CharacterClass {get;set;}
        public string Gender {get;set;}
        public int HitPoints {get; set;}
        public int ArmorClass {get; set;}
        public int Initiative { get; set; }
        public GenericRace RaceDetails {get;set;}
        public AbilityScore AbilityScores {get;set;} = new AbilityScore();
        public GenericCharacterClass ClassDetails {get;set;}
        public Dictionary<string, int> Skills {get; set;}
        public Dictionary<string, int> SavingThrows {get; set;}

        // Getters & Setters
        public void SetRace(GenericRace race){RaceDetails = race;}
        public GenericRace GetRace(){return RaceDetails;}
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

            var profBonuses = ClassDetails.GetProficiencies()["Skills"];

            foreach (var skill in profBonuses)
            {
                if (skillAndMods.ContainsKey(skill))
                {
                    skillAndMods[skill] += ClassDetails.GetProficiencyBonus();
                }
            }

            Skills = skillAndMods;

            // SAVING THROWS

            var savingThrowProfs = ClassDetails.GetProficiencies()["Saving Throws"];

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
                    savingThrows[savingThrow] += ClassDetails.GetProficiencyBonus();
                }
            }

            SavingThrows = savingThrows;

        }

        public void AddRacialProficiencies()
        {
            var skills = RaceDetails.RaceSkillProficienciesToAdd;
            var weapons = RaceDetails.RaceWeaponProficienciesToAdd;
            var armors = RaceDetails.RaceArmorProficienciesToAdd;
            var tools = RaceDetails.RaceToolProficienciesToAdd;

            if (skills.Count > 0)
            {
                foreach (var skill in skills)
                {
                    if (!ClassDetails.Proficiencies["Skills"].Contains(skill))
                    {
                        ClassDetails.Proficiencies["Skills"].Add(skill);      
                    }
                }
            }

            if (weapons.Count > 0)
            {
                foreach (var weapon in weapons)
                {
                    if (!ClassDetails.Proficiencies["Weapons"].Contains(weapon))
                    {
                        ClassDetails.Proficiencies["Weapons"].Add(weapon);
                    }
                }
            }
            
            if (armors.Count > 0)
            {
                foreach (var armor in armors)
                {
                    if (!ClassDetails.Proficiencies["Armor"].Contains(armor))
                    {
                        ClassDetails.Proficiencies["Weapons"].Add(armor);
                    }
                }
            }

            if (tools.Count > 0)
            {
                foreach (var armor in armors)
                {
                    if (!ClassDetails.Proficiencies["Armor"].Contains(armor))
                    {
                        ClassDetails.Proficiencies["Weapons"].Add(armor);
                    }
                }
            }
        }

    
        public void AddRacialSpells()
        {
            var spells = RaceDetails.SpellsToAdd;
            List<Spells> actualSpells = new List<Spells>();

            if (spells.Count > 0)
            {
                foreach (var spell in spells)
                {
                    actualSpells.Add(Tools.ReturnSpecificSpell(spell));
                }
            }

            foreach (var spell in actualSpells)
            {

                if (spell.level == 0 && !ClassDetails.Cantrips.Contains(spell))
                {
                    ClassDetails.Cantrips.Add(spell);
                }

                if (spell.level == 1 && !ClassDetails.Level1Spells.Contains(spell))
                {
                    ClassDetails.Level1Spells.Add(spell);
                }


                
            }
        }

        public void SetLevel1HitPoints()
        {
            var constitutionModifier = (int)AbilityScores.getAbilityScoreModifier(AbilityScores.GetConstitutionScore());
            
            switch (ClassDetails.Name)
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

            // The Hill Dwarf subrace hit point maximum increases by 1
            if (this.RaceDetails.SubRace == "Hill Dwarf")
            {
                HitPoints += 1;    
            }

            // Sorcerer Draconic Ancestry
            if (this.ClassDetails.SorcerousOrigin == "Draconic")
            {
                HitPoints += 1;
            }

        }

        public void CalculateArmorClass()
        {
            int armorClassValue = ClassDetails.Armor.BaseArmorClass;

            // Check from barbarian/Unarmored Defense
            var isBarbarian = (this.ClassDetails.Name == "Barbarian") ? true : false ;
            var isFighter = (this.ClassDetails.Name == "Fighter") ? true : false ;
            var isMonk = (this.ClassDetails.Name == "Monk") ? true : false ;
            var isSorcerer = (this.ClassDetails.Name == "Sorcerer") ? true : false ;

            var isHoldingShield = (this.ClassDetails.Shield != null);

            if (isBarbarian)
            {
                // This should check for armor
                ArmorClass = 10 
                                + (int)AbilityScores.getAbilityScoreModifier("DEX") 
                                + (int)AbilityScores.getAbilityScoreModifier("CON");
                return;
            }

            if (isFighter)
            {
                // Checks to see if Fighter has Defence fighting style and has armor equipped
                if (this.ClassDetails.FightingStyle == "Defense" && this.ClassDetails.Armor.Name != null)
                {
                    armorClassValue += 1;
                }
            }

            if (isMonk)
            {
                // Double checks to make sure no armor is equipped
                if (this.ClassDetails.Armor.Name == null)
                {
                    ArmorClass = 10 
                                    + (int)AbilityScores.getAbilityScoreModifier("DEX") 
                                    + (int)AbilityScores.getAbilityScoreModifier("WIS");
                return;

                }
            }

            if (isSorcerer)
            {
                // Checks SorcerousOrigin for Draconic
                // Draconic Sorcerous Origin Unarmored AC = 13 + Dex mod

                if (this.ClassDetails.Armor.Name == null)
                {
                    ArmorClass = 10 
                                    + (int)AbilityScores.getAbilityScoreModifier("DEX");
                    return;
                }

            }

            if (isHoldingShield)
            {
                armorClassValue += 2;
            }

            if (ClassDetails.Armor.AdditionalModifier != null)
            {
                var modValue = ClassDetails.Armor.AdditionalModifier;
                var abilityScoreMod = AbilityScores.getAbilityScoreModifier(modValue);
                armorClassValue += (int)abilityScoreMod;
            }

            ArmorClass = armorClassValue;

        }

        public void CalculateInitiative()
        {
            Initiative = (int)AbilityScores.getAbilityScoreModifier("DEX");
        }

    }

    
    /// <summary>Returns a character object where all character customisation steps have been randomised</summary>
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
            GetSpecificCharacterClass(CharacterClass);
            AddRacialProficiencies();
            AddRacialSpells();
            SetSkillsAndSavingThrows();
            SetLevel1HitPoints();
            CalculateArmorClass();
            CalculateInitiative();
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

        /// <summary>sets the CharacterClass variable value as a string representing a random character class<string></summary>
        public void SetRandomClass()
        {
            SetCharacterClass(new CharacterClassList().GetRandomClass());
        }

        public void GetSpecificCharacterClass(string characterClass)
        {
            switch (characterClass)
            {
                default: throw new Exception("Unknown Character Class provided as argument");
                case "Bard": ClassDetails = new Bard();break;
                case "Barbarian": ClassDetails = new Barbarian();break;
                case "Cleric": ClassDetails = new Cleric();break;
                case "Fighter": ClassDetails = new Fighter();break;
                case "Monk": ClassDetails = new Monk();break;
                case "Paladin": ClassDetails = new Paladin();break;
                case "Ranger": ClassDetails = new Ranger();break;
                case "Rogue": ClassDetails = new Rogue();break;
                case "Sorcerer": ClassDetails = new Sorcerer();break;
            }
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

    }

}