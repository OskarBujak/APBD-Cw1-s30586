using APBD_Cw1_s30586.Enums;

namespace APBD_Cw1_s30586.Models;

public class Employee(string firstName, string lastName) : User(firstName, lastName)
{
    public override UserTypes UserType => UserTypes.Employee;
}