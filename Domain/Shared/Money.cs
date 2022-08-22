using Domain.Shared.Exceptions;

namespace Domain.Shared;

public class Money:BaseValueObject
{
    /// <summary>
    ///    Rial
    /// </summary>
    public int RialValue { get;private set; }

    public Money(int rialValue)
    {
        if (rialValue < 0)
            throw new InvalidDomainDataException();

            RialValue = rialValue;
    }
    public static Money FromRial(int value)
    {
        return new Money(value);
    }
    public static Money FromToman(int value)
    {
        return new Money(value*10);
    }

    public static Money operator +(Money firstMoney, Money money2)
    {
        return new Money(firstMoney.RialValue + money2.RialValue);
    }

    public override string ToString()
    {
        return RialValue.ToString("#,0");
    }

    public static Money operator -(Money firstMoney, Money money2)
    {
        return new Money(firstMoney.RialValue - money2.RialValue);
    }
}