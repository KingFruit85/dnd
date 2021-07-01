using System.Collections.Generic;

namespace Character
{
    public class EquipmentTemplate
    {
        public string Name;
        public string Description;
        public string Cost;
        public string Weight;
        
    }

    public class MusicalInstrument : EquipmentTemplate
    {

        public MusicalInstrument(string equipmentName)
        {

            switch (equipmentName)
            {
                default: throw new System.Exception("unknown instrument name");
                case "Bagpipes": Name = "Bagpipes"; Cost = "30 gp"; Weight = "6lb";break;
                case "Drum": Name = "Drum"; Cost = "6 gp"; Weight = "6lb";break;
                case "Dulcimer": Name = "Dulcimer"; Cost = "25 gp"; Weight = "6lb";break;
                case "Flute": Name = "Flute"; Cost = "2 gp"; Weight = "6lb";break;
                case "Lute": Name = "Lute"; Cost = "35 gp"; Weight = "6lb";break;
                case "Lyre": Name = "Lyre"; Cost = "30 gp"; Weight = "6lb";break;
                case "Horn": Name = "Horn"; Cost = "3 gp"; Weight = "6lb";break;
                case "Pan Flute": Name = "Pan Flute"; Cost = "12 gp"; Weight = "6lb";break;
                case "Shawm": Name = "Shawm"; Cost = "2 gp"; Weight = "6lb";break;
                case "Viol": Name = "Viol"; Cost = "30 gp"; Weight = "6lb";break;
            }

            
        }


    }

    
}