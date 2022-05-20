using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tax_Calculator.Models
{
    public class Calculator
    {
        public double net { get; set; }

        public double gross { get; set; }
        public double vatRate { get; set; }

        public double vatAmount { get; set; }

        //public int result { get; set; }
    }
}
