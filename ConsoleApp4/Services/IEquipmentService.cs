using ConsoleApp4.Enums;
using ConsoleApp4.Equipment;


namespace ConsoleApp4.Services;
using Equipment = Equipment.Equipment;
public interface IEquipmentService
{
    void addEquipment(Equipment equipment);
    
    List<Equipment> GetAllEquipment();    
    List<Equipment> GetAvailableEquipment();    
    
    void SetEquipmentStatus(string equipmentId, EquipmentStatus newStatus);
    
    
}
    
    