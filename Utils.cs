using System;

    public class Tools
    {
    public static string GetRandomStringArrayElement(string[] array)
    {
        var R = new Random();
        var i = R.Next(0,array.Length);
        return array[i];
    }

    public static int GetRandomNumberInRange(int start, int end)
    {
        var R = new Random();
        var i = R.Next(start,end);
        return i;
    }

    }
    
