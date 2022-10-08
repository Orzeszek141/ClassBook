namespace ClassBook.BLL.DTOs.Request;

public record ClassAddDto(string ClassNumber, int NumberOfComputers, int Floor, int FacultyId);