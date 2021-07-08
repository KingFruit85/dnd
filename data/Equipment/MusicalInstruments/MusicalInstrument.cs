using Newtonsoft.Json;

public class MusicalInstrument
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