using BasicUserManagementSystem.Models.UserManagement.ResponseModels;

namespace BasicUserManagementSystem.Models.Auth;

public record AuthResponseModel(string Token, bool Success, string Message, int StatusCode, IEnumerable<string>? ErrorMessages = default)
    : BaseResponseModel(Success, Message, ErrorMessages, StatusCode);