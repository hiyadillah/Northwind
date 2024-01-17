using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }

        public override string? ToString()
        {
            return $"CustomerId : {CustomerId} " +
                $"CompanyName : {CompanyName} " +
                $"ContactName : {ContactName} " +
                $"ContactTitle : {ContactTitle} ";
        }
    }
}
