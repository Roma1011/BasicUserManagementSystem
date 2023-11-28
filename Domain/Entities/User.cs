namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public byte[] Password { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}