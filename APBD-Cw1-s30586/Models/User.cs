using APBD_Cw1_s30586.Enums;

namespace APBD_Cw1_s30586.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _nextId = 1;

    public int Id { get; set; } = _nextId++;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public abstract UserTypes UserType { get; }
}