namespace Example08.Stats
{
    public interface IStats
    {
        public int MaxForce { get; }

        public int Force { get; }

        public int MaxIntelligence { get; }

        public int Intelligence { get; }

        public int MaxDexterity { get; }

        public int Dexterity { get; }

        public void IncreaseForce(int value);

        public void DecreaseForce(int value);

        public void IncreaseIntelligence(int value);

        public void DecreaseIntelligence(int value);

        public void IncreaseDexterity(int value);

        public void DecreaseDexterity(int value);
    }
}
