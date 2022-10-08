using ClassBook.Domain.Enums;

namespace ClassBook.BLL.DTOs.Request;

public record UserRequestDto(string FirstName, string LastName, string Email, string Password , Role Role);