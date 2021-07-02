using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace Character
{

    public class Root
    {
        [JsonProperty("MusicalInstruments")]
        public List<MusicalInstrument> MusicalInstruments { get; set; }

        [JsonProperty("lightArmor")]
        public List<LightArmor> LightArmor { get; set; }

        [JsonProperty("mediumArmor")]
        public List<MediumArmor> MediumArmor { get; set; }

        [JsonProperty("heavyArmor")]
        public List<HeavyArmor> HeavyArmor { get; set; }
    }

    public class Equipment
    {

        public Root Armor()
        {
            // you get stuff out of here with the following code 
            // var a = new Equipment().Armor().HeavyArmor.Where(a => a.Name == "Chain Mail").ToArray();
            var armor = File.ReadAllText(@".\data\Armor\armor.json");
            return JsonConvert.DeserializeObject<Root>(armor);
        }

        public Root MusicalInstrument()
        {
            var instruments = File.ReadAllText(@".\data\Equipment\MusicalInstruments\MusicalInstruments.json");
            return  JsonConvert.DeserializeObject<Root>(instruments);
        }


    }

    
}