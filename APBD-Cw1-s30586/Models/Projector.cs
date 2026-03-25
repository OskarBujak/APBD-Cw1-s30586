namespace APBD_Cw1_s30586.Models;

public class Projector(string name, string manufacturer, string description, int brightnessLumens, double lampHours) : Equipment(name,manufacturer, description)
{
    public int BrightnessLumens { get; set; } = brightnessLumens;
    public double LampHours { get; set; } = lampHours;
}