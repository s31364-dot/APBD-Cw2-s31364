using ConsoleApp4.Enums;

namespace ConsoleApp4.Users;

public class Student(int id, string fullName, string email, string indexNumber) 
    : User(id, fullName, email)
{
    public string IndexNumber { get; set; } = indexNumber;
    
    public override UserType Type => UserType.Student;
    
    public override int MaxItemsLimit => 2; 
    public override decimal PenaltyMultiplier => 1.0m; 
    
}