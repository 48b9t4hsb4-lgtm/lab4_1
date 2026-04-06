using System;
public class Flower
{
    public string Name { get; set; }
    public Bud FlowerBud { get; set; }

    public Flower(string name, Bud bud)
    {
        Console.WriteLine("Викликано конструктор Flower");
        Name = name;
        FlowerBud = bud;
    }
    public void Blossom()
    {
        Console.WriteLine($"Викликано метод Blossom. Квітка '{Name}' розквітає");
    }
    public void Wither()
    {
        Console.WriteLine($"Викликано метод Wither. Квітка '{Name}' зів'яла...");
    }
    public void PrintBudColor()
    {
        Console.WriteLine($"Викликано метод PrintBudColor");
        Console.WriteLine($"Колір бутона квітки '{Name}': {FlowerBud.GetColor()}");
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("Викликано метод Equals");
        if (obj == null || GetType() != obj.GetType()) return false;
        Flower other = (Flower)obj;
        return Name == other.Name && FlowerBud.Equals(other.FlowerBud);
    }

    public override int GetHashCode()
    {
        Console.WriteLine("Викликано метод GetHashCode");
        return HashCode.Combine(Name, FlowerBud);
    }

    public override string ToString()
    {
        Console.WriteLine("Викликано метод ToString");
        return $"Квітка: {Name}, містить {FlowerBud.ToString()}";
    }

}
public class Petal
{
    public string Color { get; set; }

    public Petal(string color)
    {
        Console.WriteLine("Викликано конструктор Petal");
        Color = color;
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("Викликано метод Equals");
        if (obj == null || GetType() != obj.GetType()) return false;
        Petal other = (Petal)obj;
        return Color == other.Color;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("Викликано метод GetHashCode");
        return Color?.GetHashCode() ?? 0;
    }

    public override string ToString()
    {
        Console.WriteLine("Викликано метод ToString");
        return $"Пелюсток ({Color})";
    }

}
public class Bud
{
    public List<Petal> Petals { get; set; }

    public Bud(List<Petal> petals)
    {
        Console.WriteLine("Викликано конструктор Bud");
        Petals = petals ?? new List<Petal>();
    }
    public string GetColor()
    {
        Console.WriteLine("Викликано метод GetColor");
        if (Petals.Count == 0) return "Невідомий";
        return Petals.First().Color;
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("Викликано метод Equals");
        if (obj == null || GetType() != obj.GetType()) return false;
        Bud other = (Bud)obj;
        // Спрощене порівняння: бутони однакові, якщо в них однакова кількість пелюсток і однаковий колір
        return Petals.Count == other.Petals.Count && GetColor() == other.GetColor();
    }

    public override int GetHashCode()
    {
        Console.WriteLine("Викликано метод GetHashCode");
        return HashCode.Combine(Petals.Count, GetColor());
    }

    public override string ToString()
    {
        Console.WriteLine("Викликано метод ToString");
        return $"Бутон (Колір: {GetColor()}, Кількість пелюсток: {Petals.Count})";
    }

}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Створення об'єктів:");

        List<Petal> petals = new List<Petal>
            {
                new Petal("Червоний"),
                new Petal("Червоний"),
                new Petal("Червоний")
            };

        Bud bud = new Bud(petals); //створює бутон з пелюсток

        Flower myFlower = new Flower("Тюльпан", bud); //створюю квітку назва плюс передаю бутон

        Console.WriteLine("\nВиконання завдання:");
        myFlower.PrintBudColor();
        myFlower.Blossom();
        myFlower.Wither();

        Console.WriteLine("\nТестування основних методів:");
        Console.WriteLine(myFlower.ToString());
        Console.WriteLine($"Хешкод квітки: {myFlower.GetHashCode()}");
        //перевірка на Equals
        Flower sameFlower = new Flower("Тюльпан", new Bud(petals));
        Console.WriteLine($"Чи однакові дві квітки? -> {myFlower.Equals(sameFlower)}");

        Console.ReadLine();
    }
}