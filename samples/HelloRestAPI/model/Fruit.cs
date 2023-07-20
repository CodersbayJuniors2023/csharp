namespace HelloRestAPI.model;

public class Fruit
{
    public string Name { get; set; }
    public string Color { get; }

    public Fruit(string name, string color)
    {
        Name = name;
        Color = color;
    }
}