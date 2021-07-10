namespace Character
{
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GainedAtLevel { get; set; }

        public Feature( string name, string description, int gainedAtLevel )
        {
            Name = name;
            Description = description;
            GainedAtLevel = gainedAtLevel;
        }
    }
}