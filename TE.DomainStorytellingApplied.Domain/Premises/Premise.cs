namespace TE.DomainStorytellingApplied.Domain.Premises;

public sealed record Premise
{
    public Guid Id { get; }
    public string Name { get; }

    public Premise(Guid id, string name)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Premise id must not be empty.", nameof(id));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Id = id;
        Name = name.Trim();
    }
}
