using ConsoleApp4.Enums;
using Equipment = ConsoleApp4.Equipment.Equipment;

namespace ConsoleApp4.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment.Equipment> _equipmentList = new();

    public void AddEquipment(Equipment.Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }

    public void addEquipment(Equipment.Equipment equipment)
    {
        if (_equipmentList.Any(e => e.Id == equipment.Id))
        {
            throw new InvalidOperationException("Sprzęt o tym ID już istnieje.");
        }
    
        _equipmentList.Add(equipment);
    }

    public List<Equipment.Equipment> GetAllEquipment()
    {
        return _equipmentList;
    }

    public List<Equipment.Equipment> GetAvailableEquipment()
    {
        return _equipmentList.Where(e => e.Status == EquipmentStatus.Avalible).ToList();    }

    public void SetEquipmentStatus(string equipmentId, EquipmentStatus newStatus)
    {
        var equipment = _equipmentList.FirstOrDefault(e => e.Id == equipmentId);
        
        if (equipment == null)
        {
            throw new ArgumentException("Nie znaleziono sprzętu o podanym ID.");
        }
        
        equipment.Status = newStatus;
    }
}