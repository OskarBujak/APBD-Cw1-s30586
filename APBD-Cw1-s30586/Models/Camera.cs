using APBD_Cw1_s30586.Enums;

namespace APBD_Cw1_s30586.Models;

public class Camera(string name, string manufacturer, string description, double maxZoom, CameraTypes type) : Equipment(name,manufacturer, description)
{
    public double MaxZoom { get; set; } = maxZoom;
    public CameraTypes Type { get; set; } = type;
}