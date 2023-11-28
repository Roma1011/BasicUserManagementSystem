namespace BasicUserManagementSystem.Models.UserManagement.ResponseModels;

public record UserProfileResponseModel(string UserName,string Email,string FirstName,string LastName,bool Success, string Message, int StatusCode, IEnumerable<string>? ErrorMessages = default)
    : BaseResponseModel(Success, Message, ErrorMessages, StatusCode);