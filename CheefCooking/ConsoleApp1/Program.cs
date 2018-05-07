using CheefCooking.Vegitables;
using ConsoleApp1;
using ConsoleApp1.AllFood.Helpers;
using ConsoleApp1.Models;
using System;

namespace CheefCooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Salad salad = Salad.createSalad(new Carrot(300));
            Console.WriteLine(salad);
            salad.addNewIngredients(new Cucumber(3000));
            salad.addNewIngredients(new Tomatoe(2000), new Carrot(1000));
            Console.WriteLine(salad);
            salad.sortVegitablesByTotalProteins();
            Console.WriteLine(salad);
            Salad saladBySortedParameters = Salad.createSalad(salad.getSaladIngredientsByTotalCarbsRange(65, 83).ToArray());
            Console.WriteLine("Salad by sorted parameters:");
            Console.WriteLine(saladBySortedParameters);
            Console.WriteLine("Total salad calories: " + salad.calculateTotalCalories());
            SaladFileHelper.serializeSaladToXml(salad, "salad.xml");
            Console.WriteLine();
            Salad saladFromXml = SaladFileHelper.deserializeSaladFromXml("salad.xml");
            Console.WriteLine("Salad from xml file:");
            Console.WriteLine(saladFromXml);
            SaladFileHelper.writeSaladToFile(saladFromXml, "salad.txt");
            Salad saladFromFile = SaladFileHelper.getSaladFromRecipeFile("salad_recipe.txt");
            Console.WriteLine("Salad from txt file:");
            Console.WriteLine(saladFromFile);
            SaladFileHelper.serializeSaladToBinary(saladFromFile, "salad.dat");
            Salad saladFromBinary = SaladFileHelper.deserializeSaladFromBinary("salad.dat");
            Console.WriteLine("Salad from binary file:");
            Console.WriteLine(saladFromBinary);
            
            Northwing nw = new Northwing();
            Territory tr = new Territory(13666, "Los santos", 2);
            string lastName = nw.getEmployeeLastNameById(1);
            nw.addNewTerritory(tr);
            nw.updateTerritoryByTerritoryId(13666, new Territory(13666, "San Andreas", 2));
            nw.deleteTerritoryById(tr.territoryId);
            nw.runSalesByCategoryProcedure("Beverages", 1998);

            Console.ReadLine();
        }
    }
}
