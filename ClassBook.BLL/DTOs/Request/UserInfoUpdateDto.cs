namespace ClassBook.BLL.DTOs.Request;

public record UserInfoUpdateDto(int Id ,string PhoneNumber, DateTime BirthDate, int UserId);