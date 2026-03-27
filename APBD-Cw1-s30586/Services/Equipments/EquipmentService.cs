using APBD_Cw1_s30586.Enums;
using APBD_Cw1_s30586.Models;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipmentList  = [];
    
    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }
    public void WriteEquipment()
    {
        foreach (var equipment in GetAllEquipments())
        {
            Console.WriteLine(equipment.ToString());
        }
    }
    public void WriteAvailableEquipment()
    {
        foreach (var equipment in GetAllAvailableEquipments())
        {
            Console.WriteLine(equipment);
        }
    }

    public Equipment GetEquipmentById(int id)
    {
        return _equipmentList.FirstOrDefault(e => e.Id == id)
               ?? throw new EquipmentNotFoundException(id);
    }

    public List<Equipment> GetAllEquipments()
    {
        return _equipmentList;
    }

    public List<Equipment> GetAllAvailableEquipments()
    {
        return _equipmentList.Where(equipment => equipment.IsAvailable).ToList();
    }
    public void SetUnavaliable(Equipment equipment)
    {
        equipment.IsAvailable = false;
    }

    public void SetAvailable(Equipment equipment)
    {
        equipment.IsAvailable = true;
    }
    
    public void WriteReport()
    {
        var available = _equipmentList.Count(equipment => equipment.IsAvailable);
        var notAvailable = _equipmentList.Count(equipment => !equipment.IsAvailable);
        
        Console.WriteLine("Report:");
        Console.WriteLine($"Equipment all:             | {_equipmentList.Count}\n" +
                          $"Equipment available:       | {available}\n" +
                          $"Equipment not available:   | {notAvailable}\n");
    }
}