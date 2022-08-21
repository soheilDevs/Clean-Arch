namespace Calculator.Test.Unit.ClassFixture;

public class ComputingClassFixture:IDisposable
{
    public Computing computing;

    public ComputingClassFixture()
    {
        computing = new();
    }

    public void Dispose()
    {
        //
    }
}