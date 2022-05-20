using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tax_Calculator.Interfaces
{
    public interface IVatServices
    {
        //double TotalCost(double productCost, double currentVATrate);
        double VatAmount(double pCost, double cRate);
        double OrigPrice(double incVAT, double cRate);
        double GrossAmount(double vatAmount, double cRate);
    }
}
