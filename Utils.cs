using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using static Character.GenericRace;

namespace Character
{
    public class Tools
    {
    
    /// <summary>Saves the provided character to the exports folder<string></summary>
    /// <param name="characterToSave">the character to save<string></param>
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

    /// <summary>Returns a random element from the provided list<string></summary>
    /// <param name="list">the list of type <string></param>
    public static string GetRandomListElement(List<string> list)
    {
        return list[new Random().Next(0,list.Count)];
    }

    /// <summary>Returns a random element from the provided list<DraconicAncestryDetails></summary>
    /// <param name="list">the list of type <DraconicAncestryDetails></param>
    public static DraconicAncestryDetails GetRandomListElement(List<DraconicAncestryDetails> list)
    {
        var R = new Random();
        var i = R.Next(0,list.Count);
        return list[i];
    }

    /// <summary>Returns a random number between the two provided numbers</summary>
    /// <param name="start">an int represnting the small number</param>
    /// <param name="end">an int represnting the large number</param>
    public static int GetRandomNumberInRange(int start, int end)
    {
        return new Random().Next(start,end + 1);
    }

    /// <summary>Shuffles the provided list in a random order and returns it</summary>
    /// <param name="list">the list of type <string> to be shuffled</param>
    public static List<string> ShuffleList(List<string> list)
    {
        return list.OrderBy(i => new Random().Next()).ToList();
    }

    /// <summary>Shuffles the provided list in a random order and returns it</summary>
    /// <param name="list">the list of type <Weapon> to be shuffled</param>
    public static List<Weapon> ShuffleList(List<Weapon> list)
    {
        Random r = new Random();
        return list.OrderBy(i => r.Next()).ToList();
    }

    /// <summary>Shuffles the provided list in a random order and returns it</summary>
    /// <param name="list">the list of type <ArtisansTools> to be shuffled</param>
    public static List<ArtisansTools> ShuffleList(List<ArtisansTools> list)
    {
        Random r = new Random();
        return list.OrderBy(i => r.Next()).ToList();
    }

    /// <summary>Shuffles the provided list in a random order and returns it</summary>
    /// <param name="list">the list of type <MusicalInstrument> to be shuffled</param>
    public static List<MusicalInstrument> ShuffleList(List<MusicalInstrument> list)
    {
        Random r = new Random();
        return list.OrderBy(i => r.Next()).ToList();
    }

    /// <summary>return a random spell from a list<string> provided as a param</summary>
    /// <param name="spellList">the list of strings that represent spells</param>
    public static Spells ReturnRandomSpell(List<string> spellList)
    {
        // Get a ref to all the SRD spells
        var AllSpells = new Spells().ReturnSpellList();

        // Pick a spell from the provided list and return it
        Random r = new Random();
        var spellListLength = spellList.Count;
        var randomIndex = r.Next(0,spellList.Count);
        string randomSpell = spellList[r.Next(0,spellList.Count)].Trim(); 
        Spells pickedSpell = AllSpells.Spells.Where(s => s.Name == randomSpell).ToList()[0];
        
        return pickedSpell;

    }

    public static Spells ReturnSpecificSpell(string spellToReturn)
    {
        try
        {
            return new Spells().ReturnSpellList().Spells.Where(s => s.Name == spellToReturn).ToList()[0];
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException("spell not recognised");
        }
    }

    public static List<Spells> ReturnXSpellsFromList(List<string> spellList,int count)
    {
        var spells = new List<Spells>();

        for (int i = 1; i <= count; i++)
        {   
            var found = false;

            // Pick a random spell from the provided list
            var pickedSpell = ReturnRandomSpell(spellList);
            // Ignore and loop again if already picked
            if (spells.Count > 0)
            {
                foreach (var spell in spells)
                {
                    if (spell.Name == pickedSpell.Name)
                    {
                        found = true;
                        i--;
                    }                    
                }

                if (!found)
                {
                    spells.Add(pickedSpell);
                }

            }
            else
            {
                spells.Add(pickedSpell);
            }

        }
            return spells;
    }
    }
    }


    
