using CheefCooking;
using CheefCooking.Models;
using CheefCooking.Vegitables;
using ConsoleApp1.AllFood.Exceptions;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.AllFood.Helpers
{
    public class SaladFileHelper : SaladHelper
    {
        static readonly Type[] allPossibleIngredients = new Type[] { typeof(Tomatoe), typeof(Carrot), typeof(Cucumber) };

        public static Salad getSaladFromRecipeFile(string fileName)
        {
            Salad salad = new Salad();

            try
            {
                getTextFromFile(fileName).Split(';')
                .Select(row => row.Trim()).ToList()
                .ForEach(row =>
                {
                    salad.addNewIngredients(getIngredientFromRecipeRow(row));
                });

                return salad;
            }
            catch (Exception e)
            {
                throw new IllegalRecipeFormatException(e.Message);
            }
        }

        public static void serializeSaladToXml(Salad salad, string xmlName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Salad), allPossibleIngredients);

            using (FileStream fs = new FileStream(xmlName, FileMode.Create))
            {
                formatter.Serialize(fs, salad);
            }
        }

        public static Salad deserializeSaladFromXml(string xmlName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Salad), allPossibleIngredients);
            using (FileStream fs = new FileStream(xmlName, FileMode.OpenOrCreate))
            {
                return (Salad)xs.Deserialize(fs);
            }
        }

        public static void serializeSaladToBinary(Salad salad, string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                bf.Serialize(fs, salad);
            }
        }

        public static Salad deserializeSaladFromBinary(string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Salad)bf.Deserialize(fs);
            }
        }

        public static void writeSaladToFile(Salad salad, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] array = Encoding.Default.GetBytes(salad.ToString());
                fs.Write(array, 0, array.Length);
            }
        }

        private static string getTextFromFile(string fileName)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                return Encoding.Default.GetString(array);
            }
        }

        private static Food getIngredientFromRecipeRow(string row)
        {
            string[] r = row.Trim().Split('-').Select(s => s.Trim()).ToArray();
            string ingName = r[0];
            int ingWeight = int.Parse(r[1]);
            return createAnIngredientByName(ingName, ingWeight);
        }
    }
}
