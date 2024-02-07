namespace Specifications
{
    public static class FloatValidator
    {
        private static FloatGreatOrEqualZeroSpecification _floatGreatOrEqualZeroSpecification = new();

        public static void GreatOrEqualZero(float value)
        {
            if (_floatGreatOrEqualZeroSpecification.IsSatisfiedBy(value) == false)
                throw new System.Exception("The value cannot be less than 0");
        }
    }
}