using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace Demo.Databases_CON
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection connection = new SqlConnection(new SqlConnectionStringBuilder {
                DataSource = "127.0.0.1",
                InitialCatalog = "TestDatabase",
                UserID = "sa",
                Password = "11110000",
                IntegratedSecurity = false
            }.ConnectionString);
            try
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE EnterpriceDir (Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(32) NOT NULL, Surename NVARCHAR(32) NOT NULL, Department NVARCHAR(32) NOT NULL, Position NVARCHAR(32) NOT NULL)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO EnterpriceDir (Name, Surename, Department, Position) Values ('Vasya', 'Pupkin', 'Development', 'Developer')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO EnterpriceDir (Name, Surename, Department, Position) Values ('Petya', 'Ivanov', 'Cleaning', 'Cleaner')";
                command.ExecuteNonQuery();
                command.CommandText = "SELECT Id, Name, Surename, Department, Position FROM EnterpriceDir";
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}");
                }
                Console.ReadKey();
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}
