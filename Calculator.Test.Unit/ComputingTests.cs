using Calculator.Test.Unit.ClassFixture;
using FluentAssertions;

namespace Calculator.Test.Unit;

public class ComputingTests:IClassFixture<ComputingClassFixture>
{
    private Computing computing;

    public ComputingTests(ComputingClassFixture c)
    {
        computing =c.computing;
    }


    [Fact]
    public void OddOrEven_Should_Return_Odd_When_Input_Is_OddValue()
    {
        //act
        var result=computing.OddOrEven(11);

        //Assert.Equal("Odd",result);

        //assserts
        result.Should().Be("Odd");
    }

    [Theory]
    [InlineData(10)]
    public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue(int value)
    {
        var result = computing.OddOrEven(value);

        //Assert.Equal("Even", result);   ////bedoone estefade az fluent assertion 
        result.Should().Be("Even");      //ba estefade az fluent assertion 
    }

    [Fact]
    public void CalculateAge_Should_Calculate_Age_When_CurrentYear_And_BirthDate_Is_ValidData()
    {
        var result = computing.CalculateAge(1380, 1400);
        result.Should().Be(20);
    }
    [Fact]
    public void CalculateAge_Should_Return_Zero_When_BirthDate_LessThan_Zero()
    {
        var result = computing.CalculateAge(-1, 1400);
        result.Should().Be(0);
    }

    [Fact]
    public void CalculateAge_Should_Throw_ArgumentException_When_BirthDate_OR_CurrentYear_Is_Zero()
    {
        var result = new Action(() =>
        {
            computing.CalculateAge(0, 1400);
        });
        result.Should().Throw<ArgumentException>();
    }


    public void Dispose()
    {
        
    }
}