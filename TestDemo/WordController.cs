public class WordController
{

    private readonly IReverseService reverseService;

    public WordController(IReverseService _reverseService)
    {
        this.reverseService = _reverseService;
    }
    public string ReverseAndUpcase(string _word)
    {
        String foo = new ReverseService().Reverse(_word);
        return foo.ToUpper();
    }
    public string? RefactoredReverseAndUpcase(string _word)
    {
        try
        {
            String foo = reverseService.Reverse(_word);
            return foo.ToUpper();

        }
        catch (IOException _ioe)
        {
            Logger.logDebug(_ioe);
        }
        return default(string);
    }
}


public interface IReverseService
{
    string Reverse(string _word);
}
public class ReverseService : IReverseService
{
    public string Reverse(string _word) => new string(_word.Reverse().ToArray());
}

class Logger
{
    public static void logDebug(Exception e) => Console.WriteLine(e.Message);
}