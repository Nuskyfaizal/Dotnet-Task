namespace AppProgram.Helpers;
public class AppException
{
    public AppException(string message, string details = null)
    {
        Message = message;
        Details = details;
    }

    public string Message { get; set; }
    public string Details { get; set; }
}
