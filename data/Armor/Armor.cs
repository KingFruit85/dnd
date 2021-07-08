using Newtonsoft.Json;

    public class Armor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Cost")]
        public string Cost { get; set; }

        [JsonProperty("baseArmorClass")]
        public int BaseArmorClass { get; set; }

        [JsonProperty("additionalModifier")]
        public string AdditionalModifier { get; set; }

        [JsonProperty("modifierLimit")]
        public object ModifierLimit { get; set; }

        [JsonProperty("strengthRequirement")]
        public bool StrengthRequirement { get; set; }

        [JsonProperty("strengthRequirementValue")]
        public object StrengthRequirementValue { get; set; }

        [JsonProperty("stealthDisadvantage")]
        public bool StealthDisadvantage { get; set; }

        [JsonProperty("Weight")]
        public int Weight { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }



