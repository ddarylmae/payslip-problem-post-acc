using System;
using PayslipGeneratorCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var payslipConsole = new PayslipGeneratorConsole(
                new InputReader(),
                new OutputWriter(), 
                new PayslipGenerator(new TaxRates2017To2018()));
            
            payslipConsole.Run();
        }
    }
}