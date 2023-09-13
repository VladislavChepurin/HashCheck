namespace HashCheck.Extension
{
    internal static class ConvertByte
    {
        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB
        }

        public static string ToSize(this long value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit)).ToString("0.00");
        }
    }
}
