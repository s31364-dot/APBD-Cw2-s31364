namespace ConsoleApp4.Equipment;
using ConsoleApp4.Enums;

public abstract class Equipment(string id, string name, EquipmentStatus status)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public EquipmentStatus Status { get; set; } = status;
}