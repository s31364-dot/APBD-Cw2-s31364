using ConsoleApp4.Users;

namespace ConsoleApp4.Services;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetAllUsers();
}