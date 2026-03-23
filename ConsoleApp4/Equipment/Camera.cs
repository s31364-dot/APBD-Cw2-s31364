namespace ConsoleApp4.Equipment;
using ConsoleApp4.Enums;


public class Camera(string id, string name, EquipmentStatus status,bool isDigital,int maxVideoResoluthion) 
    : Equipment(id, name, status)
{
    public bool IsDigital {get; set;} = isDigital;
    public int MaxVideoResoluthion{get; set;} = maxVideoResoluthion;
}