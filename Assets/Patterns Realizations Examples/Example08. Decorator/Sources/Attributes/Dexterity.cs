namespace Example08.Attributes
{
    public class Dexterity : AttributeValue, IDexterity
    {
        public Dexterity(int maxValue) : base(maxValue)
        {
        }
    }
}
