namespace ClassBook.BLL.Exceptions;

public class ClassNumberAlreadyTakenException : CustomException
{
    public ClassNumberAlreadyTakenException(string className) : base($"Given class name: {className} is already taken for this faculty")
    {
    }
}