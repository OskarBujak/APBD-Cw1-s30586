namespace APBD_Cw1_s30586.Models;

public class Reservation(User user,Equipment equipment,DateTime from, DateTime to)
{
    private static int _nextId = 1;
    public static double PenaltyFee = 0.67;
    
    public int Id { get; set; } = _nextId++;
    public User User { get; set; } = user;
    public Equipment Equipment { get; set; } = equipment;
    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;

    public bool IsActive = true;
    public bool IsCancelled = false;
    
    
    
    public DateTime? ReturnTime;
    public double PenaltyValue = 0;

    public bool WasReturnedOnTime()
    {
        return (PenaltyValue == 0);
    }
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }

    public override string ToString()
    {
        var returnInfo = ReturnTime.HasValue ? ReturnTime.Value.ToString("yyyy-MM-dd") : "Not returned";
    
        return $"ID: {Id} | User: {User.FirstName} {User.LastName} | Eq: {Equipment.Name} | Period: {From:yyyy-MM-dd} - {To:yyyy-MM-dd} | Active: {(IsActive ? "Yes" : "No")} | Returned: {returnInfo} | Penalty: {PenaltyValue}";
    }
}