namespace Core.Constant
{
    public class TimeUtil
    {
        public enum TIME_UNIX
        {
            MINUTE = 60,
            HOUR = MINUTE * 60,
            SEVEN_HOUR = HOUR * 7,
            DAY = HOUR * 24,
            WEEK = DAY * 7,
        }

        public struct TIMEZONE_ID
        {
            public const string GMT7 = "SE Asia Standard Time";
            public const string GMT0 = "Greenwich Standard Time";
        }

        public static string GetTimeString(DateTime createdAt)
        {
            createdAt = createdAt.AddHours(-2);
            TimeSpan timeDifference = DateTime.Now - createdAt;
            string result;
            if (timeDifference.TotalMinutes < 1)
            {
                result = "vừa xong";
            }
            else if (timeDifference.TotalHours < 1)
            {
                int minutesAgo = (int)timeDifference.TotalMinutes;
                result = $"{minutesAgo} {(minutesAgo > 1 ? "phút" : "phút")} trước";
            }
            else if (timeDifference.TotalDays < 1)
            {
                int hoursAgo = (int)timeDifference.TotalHours;
                result = $"{hoursAgo} {(hoursAgo > 1 ? "giờ" : "giờ")} trước";
            }
            else
            {
                int daysAgo = (int)timeDifference.TotalDays;
                result = $"{daysAgo} {(daysAgo > 1 ? "ngày" : "ngày")} trước";
            }

            return result;
        }
    }
}
