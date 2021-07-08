using Character;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace dnd

{
    class Program
    {
        
        static void Main(string[] args)
        {
            // RandomCharacter newCharacter = new RandomCharacter();
            // saveCharacterToJSON(newCharacter);

            var x = new SpellList().Spells;

            // Why isn't equipment being deserialised?
            // Is it because they are cutom classes?

        }

        public static void saveCharacterToJSON(RandomCharacter characterToSave)
        {
            // Set the path to save the file
            var exportFolderPath = "c:/temp/characterExports/JSON/";
            // Set the file name
            var filename = characterToSave.FirstName + " " + characterToSave.LastName + ".json";

            // Create the JSON string
            var json = JsonSerializer.Serialize(characterToSave, new JsonSerializerOptions {MaxDepth = 64});
            // Format it so it's nice and readable 
            json = JToken.Parse(json).ToString();

            // If directory already exists just save the file
            if (Directory.Exists(exportFolderPath))
            {
                File.WriteAllText(exportFolderPath + filename, json);
            }
            // Else create the folder structure then save the file
            else
            {
                Directory.CreateDirectory(exportFolderPath);
                File.WriteAllText(exportFolderPath + filename, json);
            }
        }

    }
}

