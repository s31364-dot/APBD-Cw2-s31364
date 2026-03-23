namespace ConsoleApp4.Equipment;
using ConsoleApp4.Enums;

public class Laptop(string id, string name, EquipmentStatus status, string processorType, int ramSize, string operatingSystem) 
    : Equipment(id, name, status)
{
    public string ProcessorType { get; set; } = processorType;
    public int RamSize { get; set; } = ramSize;
    public string OperatingSystem { get; set; } = operatingSystem;
}