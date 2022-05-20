using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax_Calculator.Interfaces;


namespace Tax_Calculator.Services
{
    public class VatServices : IVatServices
    {
        // calculate the VAT amount 
        public double VatAmount(double pCost, double cRate)
        {
            double vA = (cRate + 100) / 100;
            double tCost = pCost * vA;
            double result = tCost - pCost;
            return result;
        }

        // calculate the original price 
        public double OrigPrice(double incVAT, double cRate)
        {
            double cPrice = (cRate + 100) / 100;
            double oPrice = incVAT / cPrice;
            return incVAT - oPrice;
        }

        // calculate the gross price
        public double GrossAmount(double vatAmount, double cRate)
        {
            double net = vatAmount / (cRate / 100);
            double result = net;
            return result;
        }
        
    }
}

