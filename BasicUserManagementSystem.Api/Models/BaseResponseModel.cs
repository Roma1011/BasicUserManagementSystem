namespace BasicUserManagementSystem.Models;

public record BaseResponseModel(bool Success, string Message, IEnumerable<string>? ErrorMessages, int StatusCode);