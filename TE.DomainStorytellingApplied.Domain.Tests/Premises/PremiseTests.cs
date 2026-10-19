namespace TE.DomainStorytellingApplied.Domain.Tests.Premises;

using TE.DomainStorytellingApplied.Domain.Premises;

public class PremiseTests
{
    private static readonly Guid SomeId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    [Fact]
    public void GivenIdAndName_WhenCreatingPremise_ShouldExposeIdAndName()
    {
        var premise = new Premise(SomeId, "Conference Room A");

        premise.Id.ShouldBe(SomeId);
        premise.Name.ShouldBe("Conference Room A");
    }

    [Fact]
    public void GivenNameWithSurroundingWhitespace_WhenCreatingPremise_ShouldTrimName()
    {
        var premise = new Premise(SomeId, "  Conference Room A  ");

        premise.Name.ShouldBe("Conference Room A");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenBlankName_WhenCreatingPremise_ShouldThrow(string name)
    {
        Should.Throw<ArgumentException>(() => new Premise(SomeId, name));
    }

    [Fact]
    public void GivenNullName_WhenCreatingPremise_ShouldThrow()
    {
        Should.Throw<ArgumentException>(() => new Premise(SomeId, null!));
    }

    [Fact]
    public void GivenEmptyId_WhenCreatingPremise_ShouldThrow()
    {
        Should.Throw<ArgumentException>(() => new Premise(Guid.Empty, "Conference Room A"));
    }

    [Fact]
    public void GivenSameIdAndName_WhenComparing_ShouldBeEqual()
    {
        var first = new Premise(SomeId, "Conference Room A");
        var second = new Premise(SomeId, "Conference Room A");

        first.ShouldBe(second);
    }
}
