namespace CustomerPreferenceCentre
{
    public class Program
    {
        private static CustomerPreferences? _preferences;

        private static void Main(string[] args)
        {
            _preferences = new CustomerPreferences();

            var customerPreferences = new Dictionary<string, FrequencyOptions>
            {
                {"A", new EveryDay()},
                {"B", new SpecifiedDate(10)},
                {"C", new SpecifiedDate(12)},
                {"D", new Never()},
                {"E", new SpecifiedDay(DayOfWeek.Thursday)},
                {"F", new SpecifiedDay(DayOfWeek.Thursday)},
                {"G", new SpecifiedDay(DayOfWeek.Friday)},
                {"H", new SpecifiedDay(DayOfWeek.Monday)},
                {"I", new EveryDay()},
            };

            var marketingRecords = _preferences.AllocatePreferences(customerPreferences);
            foreach (var record in marketingRecords)
            {
                Console.WriteLine($"{$"{record.Key}",-22} {record.Value}");
            }
        }
    }
}