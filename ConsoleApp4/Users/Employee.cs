using ConsoleApp4.Enums;

namespace ConsoleApp4.Users;

public class Employee(int id, string fullName, string email, string department) 
    : User(id, fullName, email)
{
    public string Department { get; set; } = department;

    public override UserType Type => UserType.Employee;
    public override int MaxItemsLimit => 5; 
    public override decimal PenaltyMultiplier => 0m; 
}