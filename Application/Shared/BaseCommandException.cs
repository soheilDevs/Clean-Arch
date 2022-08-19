namespace Application.Shared;

public class BaseCommandException:Exception
{
    public BaseCommandException()
    {

    }

    public BaseCommandException(string message) : base(message)
    {

    }
}