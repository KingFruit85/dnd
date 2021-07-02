using System.IO;
using Character;
using Newtonsoft.Json;

public class MusicalInstrument : Equipment
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

    }