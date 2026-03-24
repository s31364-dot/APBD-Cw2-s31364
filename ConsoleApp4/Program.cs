using System;
using System.Collections.Generic;
using ConsoleApp4.Enums;
using ConsoleApp4.Equipment;
using ConsoleApp4.Rentals;
using ConsoleApp4.Services;
using ConsoleApp4.Users;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var equipmentService = new EquipmentService();
            var userService = new UserService();
            var rentalService = new RentalService();
            var reportService = new ReportService(equipmentService, userService, rentalService);

            Console.WriteLine(" Scenariusz demonstracyjny \n");

            Console.WriteLine("Dodawanie sprzętu...");
            var laptop = new Laptop("L1", "Dell XPS 15", EquipmentStatus.Avalible, "Intel Core i7", 16, "Windows 11");
            var projector = new Projector("P1", "Epson X05", EquipmentStatus.Avalible, "1080p", new List<VideoInputType> { VideoInputType.HDMI, VideoInputType.VGA }, 1200);
            var camera = new Camera("C1", "Sony A7 III", EquipmentStatus.Avalible, true, 4000); 
            
            equipmentService.addEquipment(laptop);
            equipmentService.addEquipment(projector);
            equipmentService.addEquipment(camera);
            Console.WriteLine("Sprzęt został pomyślnie dodany.\n");

            Console.WriteLine("Dodawanie użytkowników...");
            var student = new Student(1, "Jan Kowalski", "jan@edu.pl", "s12345");
            var employee = new Employee(2, "Anna Nowak", "anna@edu.pl", "Wydział IT");
            
            userService.AddUser(student);
            userService.AddUser(employee);
            Console.WriteLine();

            Console.WriteLine("Poprawne wypożyczenie sprzętu...");
            var rental1 = rentalService.RentEquipment(employee, laptop, 7);
            Console.WriteLine($"Wypożyczono: {laptop.Name} dla {employee.FullName}. Status sprzętu: {laptop.Status}\n");

            Console.WriteLine("Próba niepoprawnej operacji (sprzęt niedostępny)...");
            try
            {
                rentalService.RentEquipment(student, laptop, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OCZEKIWANY BŁĄD]: {ex.Message}\n");
            }
            
            Console.WriteLine("Zwrot sprzętu w terminie...");
            var returnDateOnTime = rental1.RentDate.AddDays(5);
            rentalService.ReturnEquipment(rental1, returnDateOnTime);
            Console.WriteLine($"Zwrócono: {laptop.Name}. Naliczona kara: {rental1.PenaltyCost} PLN. Status: {laptop.Status}\n");

            Console.WriteLine("Zwrot opóźniony (kara)...");
            var rental2 = rentalService.RentEquipment(student, camera, 3); 
            var returnDateLate = rental2.RentDate.AddDays(5); 
            rentalService.ReturnEquipment(rental2, returnDateLate);
            Console.WriteLine($"Zwrócono po terminie: {camera.Name} przez {student.FullName}.");
            Console.WriteLine($"Naliczona kara (student ma mnożnik x1.0): {rental2.PenaltyCost} PLN.\n");

            equipmentService.SetEquipmentStatus("P1", EquipmentStatus.Damaged);

            Console.WriteLine("Generowanie raportu końcowego:");
            Console.WriteLine(reportService.GenerateSummaryReport());
            
            Console.ReadLine();
        }
    }
}