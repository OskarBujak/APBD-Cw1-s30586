namespace APBD_Cw1_s30586.Models;

public class Laptop(string name, string manufacturer, string description, int ram, int Hz) : Equipment(name,manufacturer, description)
{
    public int Ram { get; set; } = ram;
    public int Hz { get; set; } = Hz;
}