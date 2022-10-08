namespace ClassBook.BLL.DTOs.Request;

public record ClassUpdateDto(int Id, string ClassNumber, int NumberOfComputers, int Floor, int FacultyId);