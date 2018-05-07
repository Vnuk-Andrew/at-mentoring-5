using ConsoleApp1.AllFood.Exceptions;
using System;

namespace CheefCooking.Models
{
    [Serializable]
    public abstract class Food : IngredientEnergy
    {

        public string productName { get; set; }
        public int productWeight { get; set; }

        private readonly double carbsPerOneGramm;
        private readonly double proteinPerOneGramm;
        private readonly double fatPerOneGramm;

        public double getTotalCalories()
        {
            return (carbsPerOneGramm * 3 + proteinPerOneGramm * 4 + fatPerOneGramm * 9) * productWeight;
        }

        public double getTotalProteins()
        {
            return proteinPerOneGramm * productWeight;
        }

        public double getTotalCarbs()
        {
            return carbsPerOneGramm * productWeight;
        }

        public double getTotalFats()
        {
            return fatPerOneGramm * productWeight;
        }

        public Food() { }

        protected Food(string productName, int weight, double carbsPerOneGramm, double proteinPerOneGramm, double fatPerOneGramm)
        {
            if (weight < 0)
                throw new IllegalIngredientWeightException();
            this.productName = productName;
            this.productWeight = weight;
            this.carbsPerOneGramm = carbsPerOneGramm;
            this.proteinPerOneGramm = proteinPerOneGramm;
            this.fatPerOneGramm = fatPerOneGramm;
        }

        public override string ToString()
        {
            return productName + " Weight: " + productWeight + " Total calories: " + getTotalCalories() +
                " Total proteins: " + getTotalProteins() + " Total carbs: " + getTotalCarbs() + " Total fats: " + getTotalFats();
        }

        public abstract Food addMoreOfThisIngredient(int newIngredientWeight);
    }
}
