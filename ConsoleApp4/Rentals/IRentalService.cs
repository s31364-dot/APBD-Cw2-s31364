using ConsoleApp4.Users;

namespace ConsoleApp4.Rentals;

public interface IRentalService
{
    RentalRecord RentEquipment(User user, Equipment.Equipment equipment, int days);
    void ReturnEquipment(RentalRecord rental, DateTime actualReturnDate);
    List<RentalRecord> GetActiveRentalsForUser(User user);
    List<RentalRecord> GetOverdueRentals(DateTime currentDate);
}