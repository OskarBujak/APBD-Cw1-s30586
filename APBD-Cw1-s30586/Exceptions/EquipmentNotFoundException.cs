public class EquipmentNotFoundException(int id)
 : Exception($"Equipment with id: {id} was not Found");