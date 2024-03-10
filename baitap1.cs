using System;
using System.Collections.Generic;
using System.Linq;

// Lớp cha Vehicle
public class Vehicle
{
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
}

// Lớp con Car kế thừa từ lớp cha Vehicle
public class Car : Vehicle
{
    // Các thuộc tính riêng của Car
    public string Model { get; set; }
}

// Lớp con Truck kế thừa từ lớp cha Vehicle
public class Truck : Vehicle
{
    // Các thuộc tính riêng của Truck
    public string Company { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo danh sách các Car
        var cars = new List<Car>
        {
            new Car { Manufacturer = "Toyota", Model = "Camry", Year = 2005, Price = 150000 },
            new Car { Manufacturer = "Honda", Model = "Accord", Year = 1998, Price = 80000 },
            new Car { Manufacturer = "Ford", Model = "Fusion", Year = 2010, Price = 200000 },
            new Car { Manufacturer = "Nissan", Model = "Altima", Year = 1995, Price = 120000 },
            new Car { Manufacturer = "Chevrolet", Model = "Malibu", Year = 2008, Price = 180000 }
        };

        // Hiển thị các xe có giá trong khoảng 100.000 đến 250.000 và năm sản xuất > 1990
        var filteredCars = cars.Where(car => car.Price >= 100000 && car.Price <= 250000 && car.Year > 1990);
        Console.WriteLine("Cac xe co gia trong khoang 100.000 den 250.000 va nam san xuat > 1990:");
        foreach (var car in filteredCars)
        {
            Console.WriteLine($"{car.Manufacturer} {car.Model}, Nam san xuat: {car.Year}, Gia: {car.Price}");
        }

        // Gom các xe theo hãng sản xuất và tính tổng giá trị theo nhóm
        var groupedCars = cars.GroupBy(car => car.Manufacturer)
                              .Select(group => new
                              {
                                  Manufacturer = group.Key,
                                  TotalPrice = group.Sum(car => car.Price)
                              });
        Console.WriteLine("\nTang gia tri cac xe theo hang san xuat:");
        foreach (var group in groupedCars)
        {
            Console.WriteLine($"{group.Manufacturer}: {group.TotalPrice}");
        }

        // Tạo danh sách các Truck
        var trucks = new List<Truck>
        {
            new Truck { Manufacturer = "Ford", Year = 2015, Price = 300000, Company = "ABC Trucking" },
            new Truck { Manufacturer = "Chevrolet", Year = 2020, Price = 400000, Company = "XYZ Transport" },
            new Truck { Manufacturer = "Toyota", Year = 2018, Price = 350000, Company = "DEF Logistics" }
        };

        // Hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
        var orderedTrucks = trucks.OrderByDescending(truck => truck.Year);
        Console.WriteLine("\nDanh sach cac Truck theo thu tu nam sang xuat moi nhat:");
        foreach (var truck in orderedTrucks)
        {
            Console.WriteLine($"{truck.Manufacturer}, Nam san xuat: {truck.Year}, Gia: {truck.Price}");
        }

        // Hiển thị tên công ty chủ quản của các Truck
        Console.WriteLine("\nTen cong ty chu quan cua cac Truck:");
        foreach (var truck in trucks)
        {
            Console.WriteLine($"{truck.Manufacturer}: {truck.Company}");
        }
    }
}
