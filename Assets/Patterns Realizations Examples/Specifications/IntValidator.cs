namespace Specifications
{
    public static class IntValidator
    {
        private static IntGreatOrEqualZeroSpecification _intGreatOrEqualZeroSpecification = new();
        private static IntGreatOrEqualOneSpecification _intGreatOrEqualOneSpecification = new();
        private static IntBetweenZeroAndOneSpecification _intBetweenZeroAndOneSpecification = new();

        public static void GreatOrEqualZero(int value)
        {
            if (_intGreatOrEqualZeroSpecification.IsSatisfiedBy(value) == false)
                throw new System.Exception("The value cannot be less than 0");
        }

        public static void GreatOrEqualOne(int value)
        {
            if (_intGreatOrEqualOneSpecification.IsSatisfiedBy(value) == false)
                throw new System.Exception("The value cannot be less than 1");
        }

        public static void BetweenZeroAndOne(int value)
        {
            if (_intBetweenZeroAndOneSpecification.IsSatisfiedBy(value) == false)
                throw new System.Exception("The value must be between 0 and 1");
        }
    }
}