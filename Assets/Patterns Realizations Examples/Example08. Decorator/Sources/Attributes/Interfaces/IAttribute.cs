namespace Example08.Attributes
{
    public interface IAttribute
    {
        public int MaxValue { get; }

        public int Value { get; }

        public void Increase(int value);

        public void Decrease(int value);
    }
}
