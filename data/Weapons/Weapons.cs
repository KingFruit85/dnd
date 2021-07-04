using Character;
using Newtonsoft.Json;

public class SimpleWeapon : Equipment
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("damage")]
        public string Damage { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("roperties")]
        public string Roperties { get; set; }

        [JsonProperty("properties")]
        public string Properties { get; set; }
    }

    public class MartialMeleeWeapon : Equipment
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
    }

    public class MartialRangedWeapon : Equipment
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
    }

    public class SimpleRangedWeapon : Equipment
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
    }