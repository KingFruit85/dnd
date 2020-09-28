using System.Collections.Generic;

namespace Character
{
    public class ClassFeatures
    {
        string Name;
        int HitPoints;
        int ProficiencyBonus;
        
        Dictionary<string,string[]> Proficiencies;
        Dictionary<string,string> Equipment;
        Dictionary<string,string> Spells;
        Dictionary<string,string> Features;

        List<string> Tools;

        public void SetName(string name){Name = name;}
        public string GetName(){return Name;}
        public void SetHitPoints(int hitpoints){HitPoints = hitpoints;}
        public int GetHitPoints(){return HitPoints;}
        public void SetProficiencyBonus(int pb){ProficiencyBonus = pb;}
        public int GetProficiencyBonus(){return ProficiencyBonus;}

        public void SetProficiencies(Dictionary<string,string[]> profs)
        {
            Proficiencies = profs;
        }
        public Dictionary<string,string[]> GetProficiencies()
        {
            return Proficiencies;
        }

        public void SetTools(List<string> tools){Tools = tools;}
        public List<string> GetTools(){return Tools;}
        

    }

    public class Bard : ClassFeatures
    {
        public Bard()
        {
            SetName("Bard");
            SetProficiencyBonus(2);

            // Propulate Proficiencies
            var bardProfs = new Dictionary<string,string[]>()
            {
                {"Armor", new string[]{"Light Armor"}},
                {"Weapons",new string[]{"Simple weapons", "hand crossbows", "longswords", "rapiers", "shortswords"}},
                {"Tools", new string[]{}},
                {"Saving Throws", new string[]{"Dexterity", "Charisma"}},
                {"Skills", new string[]{}}
            
            };

            SetProficiencies(bardProfs);



        }

    } 
    
}