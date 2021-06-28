using System;
using Character;
using System.Text.Json;

namespace dnd
{
    class MyObj
    {
        public int MyInt {get;set;}
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            RandomCharacter newCharacter = new RandomCharacter();
            newCharacter.PrintCharacterInfoToConsole();

            var myobj = new MyObj(){MyInt = 204};
            var json = JsonSerializer.Serialize(newCharacter);
            Console.WriteLine(json);


        }

        public void saveCharacterToJSON()
        {
            
        }

    }
}

