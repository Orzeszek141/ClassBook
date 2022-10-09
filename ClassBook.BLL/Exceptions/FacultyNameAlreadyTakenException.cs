namespace ClassBook.BLL.Exceptions;

public class FacultyNameAlreadyTakenException : CustomException
{
    public FacultyNameAlreadyTakenException(string facultyName) : base(
        $"Given faculty name: {facultyName} is already taken")
    {
    }
}