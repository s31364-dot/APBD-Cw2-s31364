using ConsoleApp4.Equipment;
using ConsoleApp4.Enums;
using ConsoleApp4.Users;

namespace ConsoleApp4.Services;
using Equipment = ConsoleApp4.Equipment.Equipment;

public class EquipmnetService
{
    readonly List<Equipment> _equipmentList = new();
    
    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
        Console.WriteLine($"Dodano sprzęt: {equipment.Name} (ID: {equipment.Id})");
    }
    
    public List<Equipment> GetAllEquipment()
    {
        return _equipmentList;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipmentList
            .Where(e => e.Status == EquipmentStatus.Avalible)
            .ToList();
    }

}