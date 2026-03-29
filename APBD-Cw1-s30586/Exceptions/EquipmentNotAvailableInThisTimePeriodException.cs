using APBD_Cw1_s30586.Models;

public class EquipmentNotAvailableInThisTimePeriodException(Equipment equipment)
: Exception($"Equipment with id: {equipment.Id} is not available in this time period");
    
