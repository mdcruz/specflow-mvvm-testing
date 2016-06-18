using System;

namespace WpfMvvmExampleView.Utils
{
    public static class EnumUtil
    {
        public static Nullable<TEnum> Parse<TEnum>(this String value) where TEnum : struct
        {
            TEnum enumResult;

            if(Enum.TryParse(value, out enumResult))
                return (TEnum)Enum.Parse(typeof(TEnum), value);

            return null;
        }
    }
}
