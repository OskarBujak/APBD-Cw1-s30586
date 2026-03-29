using APBD_Cw1_s30586.Models;

public interface IEquipmentService
{
    public void AddEquipment(Equipment equipment);
    public void WriteEquipment();
    public void WriteAvailableEquipment();
    public Equipment GetEquipmentById(int id);
    public List<Equipment> GetAllEquipments();
    public List<Equipment> GetAllAvailableEquipments();
    public void SetUnavaliable(Equipment equipment);
    public void SetAvailable(Equipment equipment);
    public void WriteReport();
}