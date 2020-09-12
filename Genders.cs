using System;

namespace Genders
{
    class GenderList
    {
        public string[] Genders = {"Male", "Female", "Non-Binary"};

        public string GetRandomGender()
        {
            Random r = new Random();
            int i = r.Next(0,Genders.Length);
            return Genders[i];
        }
    
    }
    
}