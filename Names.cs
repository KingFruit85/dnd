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

    // Ideally this would include non-gendered first names,
    // however I have no idea what a non-gendered fantasy name
    // might be, so I have made up my own logic as a placeholder
    public string[] GetRandomDragonbornName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleDragonbornNames.Length);
            FullName[0] = MaleDragonbornNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleDragonbornNames.Length);
            FullName[0] = FemaleDragonbornNames[f]; 
        }
        else
        {
            var combined = MaleDragonbornNames.Concat(FemaleDragonbornNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, DragonbornSurnames.Length);
        FullName[1] = DragonbornSurnames[s];

        return FullName;
    }

    // -- Human
    private string[] MaleHumanNames = {"Christopher", "Aaron", "Noah", "David"};
    private string[] FemaleHumanNames = {"Kelly", "Magda", "Sophia", "Persephone"};
    private string[] HumanSurnames = {"Long", "Araniseli", "Smith", "Jones", "Peters"};

    public string[] GetRandomHumanName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHumanNames.Length);
            FullName[0] = MaleHumanNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHumanNames.Length);
            FullName[0] = FemaleHumanNames[f]; 
        }
        else
        {
            var combined = MaleHumanNames.Concat(FemaleHumanNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, HumanSurnames.Length);
        FullName[1] = HumanSurnames[s];

        return FullName;
    }

    // -- Dwarf
    private string[] MaleDwarfNames = {"Nordak", "Olunt", "Kildrak"};
    private string[] FemaleDwarfNames = {"Amber", "Artin", "Audhild"};
    private string[] DwarfSurnames = {"Balderk", "Battlehammer", "Brawnanvil"};

    public string[] GetRandomDwarfName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleDwarfNames.Length);
            FullName[0] = MaleDwarfNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleDwarfNames.Length);
            FullName[0] = FemaleDwarfNames[f]; 
        }
        else
        {
            var combined = MaleDwarfNames.Concat(FemaleDwarfNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, DwarfSurnames.Length);
        FullName[1] = DwarfSurnames[s];

        return FullName;
    }

    // -- Elf
    private string[] MaleElfNames = {"Adran", "Aramil", "Austrin"};
    private string[] FemaleElfNames = {"Arara", "Amastrianna", "Antinua"};
    private string[] ElfSurnames = {"Amakiir", "Caerdnel", "Casilltenirra"};

    public string[] GetRandomElfName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleElfNames.Length);
            FullName[0] = MaleElfNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleElfNames.Length);
            FullName[0] = FemaleElfNames[f]; 
        }
        else
        {
            var combined = MaleElfNames.Concat(FemaleElfNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, ElfSurnames.Length);
        FullName[1] = ElfSurnames[s];

        return FullName;
    }

    // -- Gnome
    private string[] MaleGnomeNames = {"Trutt", "Zod", "Cant"};
    private string[] FemaleGnomeNames = {"Vock", "Huck", "Zuth"};
    private string[] GnomeSurnames = {"Dodlawams", "Hasp", "Epswodnith"};

    public string[] GetRandomGnomeName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleGnomeNames.Length);
            FullName[0] = MaleGnomeNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleGnomeNames.Length);
            FullName[0] = FemaleGnomeNames[f]; 
        }
        else
        {
            var combined = MaleGnomeNames.Concat(FemaleGnomeNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, GnomeSurnames.Length);
        FullName[1] = GnomeSurnames[s];

        return FullName;
    }

    // -- HalfElf
    private string[] MaleHalfElfNames = {"Corrune", "Uldyr", "Iancraes"};
    private string[] FemaleHalfElfNames = {"Edecharis", "Narue", "Emfine"};
    private string[] HalfElfSurnames = {"Caiqirelle", "Wynleth", "Elafiel"};

    public string[] GetRandomHalfElfName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHalfElfNames.Length);
            FullName[0] = MaleHalfElfNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHalfElfNames.Length);
            FullName[0] = FemaleHalfElfNames[f]; 
        }
        else
        {
            var combined = MaleHalfElfNames.Concat(FemaleHalfElfNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, HalfElfSurnames.Length);
        FullName[1] = HalfElfSurnames[s];

        return FullName;
    }

    // -- HalfOrc
    private string[] MaleHalfOrcNames = {"Gul", "Hrod", "Doch"};
    private string[] FemaleHalfOrcNames = {"Ruogra", "Zoca", "Geltah"};
    private string[] HalfOrcSurnames = {"Gud", "Orkuv", "Bon"};

        public string[] GetRandomHalfOrcName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHalfOrcNames.Length);
            FullName[0] = MaleHalfOrcNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHalfOrcNames.Length);
            FullName[0] = FemaleHalfOrcNames[f]; 
        }
        else
        {
            var combined = MaleHalfOrcNames.Concat(FemaleHalfOrcNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, HalfOrcSurnames.Length);
        FullName[1] = HalfOrcSurnames[s];

        return FullName;
    }

    // -- Halfling
    private string[] MaleHalflingNames = {"Lal", "Dar", "Dord"};
    private string[] FemaleHalflingNames = {"Suseh", "Tavot", "Sira"};
    private string[] HalflingSurnames = {"Featherheart", "Hogrirg", "Darkhelm"};

    public string[] GetRandomHalflingName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleHalflingNames.Length);
            FullName[0] = MaleHalflingNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleHalflingNames.Length);
            FullName[0] = FemaleHalflingNames[f]; 
        }
        else
        {
            var combined = MaleHalflingNames.Concat(FemaleHalflingNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, HalflingSurnames.Length);
        FullName[1] = HalflingSurnames[s];

        return FullName;
    }

    // -- Tiefling
    private string[] MaleTieflingNames = {"Hormos", "Nephrut", "Malvir"};
    private string[] FemaleTieflingNames = {"Zecria", "Seiricyra", "Fririssa"};
    private string[] TieflingSurnames = {"Vervend", "Brotaebae", "Tovos"};

    public string[] GetRandomTieflingName(string gender)
    {
        string[] FullName = new string[2];
        Random R = new Random();

        if (gender == "Male")
        {
            int m = R.Next(0, MaleTieflingNames.Length);
            FullName[0] = MaleTieflingNames[m];
        }
        else if (gender == "Female")
        {
            int f = R.Next(0, FemaleTieflingNames.Length);
            FullName[0] = FemaleTieflingNames[f]; 
        }
        else
        {
            var combined = MaleTieflingNames.Concat(FemaleTieflingNames).ToArray();
            int q = R.Next(0,combined.Length);
            FullName[0] = RemoveAllVowels(combined[q]); 
        }

        // Surname isn't gendered...right?
        int s = R.Next(0, TieflingSurnames.Length);
        FullName[1] = TieflingSurnames[s];

        return FullName;
    }

    public string[] SetRandomName(string gender, string race)
    {

        switch (race)
        {   
            case "Human": return GetRandomHumanName(gender);
            case "Dragonborn": return GetRandomHumanName(gender);
            case "Dwarf": return GetRandomHumanName(gender);
            case "Elf": return GetRandomHumanName(gender);
            case "Gnome": return GetRandomHumanName(gender);
            case "HalfElf": return GetRandomHumanName(gender);
            case "HalfOrc": return GetRandomHumanName(gender);
            case "Halfling": return GetRandomHumanName(gender);
            case "Tiefling": return GetRandomHumanName(gender);
            default: throw new Exception("Invalid arguements passed to GetRandomName method");
        }
    }
    }

}