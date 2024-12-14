using System;
using System.Diagnostics;
using System.Linq;
using Models;
namespace EFCoreApplication
{
    class Data
    {
        public static void Main()
        {
            using var db = new EmployyContext();
            Console.WriteLine($"Database path : {db.Dbpath}");
            Console.WriteLine("Inserting a new employee");
            Employy employeess0 = new Employy { EID = 1, Name = "Kusma Magar", DID = 10 };
            Employy employeess1 = new Employy { EID = 2, Name = "Rai  Maila", DID = 10 };
            Employy employeess2 = new Employy { EID = 3, Name = "Ankit Pun", DID = 10 };
            db.Add(employeess0);
            db.Add(employeess1);
            db.Add(employeess2);
            db.SaveChanges();
            Console.WriteLine("Querying for all Emploooyee Ordered by Name alphabetically");

            List<Employy> allEmployy = db.Employy
               .OrderBy(E => E.Name)
               .ToList();
            foreach (var Employy in allEmployy)
            {
                Console.WriteLine($"EmployyId : {Employy.EID},EmployyName : {Employy.Name},DID : {Employy.DID}");
            }
            EmployyLeave employeeLeave = new EmployyLeave { LeaveID = 1, EemployeID = employeess0.EID, NumOfDays = 3 };
            EmployyLeave employeeLeave1 = new EmployyLeave { LeaveID = 2, EemployeID = employeess1.EID, NumOfDays = 4 };
            EmployyLeave employeeLeave2 = new EmployyLeave { LeaveID = 3, EemployeID = employeess2.EID, NumOfDays = 1 };
            db.Add(employeeLeave);
            db.Add(employeeLeave1);
            db.Add(employeeLeave2);
            db.SaveChanges();
            Console.WriteLine($"Leave applied by {employeess0.Name} for {employeeLeave.NumOfDays} days");
            Console.WriteLine($"Leave applied by {employeess1.Name} for {employeeLeave1.NumOfDays} days");
            Console.WriteLine($"Leave applied by {employeess2.Name} for {employeeLeave2.NumOfDays} days");
            db.Remove(employeess0);
            db.Remove(employeess1);
            db.Remove(employeess2);
            db.RemoveRange(employeeLeave, employeeLeave1, employeeLeave2);
            db.SaveChanges();
        }
    }
}



