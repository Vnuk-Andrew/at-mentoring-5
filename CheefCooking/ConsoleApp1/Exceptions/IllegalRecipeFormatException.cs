using System;

namespace ConsoleApp1.AllFood.Exceptions
{
    class IllegalRecipeFormatException : Exception
    {
        const string illegalRecipeText = "Illegal recipe format exception. Please try to use 'ingredient - weight;' format. Trace: ";
        public IllegalRecipeFormatException(string message) : base(illegalRecipeText + message)
        {
        }
    }
}
