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

    public class RandomCharacter : CharacterTemplate
    {
        public void SetRandomRace()
        {
            var Race = new RaceLists();
            this.Race = Race.GetRandomRace();
        }

        public void SetRandomName(string gender)
        {
            NameLists name = new NameLists();
            this.FirstName = name.GetRandomFirstName(gender);
            this.LastName = name.GetRandomLastName();
        }

        public void SetRandomClass()
        {
            CharacterClassList classList = new CharacterClassList();
            this.CharacterClass = classList.GetRandomClass();
        }

        public void SetRandomGender()
        {
            GenderList genderList = new GenderList();
            this.Gender = genderList.GetRandomGender();
        }

        public void SetAbilityScores()
        {
            DiceTypes DT = new DiceTypes();
            this.AbilityScores = DT.ReturnAbilityScores();
            
        }

        public void Randomise()
        {
            SetRandomRace();
            SetRandomGender();
            SetRandomName(this.Gender);
            SetRandomClass();
            SetAbilityScores();
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