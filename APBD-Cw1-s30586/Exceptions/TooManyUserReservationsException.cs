using APBD_Cw1_s30586.Models;

public class TooManyUserReservationsException(int reservationsCount, User user)
 : Exception($"User has too many reservations {reservationsCount} - max amount is: {user.MaxReservations}");