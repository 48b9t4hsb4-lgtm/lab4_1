public class Flower
{
    public string Name { get; set; }

    public Flower(string name)
    {
        Name = name;
    }

    public void Blossom()
    {
        Console.WriteLine($"{Name} розквітає");
    }

    public void Wither()
    {
        Console.WriteLine($"{Name} зів'яла");
    }

}

public class Petal
{
    public string Color { get; set; }
    public Petal(string color)
    {
        Color = color;
    }

}

public class Bud
{
    public string Color { get; set; }
    public Bud(string color)
    {
        Color = color;
    }
}

public class Hydrangea : Flower
{
    public Petal petal;
    public Bud bud;

    public Hydrangea(string Name, Petal petal, Bud bud) : base(Name)
    {
        this.petal = petal;
        this.bud = bud;

    }
}



