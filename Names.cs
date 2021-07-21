using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Names 
{

    public class NameLists
    {
    
    public string RemoveAllVowels(string value)
    {
        return Regex.Replace(value,"[aeiou]", "", RegexOptions.IgnoreCase);
    }
    
    // -- Dragonborn
    private string[] FemaleDragonbornNames = {"Kathyra", "Aririth", "Welsidalynn"};
    private string[] MaleDragonbornNames = {"Narvull", "Urobroth", "Qelziros"};
    private string[] DragonbornSurnames = {"Clenxec", "Aldexish", "Criracnellas"};

    public string GetRandomDragonbornFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleDragonbornNames.Length);
            return MaleDragonbornNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleDragonbornNames.Length);
            return FemaleDragonbornNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleDragonbornNames.Concat(FemaleDragonbornNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomDragonbornSurnameName()
    {
        int i = new Random().Next(0, DragonbornSurnames.Length);
        return DragonbornSurnames[i];
    }

    // -- Human
    private string[] MaleHumanNames = {"Christopher", "Aaron", "Noah", "David", "Jeremiah"};
    private string[] FemaleHumanNames = {"Kelly", "Magda", "Sophia", "Persephone"};
    private string[] HumanSurnames = {"Long", "Araniseli", "Smith", "Jones", "Peters", "Shipp"};

    public string GetRandomHumanFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHumanNames.Length);
            return MaleHumanNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHumanNames.Length);
            return FemaleHumanNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleHumanNames.Concat(FemaleHumanNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomHumanSurnameName()
    {
        int i = new Random().Next(0, HumanSurnames.Length);
        return HumanSurnames[i];
    }

    // -- Dwarf
    private string[] MaleDwarfNames = {"Nordak", "Olunt", "Kildrak"};
    private string[] FemaleDwarfNames = {"Amber", "Artin", "Audhild"};
    private string[] DwarfSurnames = {"Balderk", "Battlehammer", "Brawnanvil"};

    public string GetRandomDwarfFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleDwarfNames.Length);
            return MaleDwarfNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleDwarfNames.Length);
            return FemaleDwarfNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleDwarfNames.Concat(FemaleDwarfNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomDwarfSurnameName()
    {
        int i = new Random().Next(0, DwarfSurnames.Length);
        return DwarfSurnames[i];
    }

    // -- Elf
    private string[] MaleElfNames = {"Adran", "Aramil", "Austrin"};
    private string[] FemaleElfNames = {"Arara", "Amastrianna", "Antinua"};
    private string[] ElfSurnames = {"Amakiir", "Caerdnel", "Casilltenirra"};

    public string GetRandomElfFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleElfNames.Length);
            return MaleElfNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleElfNames.Length);
            return FemaleElfNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleElfNames.Concat(FemaleElfNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomElfSurnameName()
    {
        int i = new Random().Next(0, ElfSurnames.Length);
        return ElfSurnames[i];
    }

    // -- Gnome
    private string[] MaleGnomeNames = {"Trutt", "Zod", "Cant"};
    private string[] FemaleGnomeNames = {"Vock", "Huck", "Zuth"};
    private string[] GnomeSurnames = {"Dodlawams", "Hasp", "Epswodnith"};

    public string GetRandomGnomeFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleGnomeNames.Length);
            return MaleGnomeNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleGnomeNames.Length);
            return FemaleGnomeNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleGnomeNames.Concat(FemaleGnomeNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomGnomeSurnameName()
    {
        int i = new Random().Next(0, GnomeSurnames.Length);
        return GnomeSurnames[i];
    }

    // -- HalfElf
    private string[] MaleHalfElfNames = {"Corrune", "Uldyr", "Iancraes"};
    private string[] FemaleHalfElfNames = {"Edecharis", "Narue", "Emfine"};
    private string[] HalfElfSurnames = {"Caiqirelle", "Wynleth", "Elafiel"};

    public string GetRandomHalfElfFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHalfElfNames.Length);
            return MaleHalfElfNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHalfElfNames.Length);
            return FemaleHalfElfNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleHalfElfNames.Concat(FemaleHalfElfNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomHalfElfSurnameName()
    {
        int i = new Random().Next(0, HalfElfSurnames.Length);
        return HalfElfSurnames[i];
    }

    // -- HalfOrc
    private string[] MaleHalfOrcNames = {"Gul", "Hrod", "Doch"};
    private string[] FemaleHalfOrcNames = {"Ruogra", "Zoca", "Geltah"};
    private string[] HalfOrcSurnames = {"Gud", "Orkuv", "Bon"};

    public string GetRandomHalfOrcFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHalfOrcNames.Length);
            return MaleHalfOrcNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHalfOrcNames.Length);
            return FemaleHalfOrcNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleHalfOrcNames.Concat(FemaleHalfOrcNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomHalfOrcSurnameName()
    {
        int i = new Random().Next(0, HalfOrcSurnames.Length);
        return HalfOrcSurnames[i];
    }

    // -- Halfling
    private string[] MaleHalflingNames = {"Lal", "Dar", "Dord"};
    private string[] FemaleHalflingNames = {"Suseh", "Tavot", "Sira"};
    private string[] HalflingSurnames = {"Featherheart", "Hogrirg", "Darkhelm"};

    public string GetRandomHalflingFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHalflingNames.Length);
            return MaleHalflingNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHalflingNames.Length);
            return FemaleHalflingNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleHalflingNames.Concat(FemaleHalflingNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomHalflingSurnameName()
    {
        int i = new Random().Next(0, HalflingSurnames.Length);
        return HalflingSurnames[i];
    }

    // -- Tiefling
    private string[] MaleTieflingNames = {"Hormos", "Nephrut", "Malvir"};
    private string[] FemaleTieflingNames = {"Zecria", "Seiricyra", "Fririssa"};
    private string[] TieflingSurnames = {"Vervend", "Brotaebae", "Tovos"};

    public string GetRandomTieflingFirstName(string gender)
    {

        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleTieflingNames.Length);
            return MaleTieflingNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleTieflingNames.Length);
            return FemaleTieflingNames[f]; 
        }
        else // Non-Binary. Poor implimentation, I need a better soloution
        {
            var combined = MaleTieflingNames.Concat(FemaleTieflingNames).ToArray();
            int q = R.Next(0,combined.Length);
            return RemoveAllVowels(combined[q]); 
        }

    }
    public string GetRandomTieflingSurnameName()
    {
        int i = new Random().Next(0, TieflingSurnames.Length);
        return TieflingSurnames[i];
    }

    public string[] SetRandomName(string gender, string race)
    {
        string[] FullName = new string[2];
        
        switch (race)
        {   
            case "Human":
                FullName[0] = GetRandomHumanFirstName(gender);
                FullName[1] = GetRandomHumanSurnameName();
                break;
            case "Dragonborn":
                FullName[0] = GetRandomDragonbornFirstName(gender);
                FullName[1] = GetRandomDragonbornSurnameName();
                break;
            case "Dwarf":
                FullName[0] = GetRandomDwarfFirstName(gender);
                FullName[1] = GetRandomDwarfSurnameName();
                break;
            case "Elf":
                FullName[0] = GetRandomElfFirstName(gender);
                FullName[1] = GetRandomElfSurnameName();
                break;
            case "Gnome":
                FullName[0] = GetRandomGnomeFirstName(gender);
                FullName[1] = GetRandomGnomeSurnameName();
                break;
            case "Half-Elf":
                FullName[0] = GetRandomHalfElfFirstName(gender);
                FullName[1] = GetRandomHalfElfSurnameName();
                break;
            case "Half-Orc":
                FullName[0] = GetRandomHalfOrcFirstName(gender);
                FullName[1] = GetRandomHalfOrcSurnameName(); 
                break;
            case "Halfling":
                FullName[0] = GetRandomHalflingFirstName(gender);
                FullName[1] = GetRandomHalflingSurnameName();
                break;
            case "Tiefling":
                FullName[0] = GetRandomTieflingFirstName(gender);
                FullName[1] = GetRandomTieflingSurnameName();
                break;
            default: throw new Exception("Invalid arguements passed to GetRandomName method");
        }
        return FullName;
    }
    }

}