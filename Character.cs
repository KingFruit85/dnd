using System;
using Names;
using Races;
using CharacterClasses;
using Genders;
using Dice;

namespace Character
{
    public class CharacterTemplate
    {
        private string _race;
        public string Race
        {
            get
            {
                return _race;
            }
            set
            {
                _race = value;
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        private string _characterClass;
        public string CharacterClass
        {
            get
            {
                return _characterClass;
            }
            set
            {
                _characterClass = value;
            }
        }

        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        private int[] _abilityScores;

        public int[] AbilityScores
        {
            get
            {
                return _abilityScores;
            }
            set
            {
                if (value.Length == 6)
                {
                    _abilityScores = value;
                }
                else
                {
                    throw new Exception("Provided ability score array does not contain the correct number of values");
                }
                
            }
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
            SetRandomRace();
            SetRandomGender();
            SetRandomName(this.Gender, this.Race);
            SetRandomClass();
            SetAbilityScores();
        }

        public void SetRandomRace()
        {
            this.Race = new RaceLists().GetRandomRace();
        }

        public void SetRandomName(string gender, string race)
        {
            NameLists name = new NameLists();
            var FullName = name.SetRandomName(gender, race);
            this.FirstName = FullName[0];
            this.LastName = FullName[1];
        }

        public void SetRandomClass()
        {
            this.CharacterClass = new CharacterClassList().GetRandomClass();
        }

        public void SetRandomGender()
        {
            this.Gender = new GenderList().GetRandomGender();
        }

        public void SetAbilityScores()
        {
            this.AbilityScores = new DiceTypes().ReturnAbilityScores(); 
        }

        public void PrintCharacterInfoToConsole()
        {
            Console.WriteLine($"Name:{FirstName} {LastName}");
            Console.WriteLine($"Race:{Race}");
            Console.WriteLine($"Class:{CharacterClass}");
            Console.WriteLine($"Gender:{Gender}");
            Console.WriteLine($"Raw Scores: {AbilityScores[0]} {AbilityScores[1]} {AbilityScores[2]} {AbilityScores[3]} {AbilityScores[4]} {AbilityScores[5]}");
        }
    }
}