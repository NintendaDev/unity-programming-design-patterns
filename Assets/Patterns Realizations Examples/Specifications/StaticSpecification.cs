namespace Specifications
{
    public static class StaticSpecification
    {
        private static IntGreatOrEqualZeroSpecification _intGreatOrEqualZeroSpecification = new();

        public static void ValidateIntGreatOrEqualZero(int value)
        {
            if (_intGreatOrEqualZeroSpecification.IsSatisfiedBy(value) == false)
                throw new System.Exception("The value cannot be less than 0");
        }
    }
}