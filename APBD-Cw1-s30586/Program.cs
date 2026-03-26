using APBD_Cw1_s30586.Models;
using APBD_Cw1_s30586.Enums;

//User Creation
var user1 = new Employee("Oskar","Bujak");
var user2 = new Student("Papa","Smerf");    

//EquipmentCreation
var eq1 = new Camera("VHS", "PanSonic", "dsdsad", 2, CameraTypes.Mirrorless);
var eq2 = new Laptop("GigaDobry", "Lenovo", "jakisfajnyopis123", 2048, 60);
var eq3 = new Projector("Adas", "Huawei", "super giga dobry projektor 2137", 200, 1337);

//Service Creation
//var userService1 = new UserService();
IEquipmentService eqService = new EquipmentService();
IReservationService reservationService = new ReservationService();

eqService.addEquipment(eq1);
eqService.addEquipment(eq2);
eqService.addEquipment(eq3);

eqService.listEquipment();
eqService.listEquipment();