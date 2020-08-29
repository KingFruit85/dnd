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
        Random rand = new Random();

        int FIndex = rand.Next(0 , FirstNames.Length);
        int LIndex = rand.Next(0 , LastNames.Length);

        FullName[0] = FirstNames[FIndex];
        FullName[1] = LastNames[LIndex];

        return FullName;

    }


    }

}