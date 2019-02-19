using System;

using DateTimeExtensions;

namespace SharedLibrary
{
    public static class ToStringConversions
    {
        public static string LocalTime(this DateTime dt) => dt.ToString("HH:mm");
        public static string LocalTime(this DateTimeOffset dt) => dt.ToString("HH:mm");
        public static string LocalDate(this DateTime dt) => dt.ToString("dd/MM/yyyy");
        public static string LocalDate(this DateTimeOffset dt) => dt.ToString("dd/MM/yyyy");
        public static string LocalDateTime(this DateTime dt) => dt.ToString("dd/MM/yyyy HH:mm");
        public static string LocalDateTime(this DateTimeOffset dt) => dt.ToString("dd/MM/yyyy HH:mm");
        public static string Natural(this DateTime dt) => dt.ToNaturalText(DateTime.Now);
        public static string Natural(this DateTimeOffset dt) => dt.DateTime.Natural();
        public static string NaturalExact(this DateTime dt) => dt.ToExactNaturalText(DateTime.Now);
        public static string NaturalExact(this DateTimeOffset dt) => dt.DateTime.Natural();
        public static string Timestamp(this DateTime dt) => dt.ToString("yyyyMMddHHmmss");
    }
}
