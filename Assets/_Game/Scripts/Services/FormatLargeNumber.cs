namespace _Game.Scripts.Services
{
    public static class FormatLargeNumber
    {
        private const int K = 1000;
        private const int M = 1_000_000;
        private const int B = 1_000_000_000;

        public static string ModificationInt(int integer)
        {
            return integer switch
            {
                >= B => $"{integer / B:F1}B",
                >= M => $"{integer / M:F1}M",
                >= K => $"{integer / K:F1}K",
                _ => integer.ToString()
            };
        }
    }
}

