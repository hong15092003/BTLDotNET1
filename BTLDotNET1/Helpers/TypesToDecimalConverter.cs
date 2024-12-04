namespace BTLDotNET1.Helpers
{
    public static class TypesToDecimalConverter
    {

        public static decimal ToDecimal(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value switch
            {
                int intValue => (decimal)intValue,
                float floatValue => (decimal)floatValue,
                double doubleValue => (decimal)doubleValue,
                long longValue => (decimal)longValue,
                short shortValue => (decimal)shortValue,
                byte byteValue => (decimal)byteValue,
                string stringValue => decimal.TryParse(stringValue, out decimal result) ? result : throw new InvalidCastException("The string could not be converted to a decimal."),
                _ => throw new InvalidCastException($"The type {value.GetType()} is not supported for conversion to decimal.")
            };
        }

    }
}
