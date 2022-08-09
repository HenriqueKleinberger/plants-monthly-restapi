using Plants_Monthly.Schedules;
using Quartz;

namespace Plants_Monthly.Utils
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }

    //Implementation with real DateTime.Now
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}
