using CheefCooking.Models;
using System;

namespace CheefCooking.Vegitables
{
    [Serializable]
    public class Carrot : Food
    {
        private const string ingredientName = "Carrot";
        private const double carbsPerOneGramm = 0.069;
        private const double proteinPerOneGramm = 0.013;
        private const double fatPerOneGramm = 0.001;

        public Carrot() : base(ingredientName, 0, carbsPerOneGramm, proteinPerOneGramm, fatPerOneGramm) { }

        public Carrot(int weight) : base(ingredientName, weight, carbsPerOneGramm, proteinPerOneGramm, fatPerOneGramm) {}

        public override Food addMoreOfThisIngredient(int newIngredientWeight)
        {
            return new Carrot(this.productWeight + newIngredientWeight);
        }
    }
}
