namespace CustomerPreferenceCentre
{
    public class CustomerPreferences
    {
        private const int PrintReportForNumberOfDays = 90;

        private readonly Calendar _calendar;
        private readonly Dictionary<string, string> _preferencesAllocation;

        private IEnumerable<string> _everydayMarketing;
        private IEnumerable<string> _specifiedDayMarketing;
        private IEnumerable<string> _specifiedDateMarketing;

        public CustomerPreferences()
        {
            _calendar = new Calendar();
            _preferencesAllocation = new Dictionary<string, string>();

            _everydayMarketing = new List<string>();
            _specifiedDayMarketing = new List<string>();
            _specifiedDateMarketing = new List<string>();
        }

        public Dictionary<string, string> AllocatePreferences(Dictionary<string, FrequencyOptions> customerPreferences)
        {
            var dayDatePairing = _calendar.DayDatePairing(PrintReportForNumberOfDays);

            foreach (var (day, date) in dayDatePairing)
            {
                var customers = string.Empty;
                if (customerPreferences.Any(x => x.Value is EveryDay))
                {
                    _everydayMarketing = customerPreferences
                        .Where(x => x.Value is EveryDay)
                        .Select(x => x.Key);
                }

                if (customerPreferences.Any(x => x.Value is SpecifiedDay))
                {
                    _specifiedDayMarketing = customerPreferences
                        .Where(x => x.Value.Equals(new SpecifiedDay(day)))
                        .Select(x => x.Key);
                }

                if (customerPreferences.Any(x => x.Value is SpecifiedDate))
                {
                    _specifiedDateMarketing = customerPreferences
                        .Where(x => x.Value.Equals(new SpecifiedDate(date.date)))
                        .Select(x => x.Key);
                }

                customers += string.Join(", ",
                    _everydayMarketing.Concat(_specifiedDayMarketing).Concat(_specifiedDateMarketing));

                _preferencesAllocation.Add($"{day.ToString()[..3]} {date.date:00}-{date.month}-{date.year}", customers);
            }

            return _preferencesAllocation;
        }
    }
}