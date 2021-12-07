using System;
using System.Configuration;
using Npgsql;
using Dapper;

namespace AdoNetConsoleApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var connectionString = "Server=127.0.0.1;Port=5432;Database=userdb; ";
            //var sqlExpression = "SELECT * FROM information_schema.tables WHERE table_schema = 'public'";
            string sqlExpression = "INSERT INTO \"Users\" (\"Name\", \"Age\") VALUES ('Tom', 18)";
            //string sqlExpression = "INSERT INTO Users (Name, Age) VALUES ('Tom', 18)";

            var connection = new NpgsqlConnection(connectionString);

            var reader = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);              

                var number = command.ExecuteNonQuery();

                Console.WriteLine("Добавлено объектов: {0}", number);
                Console.WriteLine("ЗБС");
            }
            catch (NpgsqlException ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                //Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);
                //Console.WriteLine("\tWorkstationld: {0}", connection.ProcessID);
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        }
    }
}
