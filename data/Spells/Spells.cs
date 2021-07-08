using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SpellList
    {
        [JsonProperty("spells")]
        public List<Spells> Spells {get; set;}
    }

public class Spells
{
    [JsonProperty("name")]
    public string Name { get;set; }

    [JsonProperty("casting_time")]
    public string CastingTime { get;set; }

    [JsonProperty("components")]
    public string Components { get;set; }

    [JsonProperty("description")]
    public string Description { get;set; }

    [JsonProperty("duration")]
    public string Duration { get;set; }

    [JsonProperty("level")]
    public int level { get;set; }

    [JsonProperty("range")]
    public string Range { get;set; }

    [JsonProperty("school")]
    public string School { get;set; }

    public SpellList ReturnSpellList()
    {
        var spells = File.ReadAllText(@".\data\Spells\Spells.json");
        return JsonConvert.DeserializeObject<SpellList>(spells);
    }
    
    
}