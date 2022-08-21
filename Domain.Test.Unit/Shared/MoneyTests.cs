using Domain.Shared;
using Domain.Shared.Exceptions;
using FluentAssertions;

namespace Domain.Test.Unit.Shared;

public class MoneyTests
{
    [Fact]
    public void Constructor_Should_Set_Values_When_Value_BiggerThan_Zero()
    {
        var money = new Money(10000);

        money.Value.Should().Be(10000);
    }

    [Fact]
    public void Constructor_Should_Throw_InvalidDomainDataException_When_Value_LessThan_Zero()
    {
        var result =()=> new Money(-100);

        result.Should().ThrowExactly<InvalidDomainDataException>();
    }
    [Fact]
    public void FromRial_Should_Create_New_Money()
    {
        var money = Money.FromRial(1000);
        money.Value.Should().Be(1000);
    }
    [Fact]
    public void FromTooman_Should_Create_New_Money_With_ToomanValue()
    {
        var toomanValue = 1000;
        var money = Money.FromToman(toomanValue);
        money.Value.Should().Be(toomanValue*10);
    }
    [Fact]
    public void Plus_Operator_Should_Sum_Values_And_Return_New_Money()
    {
        //arrange
        var money = Money.FromRial(100);
        var money2 = Money.FromRial(500);

        //act
        var result = money + money2;

        //asserts
        result.Value.Should().Be(600);
    }
    [Fact]
    public void ToString_Should_Return_MoneyValue_With_String_Format()
    {
        //arrange
        var money = Money.FromRial(100);

        //act
        var result = money.ToString();

        //asserts
        result.Should().Be("100");
    }
    [Fact]
    public void Minus_Operator_Should_Subtract_Values_And_Return_New_Money()
    {
        //arrange
        var money = Money.FromRial(100);
        var money2 = Money.FromRial(500);

        //act
        var result = money2 - money;

        //asserts
        result.Value.Should().Be(400);
    }
}