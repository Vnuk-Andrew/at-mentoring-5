using CheefCooking.Models;
using System;

namespace CheefCooking.Vegitables
{
    [Serializable]
    public class Cucumber : Food
    {
        private const string ingredientName = "Cucumber";
        private const double carbsPerOneGramm = 0.001;
        private const double proteinPerOneGramm = 0.008;
        private const double fatPerOneGramm = 0.001;

        public Cucumber() : base(ingredientName, 0, carbsPerOneGramm, proteinPerOneGramm, fatPerOneGramm) { }

        public Cucumber(int weight) : base(ingredientName, weight, carbsPerOneGramm, proteinPerOneGramm, fatPerOneGramm) {}

        public override Food addMoreOfThisIngredient(int newIngredientWeight)
        {
            return new Cucumber(this.productWeight + newIngredientWeight);
        }
    }
}
