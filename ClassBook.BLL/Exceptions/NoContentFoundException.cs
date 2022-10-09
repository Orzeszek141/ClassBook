namespace ClassBook.BLL.Exceptions;

public class NoContentFoundException : CustomException
{
    public NoContentFoundException() : base("There is no content found in table")
    {
    }
}