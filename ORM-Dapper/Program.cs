using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;



namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            //^^^^MUST HAVE USING DIRECTIVES^^^^

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            //var depRepo = new DepartmentRepo(conn);

            //Console.WriteLine("Enter the name of the department you would like to create:");
            //var departmentName = Console.ReadLine();

            //depRepo.InsertDepartment(departmentName);

            //var departments = depRepo.GetAllDeparts();

            //foreach (var dep in departments)
            //{
            //    Console.WriteLine($"ID: {dep.DepartmentID}| Name: {dep.Name} ");
            //}

            var productRepo = new ProductRepo(conn);

           

            // productRepo.CreateProduct("Fallout: New Vegas",140.00,8,true,250);
            // productRepo.UpdateProduct(940, "Kate Fallout");
            productRepo.DeleteProduct(940);
            var products =productRepo.GetAllProdcuts();

            foreach (var product in products)
            {
                Console.WriteLine($"ID:{product.ProductID} | Name: {product.Name} | CategoryID: {product.CategoryID} | Price: {product.Price} | OnSale: {product.OnSale} | StockLevel:{product.StockLevel}");
            }

        }
    }
}
