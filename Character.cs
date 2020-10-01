using System;
using Names;
using CharacterClasses;
using System.Linq;
using System.Collections.Generic;
using Races;

namespace Character
{
    public abstract class CharacterTemplate
    {
        public ClassFeatures CC;
        
        private GenericRace Race;
        private string FirstName;
        private string LastName;
        private string CharacterClass;
        private string Gender;
        private AbilityScore AbilityScores = new AbilityScore();
        private Dictionary<string,string> Skills;
        private Dictionary<string,string> SavingThrows;


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

        public AbilityScore GetAbilityScores(){return AbilityScores;}
        public void SetAbilityScore(AbilityScore abilityScore)
        {
            AbilityScores = abilityScore;
        }

    }

    public class ManualCharacter : CharacterTemplate
    {
        

    }

    // -- Returns a character object where all character customisation steps have been randomised
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

            CC = new Bard();
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
                   GetAbilityScores().SetProvidedScore(stat.Key,stat.Value);
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