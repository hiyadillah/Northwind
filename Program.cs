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
            //// call interface, implement solid dependency inversion
            IRepository repositoryDB = new RepositoryDB(adoDbContext);

            //1.call method di interface, FindAll return IEnumerator, tuk dapat value harus di loop dulu
            //var employees = repositoryDB.FindAll();
            //while (employees.MoveNext())
            //{
            //    var employee = employees.Current;
            //    Console.WriteLine(employee.ToString());
            //}



            //2. FindAllEmployee() return IEnumerable langsung dapat di loop using foreach
            //var emps = repositoryDB.FindAllEmployee();
            //foreach (var employee in emps)
            //{
            //    Console.WriteLine(employee.ToString());
            //}

            //3. FindEmployeeById
            //var foundEmployee = repositoryDB.FindEmployeeById(2);
            //Console.WriteLine($"Found Empployee : {foundEmployee}");

            //4. FindEmployeeByFirstName
            //var filterEmployeeByName = repositoryDB.FindEmployeeByFirstName("A%");
            //foreach (var employee in filterEmployeeByName)
            //{
            //    Console.WriteLine(employee.ToString());
            //}

            //5. createEmployee, EmployeeId ga diisi, otomatis dari sequence database
            //var newEmps = new Employee
            //{
            //    FirstName = "Yuli",
            //    LastName = "Ayu",
            //    BirthDate = DateTime.Now
            //};

            //newEmps = repositoryDB.CreateEmployee(ref newEmps);
            //Console.WriteLine(newEmps.ToString());

            //6. Update Employee
            //var findUpdateEmps = new Employee
            //{
            //    EmployeeId = 11,
            //    FirstName = "Widi",
            //    LastName = "Wini",
            //    BirthDate = DateTime.Now
            //};

            //var updateEmp = repositoryDB.UpdateEmployee(findUpdateEmps);
            //Console.WriteLine(updateEmp.ToString());


            //7. delete employee by id 10
            //repositoryDB.DeleteEmployee(10);

            //8. call method async
            //var employeeAsync = repositoryDB.FindAllEmployeeAsync();
            //foreach (var item in await employeeAsync)
            //{
            //    Console.WriteLine($"te{im.ToString()}");
            //}

            //9. Call Generic Method
            //IRepositoryBase<Employee> repositoryEmps = new EmployeeRepository(adoDbContext,dapper);
            //var employeeGeneric = repositoryEmps.FindAll<Employee>();
            //foreach (var employee in employeeGeneric)
            //{
            //    Console.WriteLine($"{employee.ToString()}");
            //}

            //10. AGUS KEREN
        }
        {
            // call interface, implement customer repository
            IRepositoryBase<Customer> custRepo = new CustomerRepository(adoDbContext,dapper);

            // call method di interface
            //var customers = custRepo.FindAll();
            //while (customers.MoveNext())
            //{
            //    Console.WriteLine($"[{customers.Current.ToString()}]");
            //}

            //var customer = custRepo.FindById("AGUS");
            //if (customer == null) Console.WriteLine($"Customer tidak ditemukan");
            //else Console.WriteLine($"{customer.ToString()}");

        }
        {
            // call supplierrepo 
            SupplierRepository supprepo = new SupplierRepository(adoDbContext,dapper);

            //// call method

            //var supp1=new Supplier() { CompanyName = "Axa", ContactName = "Abdul", ContactTitle = "Mr" };
            //supprepo.Save(supp1);

            //var supp2=new Supplier() { CompanyName = "Codeid", ContactName = "Alex", ContactTitle = "Mr" };
            //supprepo.Update(30,supp2);

            supprepo.Delete(30);



            IEnumerable<Supplier> supplier = supprepo.FindById(1);
            foreach (Supplier item in supplier)
            {
                Console.WriteLine($"{item.ToString()}");
            }


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