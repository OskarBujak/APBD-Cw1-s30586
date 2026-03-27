using APBD_Cw1_s30586.Models;

public class EquipmentNotAvailableException(Equipment equipment)
 : Exception($"Equipment with id: {equipment.Id} is not available");