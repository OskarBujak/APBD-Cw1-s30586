using APBD_Cw1_s30586.Models;

public interface IReservationService
{
    public void CreateReservation(User user, Equipment equipment, DateTime startDate, DateTime endDate);
    public void CancelReservation(Reservation reservation);
    public void EndReservation(Reservation reservation, DateTime returnDate);
    
    public List<Reservation> GetUserReservations(User user);
    public List<Reservation> GetAllReservations();
    public List<Reservation> GetOverdueReservations();
    public Reservation GetReservationFromId(int id);
    public void WriteReservation(List<Reservation> reservations);

    public void WriteReport();
}