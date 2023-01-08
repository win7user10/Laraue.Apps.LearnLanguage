namespace Laraue.Apps.LearnLanguage.Common.Extensions;

public static class DoubleExtensions
{
    private static double DivideAndReturnPercent(this double value, double delimiter)
    {
        return delimiter == 0
            ? 0
            : value / delimiter * 100;
    }
    
    public static double DivideAndReturnPercent(this int value, double delimiter)
    {
        return DivideAndReturnPercent((double) value, delimiter);
    }
}