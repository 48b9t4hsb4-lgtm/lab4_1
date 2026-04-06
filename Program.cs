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
}
public class Petal
{
    public string Color { get; set; }

    public Petal(string color)
    {
        Console.WriteLine("Викликано конструктор Petal");
        Color = color;
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
}
