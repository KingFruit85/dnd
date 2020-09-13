using System;
using System.Linq;

namespace Names 
{

    public class NameLists
    {
    private string[] MaleFirstNames = {"Christopher", "Aaron", "Noah", "David"};
    private string[] FemaleFirstNames = {"Kelly", "Magda", "Sophia", "Persephone"};
    private string[] LastNames = {"Long", "Araniseli", "Smith", "Jones", "Peters"};

    public string[] GetRandomName(string gender)
    {
        string[] FullName = new string[2];
        FullName[0] = GetRandomFirstName(gender);
        FullName[1] = GetRandomLastName();
        return FullName;
    }

    public string GetRandomFirstName(string gender)
    {
        if (gender == "Male")
        {
            Random r = new Random();
            int i = r.Next(0,MaleFirstNames.Length);
            return MaleFirstNames[i];
        }
        else if (gender == "Female")
        {
            Random r = new Random();
            int i = r.Next(0,FemaleFirstNames.Length);
            return FemaleFirstNames[i];
        }
        else
        {
            //--Non-Binary gender option. Maybe I should add some cooler names in here, but for the mean time this should do
            var combinedFirstNameList = MaleFirstNames.Concat(FemaleFirstNames).ToArray();
            Random r = new Random();
            int i = r.Next(0,combinedFirstNameList.Length);
            return combinedFirstNameList[i]; 
        }

    }

        public string GetRandomLastName()
    {
        Random r = new Random();
        int i = r.Next(0,LastNames.Length);
        return LastNames[i];
    }


    }

}