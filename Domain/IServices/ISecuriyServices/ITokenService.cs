namespace Domain.IServices.ISecuriyServices;

public interface ITokenService
{
    string Generate(string userName);
}