using System;

namespace ConsoleApp1.AllFood.Exceptions
{
    class UnknownIngredientException : Exception
    {
        public UnknownIngredientException(string message) : base(message)
        {
        }
    }
}
