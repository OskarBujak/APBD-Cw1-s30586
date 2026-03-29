public class ReservationNotFoundException(int id)
 : Exception($"Reservation with id: {id} was not Found");