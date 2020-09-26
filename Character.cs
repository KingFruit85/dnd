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
        private AbilityScore AbilityScores = new AbilityScore();


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
        public void SetAbilityScores(){}

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
            GetAbilityScores().Arrange(GetCharacterClass());
            SetRandomGender();
            SetRandomName(GetGender(), GetRace().GetName());
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


        public void UpdateAbilityScores(int[] rawScores)
        {


            // this.UpdatedAbilityScores = results;
            
        }

        public void PrintCharacterInfoToConsole()
        {
            Console.WriteLine("*-Character Attributes-*");
            Console.WriteLine($"Name:{GetFirstName()} {GetLastName()}");
            Console.WriteLine($"Class:{GetCharacterClass()}");
            Console.WriteLine($"Gender:{GetGender()}");
            //Console.WriteLine($"Raw Scores: [{GetRawAbilityScores()[0]}] [{GetRawAbilityScores()[1]}] [{GetRawAbilityScores()[2]}] [{GetRawAbilityScores()[3]}] [{GetRawAbilityScores()[4]}] [{GetRawAbilityScores()[5]}]");
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