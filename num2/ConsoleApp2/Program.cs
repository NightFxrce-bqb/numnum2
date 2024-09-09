using System;
using System.Collections.Generic;

// Абстрактный класс Product
public abstract class Product
{
    public abstract string Name { get; set; }
    public virtual decimal Price { get; set; }

    // Абстрактный метод для получения информации о продукте
    public abstract string GetInformation();
}

// Класс Toy (игрушка) с уникальным свойством AgeGroup
public class Toy : Product
{
    public override string Name { get; set; }
    public override decimal Price { get; set; }
    public string AgeGroup { get; set; }

    public override string GetInformation()
    {
        return $"Toy: {Name}, Price: {Price:C}, Age Group: {AgeGroup}";
    }
}

// Класс Meat (мясо) с уникальным свойством ExpirationDate
public class Meat : Product
{
    public override string Name { get; set; }
    public override decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }

    public override string GetInformation()
    {
        return $"Meat: {Name}, Price: {Price:C}, Expiration Date: {ExpirationDate:MM/dd/yyyy}";
    }
}

// Класс Drink (напиток) с уникальным свойством Volume
public class Drink : Product
{
    public override string Name { get; set; }
    public override decimal Price { get; set; }
    public double Volume { get; set; } // объем в литрах

    public override string GetInformation()
    {
        return $"Drink: {Name}, Price: {Price:C}, Volume: {Volume}L";
    }
}

// Класс Book (книга) с уникальным свойством Author
public class Book : Product
{
    public override string Name { get; set; }
    public override decimal Price { get; set; }
    public string Author { get; set; }

    public override string GetInformation()
    {
        return $"Book: {Name}, Price: {Price:C}, Author: {Author}";
    }
}

// Класс Electronics (электроника) с уникальным свойством WarrantyPeriod
public class Electronics : Product
{
    public override string Name { get; set; }
    public override decimal Price { get; set; }
    public int WarrantyPeriod { get; set; } // гарантия в месяцах

    public override string GetInformation()
    {
        return $"Electronics: {Name}, Price: {Price:C}, Warranty: {WarrantyPeriod} months";
    }
}

// Класс для применения скидок
public class DiscountManager
{
    // Метод для применения скидки ко всем продуктам в списке
    public static void ApplyDiscount(List<Product> products, decimal discountPercentage)
    {
        foreach (var product in products)
        {
            // Применяем скидку
            product.Price -= product.Price * (discountPercentage / 100);
        }
    }
}

class Program
{
    static void Main()
    {
        // Создание списка продуктов
        var products = new List<Product>
        {
            new Toy { Name = "car", Price = 59.99m, AgeGroup = "6-12" },
            new Meat { Name = "chiken", Price = 9.99m, ExpirationDate = DateTime.Now.AddDays(7) },
            new Drink { Name = "sokk oragne", Price = 6.49m, Volume = 2 },
            new Book { Name = "skazki", Price = 29.99m, Author = "tom skynet" },
            new Electronics { Name = "notebook", Price = 699.99m, WarrantyPeriod = 20 }
        };

        // Применение скидки 10%
        DiscountManager.ApplyDiscount(products, 10);

        // Вывод информации о продуктах
        foreach (var product in products)
        {
            Console.WriteLine(product.GetInformation());
        }
    }
}
