using Newtonsoft.Json;

public class Weapon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("damage")]
        public string Damage { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("properties")]
        public string Properties { get; set; }

        [JsonProperty("weaponType")]
        public string WeaponType { get; set; }
        
        [JsonProperty("twohanded")]
        public bool Twohanded { get; set; }
    }