namespace ClassBook.BLL.Exceptions;

public class PhoneNumberAlreadyTakenException : CustomException
{
    public PhoneNumberAlreadyTakenException(string phoneNumber) : base(
        $"Given phone number: {phoneNumber} is already taken")
    {
    }
}