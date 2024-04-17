public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World!";
    }
}

// metodo helloworld interface
public interface IHelloWorldService
{
    string GetHelloWorld();
}