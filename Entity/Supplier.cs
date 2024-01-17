﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    public class Supplier
    {

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }

        public override string? ToString()
        {
            return $"SupplierId : {SupplierId}  " +
                $"CompanyName : {CompanyName}   " +
                $"ContactName : {ContactName}   " +
                $"ContactTitle : {ContactTitle}    ";
        }
    }
}
