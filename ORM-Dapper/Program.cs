using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Engines;
using System.Data;

namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            Console.WriteLine("Departments: ");
            Thread.Sleep(1000);
            Console.Write("Loading ");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(". ");
            }
            Console.WriteLine();

            #region Department Section

            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {

                Console.WriteLine($"{department.DepartmentID} {department.Name}");
                Console.WriteLine();

            }

            #endregion

            Console.WriteLine("Products: ");
            Thread.Sleep(1000);
            Console.Write("Loading ");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(". ");
            }
            Console.WriteLine();


            #region Product Section

            var productRepository = new DapperProductRepository(conn);

            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {

                Console.WriteLine($"ProductID: {product.ProductID}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"CategoryID: {product.CategoryID}");
                Console.WriteLine($"On sale (t/f):{product.OnSale}");
                Console.WriteLine($"Stock level{product.StockLevel}");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(". . . . . . . . . .");
                Console.WriteLine();

            }

            #endregion




        }
    }
}