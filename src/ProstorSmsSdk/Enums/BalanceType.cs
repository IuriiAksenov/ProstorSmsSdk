using System;

namespace ProstorSmsSdk.Enums
{
    public static class BalanceTypeConverter
    {
        public static BalanceType FromString(string type)
        {
            return type switch
            {
                "RUB" => BalanceType.Rub,
                "SMS" => BalanceType.Sms,
                _ => throw new ArgumentOutOfRangeException($"BalanceType has not value: '{type}'")
            };
        }
    }

    public enum BalanceType
    {
        Rub,
        Sms
    }
}