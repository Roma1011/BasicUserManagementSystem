namespace Domain.IServices.ISecuriyServices;

public interface IPasswordService
{ 
    byte[] HashPassword(string password);
    bool IsValidPasswordHash(string password, byte[] storedPasswordHash);
}