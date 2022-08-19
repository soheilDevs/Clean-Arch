namespace Domain.Shared;

public class Money:BaseValueObject
{
    /// <summary>
    ///    Rial
    /// </summary>
    public int Value { get; }

    public Money(int rialValue)
    {
        if (rialValue < 0)
            throw new InvalidDataException();

            Value = rialValue;
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
        return new Money(firstMoney.Value + money2.Value);
    }

    public override string ToString()
    {
        return Value.ToString("#,0");
    }

    public static Money operator -(Money firstMoney, Money money2)
    {
        return new Money(firstMoney.Value - money2.Value);
    }
}