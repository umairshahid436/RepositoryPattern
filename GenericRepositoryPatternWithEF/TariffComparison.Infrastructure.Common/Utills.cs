using System;
namespace TariffComparison.Infrastructure.Common
{
    public static class Utills
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        
    }
}
