using APBD_Cw1_s30586.Exceptions;
using APBD_Cw1_s30586.Models;

public class ReservationService : IReservationService
{
    private readonly List<Reservation> _reservations = [];
    public void CreateReservation(User user, Equipment equipment, DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            throw new InvalidDatesException();
        }
        if (!equipment.IsAvailable)
        {
            throw new EquipmentNotAvailableException(equipment);
        }
        
        int countUserActiveReservations = GetUserReservations(user).Count(reservation => reservation.IsActive);

        if (countUserActiveReservations >= user.MaxReservations)
        {
            throw new TooManyUserReservationsException(countUserActiveReservations, user);
        }
        
        bool itemNotAvailableInTimePeriod = _reservations.Any(reservation => 
                reservation.IsActive 
                && reservation.Equipment == equipment 
                && reservation.Overlaps(startDate, endDate) 
        );

        if (itemNotAvailableInTimePeriod)
        {
            throw new EquipmentNotAvailableInThisTimePeriodException(equipment);
        }
        
        _reservations.Add(new Reservation(user, equipment, startDate, endDate));
        Console.WriteLine($"Created new reservation for {user.Id}");
    }

    public void CancelReservation(Reservation reservation)
    {
        reservation.IsCancelled = true;
        reservation.IsActive = false;
        Console.WriteLine($"Cancel reservation for {reservation.Id}");
    }

    public void EndReservation(Reservation reservation, DateTime returnDate)
    {
        if (!reservation.IsActive)
        {
            throw new ReservationAlreadyEndedException();
        }
        if (returnDate < reservation.From)
        {
            CancelReservation(reservation);
        }
        else if (returnDate < reservation.To)
        {
            reservation.IsActive = false;
            reservation.ReturnTime = returnDate;
            Console.WriteLine($"Reservation {reservation.Id} ended");
        }
        else if (returnDate > reservation.To)
        {
            reservation.IsActive = false;
            reservation.ReturnTime = returnDate;
            
            TimeSpan delay = returnDate - reservation.To;
            
            int daysLate = delay.Days;
            reservation.PenaltyValue = daysLate * Reservation.PenaltyFee; //0.67 za każdy dzień opóźnienia
            Console.WriteLine($"Reservation {reservation.Id} ended. Late fee: {reservation.PenaltyValue} PLN");
        }
    }

    public Reservation GetReservationFromId(int id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);
        return reservation ?? throw new ReservationNotFoundException(id);
    }
    
    public List<Reservation> GetUserReservations(User user)
    {
        return _reservations.Where(reservation => reservation.User == user).ToList();
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservations;
    }

    public List<Reservation> GetOverdueReservations()
    {
        return _reservations.Where(reservation => 
            reservation.IsActive
            && reservation.To < DateTime.Today
            ).ToList();
    }

    public void WriteReservation(List<Reservation> reservations)
    {
        foreach (var reservation in reservations)
        {
            Console.WriteLine(reservation);
        }
    }

    public void WriteReport()
    {
        var active = _reservations.Count(reservation => reservation.IsActive);
        var canceled = _reservations.Count(reservation => reservation.IsCancelled);
        var ended = _reservations.Count(reservation => reservation.ReturnTime != null);
        
        Console.WriteLine("Report:");
        Console.WriteLine($"Reservations all:       | {_reservations.Count}\n" +
                          $"Reservations active:    | {active}\n" +
                          $"Reservations canceled:  | {canceled}\n" +
                          $"Reservations ended:     | {ended}");
    }
}