using CheefCooking.Models;
using System;

namespace CheefCooking.Vegitables
{
    [Serializable]
    public class Tomatoe : Food
    {
        private const string ingredientName = "Tomatoe";
        private const double carbsPerOneGramm = 0.037;
        private const double proteinPerOneGramm = 0.011;
        private const double fatPerOneGramm = 0.002;

        public Tomatoe() : base(ingredientName, 0, carbsPerOneGramm, proteinPerOneGramm, fatPerOneGramm) {}
        public Tomatoe(int weight) : base(ingredientName, weight, carbsPerOneGramm, proteinPerOneGramm, fatPerOneGramm) { }

        public override Food addMoreOfThisIngredient(int newIngredientWeight)
        {
            return new Tomatoe(this.productWeight + newIngredientWeight);
        }
    }
}
