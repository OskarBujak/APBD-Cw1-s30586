using APBD_Cw1_s30586.Models;

public interface IEquipmentService
{
    public void addEquipment(Equipment equipment);
    public void listEquipment();
    public void listAvailableEquipment();
}