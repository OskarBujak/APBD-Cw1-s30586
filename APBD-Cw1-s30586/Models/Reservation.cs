namespace APBD_Cw1_s30586.Models;

public class Reservation(User user,Equipment equipment,DateTime from, DateTime to)
{
    private static int _nextId = 1;

    public int Id { get; set; } = _nextId++;
    public User User { get; set; } = user;
    public Equipment Equipment { get; set; } = equipment;
    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;

    public DateTime? ReturnTime;
    public double PenaltyValue = 0;

    public bool WasReturnerOnTime()
    {
        return (PenaltyValue == 0);
    }
}