using ConsoleApp4.Equipment;


namespace ConsoleApp4.Services;
using Equipment = ConsoleApp4.Equipment.Equipment;
public interface IEquipmentService
{
    void addEquipment();
    
    List<Equipment> GetAllEquipment();
    
    List<Equipment> GetAvailableEquipment();
    
}