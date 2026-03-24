using ConsoleApp4.Enums;
using ConsoleApp4.Users;

namespace ConsoleApp4.Rentals;

public class RentalService : IRentalService
{
    private readonly List<RentalRecord> _rentals = new();
    private const double BasePenaltyPerDay = 10.0;

    public RentalRecord RentEquipment(User user, Equipment.Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Avalible)
        {
            throw new InvalidOperationException("Sprzęt jest niedostępny do wypożyczenia.");
        }

        var activeRentalsCount = _rentals.Count(r => r.RentedBy.Id == user.Id && r.ReturnDate == null);
        if (activeRentalsCount >= user.MaxItemsLimit)
        {
            throw new InvalidOperationException("Użytkownik przekroczył limit aktywnych wypożyczeń.");
        }

        equipment.Status = EquipmentStatus.Rented;
        
        var rentDate = DateTime.Now;
        var dueDate = rentDate.AddDays(days);
        var rental = new RentalRecord(user, equipment, rentDate, dueDate);
        
        _rentals.Add(rental);
        return rental;
    }

    public void ReturnEquipment(RentalRecord rental, DateTime actualReturnDate)
    {
        if (rental.ReturnDate.HasValue)
        {
            throw new InvalidOperationException("To wypożyczenie zostało już zwrócone.");
        }

        rental.ReturnDate = actualReturnDate;
        rental.RentedEquipment.Status = EquipmentStatus.Avalible;

        if (actualReturnDate > rental.DueDate)
        {
            double daysLate = (actualReturnDate - rental.DueDate).Days;
            rental.PenaltyCost = daysLate * BasePenaltyPerDay * (double)rental.RentedBy.PenaltyMultiplier;
        }
    }

    public List<RentalRecord> GetActiveRentalsForUser(User user)
    {
        return _rentals.Where(r => r.RentedBy.Id == user.Id && r.ReturnDate == null).ToList();
    }

    public List<RentalRecord> GetOverdueRentals(DateTime currentDate)
    {
        return _rentals.Where(r => r.ReturnDate == null && r.DueDate < currentDate).ToList();
    }
}