using System;
using System.Collections.Generic;
using System.Linq;
using Races;
using static Races.GenericRace;

namespace Utils

{
    public class Tools
    {
    public static string GetRandomStringArrayElement(string[] array)
    {
        var R = new Random();
        var i = R.Next(0,array.Length);
        return array[i];
    }

    public static GenericRace GetRandomRaceArrayElement(GenericRace[] array)
    {
        var R = new Random();
        var i = R.Next(0,array.Length);
        return array[i];
    }

    public static string GetRandomListElement(List<string> list)
    {
        var R = new Random();
        var i = R.Next(0,list.Count);
        return list[i];
    }

    public static DraconicAncestryDetails GetRandomListElement(List<DraconicAncestryDetails> list)
    {
        var R = new Random();
        var i = R.Next(0,list.Count);
        return list[i];
    }

    public static int GetRandomNumberInRange(int start, int end)
    {
        var R = new Random();
        var i = R.Next(start,end);
        return i;
    }

    public static List<string> ShuffleList(List<string> list)
    {
        Random r = new Random();
        return list.OrderBy(i => r.Next()).ToList();
    }

    public static List<Weapon> ShuffleList(List<Weapon> list)
    {
        Random r = new Random();
        return list.OrderBy(i => r.Next()).ToList();
    }

    }

}

    
