namespace CustomerPreferenceCentre
{
    public class Calendar
    {
        private const int DaysPerCalendarMonth = 28;

        public List<(DayOfWeek day, (int date, string month, int year))> DayDatePairing(int numberOfDays)
        {
            var dateOnly = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var daysList = new List<DayOfWeek>();
            var datesList = new List<(int date, string month, int year)>();

            for (var i = 1; i < numberOfDays; i++)
            {
                var updatedDate = dateOnly.AddDays(i);

                var day = updatedDate.DayOfWeek;
                daysList.Add(day);

                var date = updatedDate.Day;
                var month = updatedDate.ToString("MMMM");
                var year = updatedDate.Year;

                if (date > DaysPerCalendarMonth)
                {
                    continue;
                }

                datesList.Add((date, month, year));
            }

            return daysList.Zip(datesList).ToList();
        }
    }
}