using APBD_Cw1_s30586.Enums;
using APBD_Cw1_s30586.Models;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipmentList  = [];
    
    public void addEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }
    public void listEquipment()
    {
        foreach (var equipment in _equipmentList)
        {
            Console.WriteLine(equipment.ToString());
        }
    }

    public void listAvailableEquipment()
    {
        foreach (var equipment in _equipmentList)
        {
            if (equipment.IsAvailable)
            {
                Console.WriteLine(equipment);
            }
        }
    }
    
}