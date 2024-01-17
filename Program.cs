using Day06.Repository;
using Day06.DbContext;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Day06.Entity;
using System.Reflection;
using System.Security.AccessControl;

internal class Program
{
    private static IConfigurationRoot Configuration;                                                                                           
    static async Task Main(string[] args)
    {
        BuildConfiguration();
        var adoDbContext = new AdoDbContext(Configuration.GetConnectionString("NorthWindDs"));
        var dapper = new DapperDbContext(Configuration.GetConnectionString("NorthWindDS"));

        {
            // call supplierrepo 
            SupplierRepository supprepo = new SupplierRepository(adoDbContext,dapper);


            // SAVE / INSERT
            //var supp1=new Supplier() { CompanyName = "Axa", ContactName = "Abdul", ContactTitle = "Mr" };
            //supprepo.Save(supp1);


            // UPDATE
            //var supp2=new Supplier() { CompanyName = "Codeid", ContactName = "Alex", ContactTitle = "Mr" };
            //supprepo.Update(30,supp2);


            // DELETE
            //supprepo.Delete(30);


            // FIND BY ID
            //IEnumerator<Supplier> supplier = supprepo.FindById(1).GetEnumerator();
            //while (supplier.MoveNext())
            //{
            //    Console.WriteLine(supplier.Current.ToString());
            //}

            // FIND ALL
            IEnumerable<Supplier> suppliers = supprepo.FindAll();
            foreach (var item in suppliers)
            {
                await Console.Out.WriteLineAsync($"{item.ToString()}");
            }
        }
        
    }
    private static void BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
        Configuration= builder.Build();
        Console.WriteLine(Configuration.GetConnectionString("NorthWindDS"));
    }

}