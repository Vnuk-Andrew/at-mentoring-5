using CheefCooking.Models;
using CheefCooking.Vegitables;
using ConsoleApp1.AllFood.Exceptions;
using System;

namespace ConsoleApp1.AllFood.Helpers
{
    public class SaladHelper
    {
        public static Food createAnIngredientByName(string ingName, int ingWeight)
        {
            switch (ingName)
            {
                case "Carrot":
                    return new Carrot(ingWeight);
                case "Cucumber":
                    return new Cucumber(ingWeight);
                case "Tomatoe":
                    return new Tomatoe(ingWeight);
                default:
                    throw new UnknownIngredientException("Program doesn't know this ingredient: " + ingName);
            }
        }
    }
}
