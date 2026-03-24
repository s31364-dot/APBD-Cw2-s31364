using ConsoleApp4.Users;

namespace ConsoleApp4.Rentals;

public class RentalRecord(User rentedBy, Equipment.Equipment rentedEquipment, DateTime rentDate, DateTime dueDate)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public User RentedBy { get; init; } = rentedBy;
    public Equipment.Equipment RentedEquipment { get; init; } = rentedEquipment;
    public DateTime RentDate { get; init; } = rentDate;
    public DateTime DueDate { get; init; } = dueDate;
    public DateTime? ReturnDate { get; set; }
    public double PenaltyCost { get; set; }
}