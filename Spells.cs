namespace Spells
{
    public class Spell
    {
        public string Name;
        public string Description;
        public int BaseSpellLevel;

        public Spell(string name, string description, int baseSpellLevel)
        {
            this.Name = name;
            this.Description = description;
            this.BaseSpellLevel = baseSpellLevel;

        }

    }
}