namespace ClassBook.BLL.Exceptions;

public class WrongPasswordException : CustomException
{
    public WrongPasswordException() : base("Given password was wrong")
    {
    }
}