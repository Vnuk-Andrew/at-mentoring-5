using CheefCooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheefCooking
{
    [Serializable]
    public class Salad
    {
        public List<Food> currentSaladIngredients = new List<Food>();

        public static Salad createSalad(params Food[] ingredients)
        {
            var salad = new Salad();
            salad.addNewIngredients(ingredients);
            return salad;
        }

        public Salad() { }

        public void addNewIngredients(params Food[] ingredients)
        {
            foreach (Food ingredient in ingredients)
            {
                addNewIngredient(ingredient);
            }
        }

        public void sortVegitablesByTotalProteins()
        {
            currentSaladIngredients = currentSaladIngredients.OrderBy(r => r.getTotalProteins()).ToList();
        }
        
        public List<Food> getSaladIngredientsByTotalCarbsRange(double minCarbs, double maxCarbs)
        {
            return currentSaladIngredients
                .Where(ing => ing.getTotalCarbs() >= minCarbs)
                .Where(ing => ing.getTotalCarbs() <= maxCarbs)
                .ToList();
        }

        public double calculateTotalCalories()
        {
            double totalCal = 0;
            currentSaladIngredients.ForEach(ing => totalCal += ing.getTotalCalories());
            return totalCal;
        }

        public override string ToString()
        {
            string s = string.Empty;
            currentSaladIngredients.ForEach(r =>
            {
                s += r.ToString() + "\n";
            });
            return s;
        }
        
        private void addNewIngredient(Food newIngredient)
        {
            bool isNewIngredientAlreadyInSalad = false;

            for (int i = 0; i < currentSaladIngredients.Count; i++)
            {
                if (currentSaladIngredients[i].productName.Equals(newIngredient.productName))
                {
                    isNewIngredientAlreadyInSalad = true;
                    currentSaladIngredients[i] = currentSaladIngredients[i].addMoreOfThisIngredient(newIngredient.productWeight);
                }
            }

            if (!isNewIngredientAlreadyInSalad)
            {
                currentSaladIngredients.Add(newIngredient);
            }
        }
    }
}
