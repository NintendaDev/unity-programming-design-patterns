namespace Example08.Attributes
{
    public class Force : AttributeValue, IForce
    {
        public Force(int maxValue) : base(maxValue)
        {
        }
    }
}
