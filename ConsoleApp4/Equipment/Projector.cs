using ConsoleApp4.Enums;

namespace ConsoleApp4.Equipment;

public class Projector(string id, string name, EquipmentStatus status,string resoluthion,List<VideoInputType> supportedInputs, int lampHours) 
    : Equipment(id, name, status)
{
    public string Resoluthion { get; set; } = resoluthion;
    public int LampHours {get; set;} = lampHours;
    public List<VideoInputType> SupportedInputs { get; set; } = supportedInputs;
}