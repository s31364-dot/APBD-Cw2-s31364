namespace ConsoleApp4.Users;

public abstract class User(int id,string fullName,string email)
{
    public int Id { get; set; } = id;
    public string FullName { get; set; } = fullName;
    public string Email { get; set; } = email;
    
    public abstract int MaxItemsLimit { get; }
    public abstract decimal PenaltyMultiplier { get; }
}