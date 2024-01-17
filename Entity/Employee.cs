using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    internal class Employee
    {
        public long EmployeeId { get; set; }
        public string ? LastName { get; set; }
        public string ? FirstName { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        //public DateTime HireDate { get; set; }

        public override string? ToString()
        {
            return $"[EmployeeId : {EmployeeId}, LastName : {LastName}, FirstName : {FirstName}, TitleOfCourtesy : {TitleOfCourtesy}, BirthDate : {BirthDate}]";
        }
    }
}
