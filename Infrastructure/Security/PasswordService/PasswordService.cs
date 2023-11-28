using System.Security.Cryptography;
using System.Text;
using Domain.IServices.ISecuriyServices;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Security.PasswordService;

public class PasswordService:IPasswordService
{
    private readonly IConfiguration _configuration;

    public PasswordService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public byte[] HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public bool IsValidPasswordHash(string password, byte[] storedPasswordHash)
    {
        byte[] newPasswordHash = HashPassword(password);
        return newPasswordHash.Length == storedPasswordHash.Length && newPasswordHash.AsSpan().SequenceEqual(storedPasswordHash);
    }
}