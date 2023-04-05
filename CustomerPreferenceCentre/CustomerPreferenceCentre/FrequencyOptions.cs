namespace CustomerPreferenceCentre
{
    public abstract record FrequencyOptions();

    public record SpecifiedDate(int date) : FrequencyOptions;

    public record SpecifiedDay(DayOfWeek dayOfWeek) : FrequencyOptions;

    public record EveryDay() : FrequencyOptions;

    public record Never() : FrequencyOptions;
}