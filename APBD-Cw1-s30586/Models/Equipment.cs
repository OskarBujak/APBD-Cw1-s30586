namespace APBD_Cw1_s30586.Models;

public abstract class Equipment(string name, string manufacturer, string description)
{
    private static int _nextId = 1;

    public int Id { get; set; } = _nextId++;
    public string Name { get; set; } = name;
    public string Manufacturer { get; set; } = manufacturer;
    public string Description { get; set; } = description;
    
    public bool IsAvailable { get; set; } = true;

    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | Manufacturer: {Manufacturer} | Available: {(IsAvailable ? "Yes" : "No")} | Desc: {Description}";
    }
}