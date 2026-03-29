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

eqService.AddEquipment(eq1);
eqService.AddEquipment(eq2);
eqService.AddEquipment(eq3);

eqService.WriteReport();

eqService.WriteEquipment();
eqService.SetUnavaliable(eq1);

eqService.WriteReport();

// Przedmiot niedostepny
//Exception reservationService.CreateReservation(user1, eq1, new DateTime(2026, 3, 27), new DateTime(2026, 03, 30));

eqService.WriteAvailableEquipment();
eqService.SetAvailable(eq1);

reservationService.CreateReservation(user2, eq1, new DateTime(2026, 3, 20), new DateTime(2026, 03, 26));

Console.WriteLine(); //All
reservationService.WriteReservation(reservationService.GetAllReservations());
Console.WriteLine(); //Overdue
reservationService.WriteReservation(reservationService.GetOverdueReservations());

//Exception Przedmiot niedostepny w tym okresie czasowym
//reservationService.CreateReservation(user2, eq1, new DateTime(2026, 3, 20), new DateTime(2026, 03, 26));

reservationService.CreateReservation(user2, eq2, new DateTime(2026, 3, 27), new DateTime(2026, 03, 30));
//Exception Limit rezerwacji osiagniety
//reservationService.CreateReservation(user2, eq2, new DateTime(2026, 04, 1), new DateTime(2026, 04, 30));

//Exception Data koncowa wczesniej niz data startu
//reservationService.CreateReservation(user2, eq2, new DateTime(2026, 5, 27), new DateTime(2026, 03, 30));

//Wyswietlenie aktywnych wypozyczen uzytkownika
Console.WriteLine("Aktywne wypozycznia uzytkownika: ");
reservationService.WriteReservation(reservationService.GetUserReservations(user2));

reservationService.WriteReport();


//Oddanie sprzetu
reservationService.EndReservation(reservationService.GetReservationFromId(2),new DateTime(2026, 3, 29));
reservationService.EndReservation(reservationService.GetReservationFromId(1),DateTime.Today);
//Exception Rezerwacja juz zakonczona 
//reservationService.EndReservation(reservationService.GetReservationFromId(1),DateTime.Today);

reservationService.WriteReport();