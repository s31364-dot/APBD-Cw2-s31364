using ConsoleApp4.Enums;
using ConsoleApp4.Rentals;

namespace ConsoleApp4.Services;

public class ReportService(IEquipmentService equipmentService, IUserService userService, IRentalService rentalService) : IReportService
{
    public string GenerateSummaryReport()
    {
        var allEquipment = equipmentService.GetAllEquipment();
        var allUsers = userService.GetAllUsers();
        var currentDate = DateTime.Now;

        var totalEquipment = allEquipment.Count;
        var availableEquipment = allEquipment.Count(e => e.Status == EquipmentStatus.Avalible);
        var rentedEquipment = allEquipment.Count(e => e.Status == EquipmentStatus.Rented);
        var damagedOrService = allEquipment.Count(e => e.Status == EquipmentStatus.Damaged || e.Status == EquipmentStatus.InService);

        var totalUsers = allUsers.Count;
        var overdueRentals = rentalService.GetOverdueRentals(currentDate).Count;

        return $"""
                Całkowita liczba sprzętu: {totalEquipment}
                  - Dostępne: {availableEquipment}
                  - Wypożyczone: {rentedEquipment}
                  - W naprawie/Uszkodzone: {damagedOrService}

                Liczba zarejestrowanych użytkowników: {totalUsers}
                Liczba przeterminowanych wypożyczeń: {overdueRentals}
                ---------------------------------
                """;
    }
}