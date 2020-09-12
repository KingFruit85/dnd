using System;
using Names;
using Races;
using CharacterClasses;
using Genders;

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
        private int Level = 1;

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

        public void SetRandomName()
        {
            NameLists name = new NameLists();
            this.FirstName = name.GetRandomFirstName();
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

        public void Randomise()
        {
            SetRandomRace();
            SetRandomName();
            SetRandomClass();
            SetRandomGender();
        }

        public void PrintCharacterInfoToConsole()
        {
            Console.WriteLine($"Name:{FirstName} {LastName}. Race:{Race} Class:{CharacterClass}" );
        }


    }
}