public static class FormatLargeNumber
{
    private const int K = 1000;
    private const int M = 1_000_000;
    private const int B = 1_000_000_000;

    public static string ModificationInt(int integer)
    {
        return integer switch
        {
            >= B => $"{integer / B:F1}B",  // Форматирование с одной дробной цифрой
            >= M => $"{integer / M:F1}M",
            >= K => $"{integer / K:F1}K",
            _ => integer.ToString()
        };
        var displayText = integer switch
        {
            >= B => integer / B + "." + integer % B / (B / 10) + " B",
            >= M => integer / M + "." + integer % M / (M / 10) + "M",
            >= K => integer / K + "." + integer % K / (K / 10) + "K",
            _ => integer.ToString()
        };
        return displayText;
    }
}

