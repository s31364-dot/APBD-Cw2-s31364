using ConsoleApp4.Enums;

namespace ConsoleApp4.Equipment;

public class Projector(string id, string name, EquipmentStatus status,string resoluthion,List<VideoInputType> supportedInputs) 
    : Equipment(id, name, status)
{
    public string resoluthion { get; set; }
    public int lampHours {get; set;}
    public List<VideoInputType> supportedInputs { get; set; }
}