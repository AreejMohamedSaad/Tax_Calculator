using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax_Calculator.Models;
using Tax_Calculator.Services;
using Tax_Calculator.Interfaces;

namespace Tax_Calculator.Controllers
{

    public class CalculatorController : Controller
    {
        // set the private property of type IVatServices which will be used to call methods from the POST method.
        private IVatServices vatServices { get; set; }
        public CalculatorController(IVatServices vatServices)
        {
            this.vatServices = vatServices;
        }

        [HttpGet]
        public IActionResult Index()
         {
            return View(new Calculator());
        }

        [HttpPost]
        public IActionResult Index(Calculator cal , string calculate ,string resettozero)
        {
            // The instance of IVatServices has been resolved dynamically 
            // Dependency injection applied 
            if (resettozero == "reset")
            {
                return View(new Calculator());
            }
            if (calculate == "add")
                {
                if (cal.net != 0 && cal.gross != 0 && cal.vatAmount != 0)
                {
                    ViewBag.Message = "Please make sure you reset the values, so reset the two other values. Or click on the reset button.";

                }
                // calculate the vat amount and the gross
                else if (cal.vatAmount == 0 && cal.gross == 0 && cal.net != 0)
                    {
                        cal.vatAmount = vatServices.VatAmount(Convert.ToDouble(cal.net), Convert.ToDouble(cal.vatRate));
                        cal.gross = Convert.ToDouble(cal.net) + cal.vatAmount;
                    }
                    // calculate the vat amount and the net 
                    else if (cal.vatAmount == 0 && cal.net == 0 && cal.gross != 0)
                    {
                        cal.vatAmount = vatServices.OrigPrice(Convert.ToDouble(cal.gross), Convert.ToDouble(cal.vatRate));
                        cal.net = cal.gross - cal.vatAmount;

                    }
                    //calculate the net and the gross 
                    else if (cal.net == 0 && cal.gross == 0 && cal.vatAmount != 0)
                    {
                        cal.net = vatServices.GrossAmount(Convert.ToDouble(cal.vatAmount), Convert.ToDouble(cal.vatRate));
                        cal.gross = Convert.ToDouble(cal.net) + Convert.ToDouble(cal.vatAmount);
                    }
                //----------------------////----------------------////----------------------////----------------------//
                // cases when user leave the fields empty 
                    else if (cal.net == 0 && cal.gross == 0 && cal.vatAmount == 0)
                    {
                        ViewBag.Message = "You must enter one field either gross , net or VAT amount";
                    }

                    //cases when user enter more than on field
                    if (cal.vatAmount == 0 && cal.gross != 0 && cal.net != 0)
                    {
                        ViewBag.Message = "You must enter one field either gross , net or VAT amount";
                    }
                    else if (cal.vatAmount != 0 && cal.net == 0 && cal.gross != 0)
                    {
                        ViewBag.Message = "You must enter one field either gross , net or VAT amount";

                    }
                    else if (cal.net != 0 && cal.gross != 0 && cal.vatAmount == 0)
                    {
                        ViewBag.Message = "You must enter one field either gross , net or VAT amount";

                    }

            }

            return View("Views/Calculator/Index.cshtml", cal);
        }
    }
}
