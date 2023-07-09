namespace HelloCSWorld;

public class Person
{
    private string? _firstName;
    public string FirstName
    {
        get
        {
            if (_firstName == null)
            {
                return "name is not set";
            }

            return _firstName;
        }
        set => _firstName = value;
    }

    private string _lastName;
    public string? LastName { get; set; }

    public Person(string? firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    static void Main()
    {
        var person1 = new Person("Gustav", "Gottfried");
        person1.LastName = "Gans";
        Console.WriteLine(person1.LastName);

        Person person2 = new(null, "Mustermann");
        Console.WriteLine(person2.ToString());

        Console.WriteLine("Hello CS World");

        int[] array1 = new int[5];
        var array2 = new[] { 1, 2, 3, 4 };
        int[] array3 = { 1, 2, 3, 4 };

        // two dim array
        var multiDim1 = new int[2, 3];
        int[,] multiDim2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // jagged array
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged structure
        jaggedArray[0] = new[] { 1, 2, 3, 4 };

        foreach (var i in array3)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < 20; i++)
        {
            Console.Write($"{i} ");
        }

        Car car1 = new("BMW", "M4 Coupe", "04-2023");
        Car car2 = new("BMW", "M4 Coupe", "05-2023");

        Console.WriteLine();
        // no implicit toString call like in Java
        Console.WriteLine(car1.Equals(car2).ToString());
    }
}