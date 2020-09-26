using System;
using Names;
using CharacterClasses;
using System.Linq;
using System.Collections.Generic;
using Races;

namespace Character
{
    public class CharacterTemplate
    {
        
        private GenericRace Race;
        private string FirstName;
        private string LastName;
        private string CharacterClass;
        private string Gender;
        private int[] RawAbilityScores;
        private AbilityScore UpdatedAbilityScores = new AbilityScore();

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

        public int[] GetRawAbilityScores(){return RawAbilityScores;}
        public void SetRawAbilityScores(int[] scores){RawAbilityScores = scores;}

        public AbilityScore GetUpdatedAbilityScores(){return UpdatedAbilityScores;}
        public void SetUpdatedAbilityScores(AbilityScore scores){UpdatedAbilityScores = scores;}
    }

    public class ManualCharacter : CharacterTemplate
    {
        

    }

    // -- Returns a character object where all character customisation steps have been randomised
    public class RandomCharacter : CharacterTemplate
    {
        public RandomCharacter()
        {
            SetRandomRace();
            SetRandomClass();
            SetAbilityScores();
            SetRandomGender();
            SetRandomName(GetGender(), GetRace().GetName());
            UpdateAbilityScores(GetRawAbilityScores());
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

        public void SetAbilityScores()
        {
            SetRawAbilityScores(new DiceTypes().ReturnAbilityScores()); 
        }

        public void UpdateAbilityScores(int[] rawScores)
        {
            var character = GetCharacterClass();
            var results = new Dictionary<string,int>();

            // rawScores should return a list of ints in decending order

            switch (character)
            {   
                case "Bard":
                    results.Add("CHA",rawScores[0]);
                    results.Add("DEX",rawScores[1]);
                    results.Add("CON",rawScores[2]);
                    results.Add("WIS",rawScores[3]);
                    results.Add("STR",rawScores[4]);
                    results.Add("INT",rawScores[5]);
                    break;

                
                default: throw new Exception("program fell through switchcase");
            }

            // this.UpdatedAbilityScores = results;
            
        }

        public void PrintCharacterInfoToConsole()
        {
            Console.WriteLine("*-Character Attributes-*");
            Console.WriteLine($"Name:{GetFirstName()} {GetLastName()}");
            Console.WriteLine($"Class:{GetCharacterClass()}");
            Console.WriteLine($"Gender:{GetGender()}");
            Console.WriteLine($"Raw Scores: [{GetRawAbilityScores()[0]}] [{GetRawAbilityScores()[1]}] [{GetRawAbilityScores()[2]}] [{GetRawAbilityScores()[3]}] [{GetRawAbilityScores()[4]}] [{GetRawAbilityScores()[5]}]");
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