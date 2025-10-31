using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum RoomStatus
{
    Свободен,
    Занят,
    Уборка
}

public enum BookingStatus
{
    Подтверждено,
    Ожидание,
    Отменено,
    Завершено
}

public enum PaymentStatus
{
    Оплачено,
    Ожидание,
    Отменено,
    Возврат
}

public enum PaymentMethod
{
    Наличные,
    Карта,
    Перевод,
    Онлайн
}

public class Guest
{
    public int GuestID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string PassportNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
}

public class Room
{
    public int RoomID { get; set; }
    public string RoomNumber { get; set; }
    public string RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public RoomStatus Status { get; set; }
}

public class Booking
    public DateTime CheckInDate { get; set; }
    public decimal TotalCost { get; set; }
    public BookingStatus Status { get; set; }
}
public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTime HireDate { get; set; }
}

{
    public int ServiceID { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}

public class Payment
{
    public int BookingID { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
}

public class HotelDatabase
{
    public List<Guest> Guests { get; set; }
    public List<Booking> Bookings { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Service> Services { get; set; }
    public List<Payment> Payments { get; set; }

    public HotelDatabase()
    {
        Guests = new List<Guest>();
        Rooms = new List<Room>();
        Bookings = new List<Booking>();
        Employees = new List<Employee>();
        Services = new List<Service>();
        Payments = new List<Payment>();
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
       
        Guests.Add(new Guest { GuestID = 1, FirstName = "Иван", LastName = "Петров", Phone = "+79161234567", PassportNumber = "4510123456", RegistrationDate = DateTime.Now.AddDays(-30) });
        Guests.Add(new Guest { GuestID = 2, FirstName = "Мария", LastName = "Сидорова", Phone = "+79167654321", PassportNumber = "4510654321", RegistrationDate = DateTime.Now.AddDays(-15) });

        Rooms.Add(new Room { RoomID = 1, RoomNumber = "101", RoomType = "Стандарт", PricePerNight = 2500, Capacity = 2, Status = RoomStatus.Свободен });
        Rooms.Add(new Room { RoomID = 2, RoomNumber = "102", RoomType = "Люкс", PricePerNight = 5000, Capacity = 3, Status = RoomStatus.Свободен });
        Rooms.Add(new Room { RoomID = 3, RoomNumber = "201", RoomType = "Бизнес", PricePerNight = 7500, Capacity = 2, Status = RoomStatus.Уборка });

        Employees.Add(new Employee { EmployeeID = 1, FirstName = "Анна", LastName = "Иванова", Position = "Администратор", Phone = "+79161112233", HireDate = DateTime.Now.AddYears(-1), Salary = 45000 });
        Employees.Add(new Employee { EmployeeID = 2, FirstName = "Сергей", LastName = "Кузнецов", Position = "Горничная", Phone = "+79162223344", HireDate = DateTime.Now.AddMonths(-6), Salary = 35000 });

        Services.Add(new Service { ServiceID = 1, ServiceName = "Завтрак", Description = "Континентальный завтрак", Cost = 500, Category = "Питание" });
        Services.Add(new Service { ServiceID = 2, ServiceName = "SPA", Description = "Расслабляющий массаж", Cost = 2000, Category = "Услуги" });
    public List<Room> Rooms { get; set; }
    public int PaymentID { get; set; }
    public string Category { get; set; }
    public string ServiceName { get; set; }
public class Service
        Services.Add(new Service { ServiceID = 3, ServiceName = "Трансфер", Description = "Трансфер из/в аэропорт", Cost = 1500, Category = "Транспорт" });
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public int EmployeeID { get; set; }
    }


    public DateTime BookingDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int BookingID { get; set; }
    public void AddGuest(Guest guest)
    public int RoomID { get; set; }
    public int GuestID { get; set; }
    {

        guest.GuestID = Guests.Count > 0 ? Guests.Max(g => g.GuestID) + 1 : 1;

        Guests.Add(guest);

    }


    public Guest GetGuest(int guestId)
    {
        return Guests.FirstOrDefault(g => g.GuestID == guestId);
    }

    public void AddRoom(Room room)

    {
        room.RoomID = Rooms.Count > 0 ? Rooms.Max(r => r.RoomID) + 1 : 1;
        Rooms.Add(room);
    }


    public List<Room> GetAvailableRooms()
    {
        return Rooms.Where(r => r.Status == RoomStatus.Свободен).ToList();

    }


    public void AddBooking(Booking booking)
    {
        booking.BookingID = Bookings.Count > 0 ? Bookings.Max(b => b.BookingID) + 1 : 1;

        Bookings.Add(booking);

        var room = Rooms.FirstOrDefault(r => r.RoomID == booking.RoomID);

        if (room != null)
        {
            room.Status = RoomStatus.Занят;

        }
    }


    public void AddPayment(Payment payment)
    {
        payment.PaymentID = Payments.Count > 0 ? Payments.Max(p => p.PaymentID) + 1 : 1;

        Payments.Add(payment);
    }


    public List<Booking> GetBookingsByGuest(int guestId)
    {
        return Bookings.Where(b => b.GuestID == guestId).ToList();
    }


    public decimal GetTotalPaymentsForBooking(int bookingId)
    {
        return Payments
            .Where(p => p.BookingID == bookingId && p.Status == PaymentStatus.Оплачено)
            .Sum(p => p.Amount);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.InputEncoding = Encoding.UTF8;

        var db = new HotelDatabase();


        var newGuest = new Guest

        {
            FirstName = "Алексей",

            LastName = "Смирнов",

            Phone = "+79169998877",

            PassportNumber = "4510789456",

            RegistrationDate = DateTime.Now

        };
        db.AddGuest(newGuest);

        var booking = new Booking

        {
            GuestID = newGuest.GuestID,

            RoomID = 1,
            CheckInDate = DateTime.Now.AddDays(1),
            CheckOutDate = DateTime.Now.AddDays(3),
            TotalCost = 5000,

            Status = BookingStatus.Подтверждено,

            BookingDate = DateTime.Now
        };

        db.AddBooking(booking);

        var payment = new Payment

        {
            BookingID = booking.BookingID,

            Amount = 5000,
            PaymentDate = DateTime.Now,

            Method = PaymentMethod.Карта,
            Status = PaymentStatus.Оплачено

        };

        db.AddPayment(payment);

        Console.WriteLine("Свободные номера:");
        foreach (var room in db.GetAvailableRooms())

        {
            Console.WriteLine($"Номер {room.RoomNumber} - {room.RoomType} - {room.PricePerNight} руб./ночь");
        }

        Console.WriteLine("\nВсе гости:");
        foreach (var guest in db.Guests)
        {
            Console.WriteLine($"{guest.FirstName} {guest.LastName} - {guest.Phone}");
        }
    }
}
