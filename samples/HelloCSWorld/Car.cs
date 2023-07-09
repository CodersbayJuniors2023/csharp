namespace HelloCSWorld;

public class Car : IEquatable<Car>
{
    private string? Make { get; set; }
    private string? Model { get; set; }
    private string? Year { get; set; }

    public Car(string? make, string? model, string? year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
    
    public bool Equals(Car? car)
    {
        return (Make, Model, Year) == (car?.Make, car?.Model, car?.Year);
    }
}