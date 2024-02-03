namespace Example08.Attributes
{
    public class Intelligence : AttributeValue, IIntelligence
    {
        public Intelligence(int maxValue) : base(maxValue)
        {
        }
    }
}
