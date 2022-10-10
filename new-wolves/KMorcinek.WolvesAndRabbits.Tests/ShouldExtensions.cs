namespace KMorcinek.WolvesAndRabbits.Tests;

public static class ShouldExtensions
{
    public static void ShouldBe(this int value, int expected)
    {
        Assert.Equal(expected, value);
    }
    
    public static void ShouldBe(this double value, int expected)
    {
        Assert.Equal(expected, value);
    }
    
    public static void ShouldBe(this double value, double expected)
    {
        Assert.Equal(expected, value);
    }
    
    public static void ShouldBeTrue(this bool value)
    {
        Assert.True(value);   
    }
    
}