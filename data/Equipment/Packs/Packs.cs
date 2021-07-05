using Newtonsoft.Json;

namespace Character
{
    public class EquipmentPack : Equipment
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}