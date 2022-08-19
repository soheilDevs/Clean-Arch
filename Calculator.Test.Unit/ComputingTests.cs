namespace Calculator.Test.Unit;

public class ComputingTests
{
    [Fact]
    public void OddOrEven_Should_Return_Odd_When_Input_Is_OddValue()
    {
        var computing = new Computing();
        var result=computing.OddOrEven(11);

        Assert.Equal("Odd",result);
    }

    [Theory]
    [InlineData(10)]
    public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue(int value)
    {
        var computing = new Computing();
        var result = computing.OddOrEven(value);

        Assert.Equal("Even", result);
    }
}