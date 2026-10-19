namespace TE.DomainStorytellingApplied.Domain.Timeslots;

public sealed record Timeslot
{
    public DateTimeOffset Start { get; }
    public DateTimeOffset End { get; }
    public TimeSpan Duration => End - Start;

    public Timeslot(DateTimeOffset start, DateTimeOffset end)
    {
        if (end <= start)
        {
            throw new ArgumentException("Timeslot must end after it starts.", nameof(end));
        }

        Start = start;
        End = end;
    }
}
