public class PersonTests
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        Person p = new Person("Casey", "Nguyen", 21);

        Assert.Equal("Nguyen, Casey", p.FullName());
    }

    [Fact]
    public void IsAdult_ReturnsTrue_WhenAge18OrMore()
    {
        Person p = new Person("Sam", "Lee", 18);

        Assert.True(p.IsAdult());
    }
}
