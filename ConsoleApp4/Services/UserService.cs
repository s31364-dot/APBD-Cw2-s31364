using ConsoleApp4.Users;

namespace ConsoleApp4.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);


        Console.WriteLine($"User {user.FullName}  ({user.Type}) has been added");
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}
    