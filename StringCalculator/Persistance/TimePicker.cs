using System;

namespace StringCalculator.Persistance
{
    public interface TimePicker
    {
        public DateTime GetDate();
    }

    public class HistoryTimePicker : TimePicker
    {
        public DateTime GetDate() => DateTime.Now;

    }
}
