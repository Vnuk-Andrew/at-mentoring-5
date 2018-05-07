using System;

namespace ConsoleApp1.AllFood.Exceptions
{
    class IllegalIngredientWeightException : Exception
    {
        const string message = "Ingredient weight can't be less than zero!";

        public IllegalIngredientWeightException() : base(message)
        {
        }
    }
}
