using ConsoleApp1.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;

namespace ConsoleApp1
{
    public class Northwing
    {
        private readonly string connectionString;
        const string selectEmployyeLastnameByIdTemplate = "SELECT [LastName] FROM[Northwind].[dbo].[Employees] WHERE[EmployeeID] = {0}";
        const string insertTerritoryCommandTemplate = "INSERT [Northwind].[dbo].[Territories] VALUES ({0}, '{1}', {2})";
        const string deleteByTerritoryIdCommandTemplate = "DELETE [Northwind].[dbo].[Territories] WHERE TerritoryID = {0}";
        const string updateTerritoryByTerritoryIdTemplate = @"  UPDATE [Northwind].[dbo].[Territories]
        SET TerritoryID = {0}, TerritoryDescription = '{1}', RegionID = {2}
        WHERE TerritoryID = {3}";

        public Northwing()
        {
            connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        }
        
        public string getEmployeeLastNameById(int id)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();

                SqlCommand command = new SqlCommand(string.Format(selectEmployyeLastnameByIdTemplate, id), sql);
                return (string)command.ExecuteScalar();
            }
        }

        public int addNewTerritory(Territory territory)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();
                SqlCommand command = new SqlCommand(string.Format(insertTerritoryCommandTemplate, territory.territoryId, territory.territoryDescription, territory.regionId), sql);
                return command.ExecuteNonQuery();
            }
        }

        public int deleteTerritoryById(int territoryId)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();
                SqlCommand command = new SqlCommand(string.Format(deleteByTerritoryIdCommandTemplate, territoryId), sql);
                return command.ExecuteNonQuery();
            }
        }

        public int updateTerritoryByTerritoryId(int territoryId, Territory newTerritory)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();
                SqlCommand command = new SqlCommand(string.Format(updateTerritoryByTerritoryIdTemplate, 
                    newTerritory.territoryId, newTerritory.territoryDescription, newTerritory.regionId, territoryId), sql);
                return command.ExecuteNonQuery();
            }
        }

        public DataTable runSalesByCategoryProcedure(string categoryName, int orderYear)
        {
            if (orderYear.ToString().Length > 4)
                throw new DataException("orderYear value size can't be more than 4 symbols");
            if (orderYear < 0)
                throw new ArithmeticException("orderYear can't be less than zero!");
            if (categoryName.Length > 15)
                throw new ArgumentException("categoryName length can't be more than 15 symbols");

            var ordersTable = new DataTable();
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();
                SqlCommand command = new SqlCommand("SalesByCategory", sql);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter catNameParam = new SqlParameter("@CategoryName", SqlDbType.NVarChar, 15);
                catNameParam.Value = categoryName;

                SqlParameter orderYearParam = new SqlParameter("@OrdYear", SqlDbType.NVarChar, 4);
                orderYearParam.Value = orderYear.ToString();

                command.Parameters.Add(catNameParam);
                command.Parameters.Add(orderYearParam);

                var result = command.ExecuteReader();
                ordersTable.Load(result);
                return ordersTable;
            }
            
        }
    }
}
