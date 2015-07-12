public static class Parameters
{
    public static double ConsumeMinutesWhenPriceEqualsValue = 10;

    public static double CalcPriceFromValue(double value, double amount, double consumePerMinute)
    {
        return value*(ConsumeMinutesWhenPriceEqualsValue + 1)/(amount/consumePerMinute + 1);
    }

    public static float TownSettleIntervalSeconds = 1;
}