namespace ClassBook.BLL.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException() : base("Resource was not found for given id")
    {
    }

    public NotFoundException(string email) : base($"User for given email: {email} does not exist")
    {
    }
}