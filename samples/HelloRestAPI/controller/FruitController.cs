using HelloRestAPI.model;

namespace HelloRestAPI.controller;

public class FruitController
{
    public Fruit GetOrange()
    {
        return new Fruit("orange", "orange");
    }

    public Fruit GetPear()
    {
        return new Fruit("pear", "green");
    }

    public Fruit GetApple()
    {
        return new Fruit("apple", "red");
    }

    public Fruit[] GetFruits()
    {
        return new[] { GetOrange(), GetPear(), GetApple() };
    }
}