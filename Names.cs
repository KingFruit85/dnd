using System;

namespace Names 
{

    public class NameLists
    {
    private string[] FirstNames = {"Christopher", "Aaron", "Noah", "Kelly", "Magda", "David"};
    private string[] LastNames = {"Long", "Araniseli", "Smith", "Jones", "Peters"};

    public string[] GetRandomName()
    {
        string[] FullName = new string[2];
        FullName[0] = GetRandomFirstName();
        FullName[1] = GetRandomLastName();
        return FullName;
    }

    public string GetRandomFirstName()
    {
        Random r = new Random();
        int i = r.Next(0,FirstNames.Length);
        return FirstNames[i];
    }

        public string GetRandomLastName()
    {
        Random r = new Random();
        int i = r.Next(0,LastNames.Length);
        return LastNames[i];
    }


    }

}