namespace ClassBook.BLL.Exceptions;

public class EmailAlreadyTakenException : CustomException
{
    public EmailAlreadyTakenException(string email) : base($"Given email: {email} is already taken")
    {
    }
}