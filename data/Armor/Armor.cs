using Newtonsoft.Json;

    public class LightArmor
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

    public class MediumArmor
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
        public int? ModifierLimit { get; set; }

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

    public class HeavyArmor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Cost")]
        public string Cost { get; set; }

        [JsonProperty("baseArmorClass")]
        public string BaseArmorClass { get; set; }

        [JsonProperty("strengthRequirement")]
        public bool StrengthRequirement { get; set; }

        [JsonProperty("strengthRequirementValue")]
        public int? StrengthRequirementValue { get; set; }

        [JsonProperty("stealthDisadvantage")]
        public bool StealthDisadvantage { get; set; }

        [JsonProperty("Weight")]
        public int Weight { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("additionalModifier")]
        public object AdditionalModifier { get; set; }
    }


