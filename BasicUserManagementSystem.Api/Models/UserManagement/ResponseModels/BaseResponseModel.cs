namespace BasicUserManagementSystem.Models.UserManagement.ResponseModels;

public record BaseResponseModel(bool Success, string Message, IEnumerable<string> ErrorMessages, int StatusCode);