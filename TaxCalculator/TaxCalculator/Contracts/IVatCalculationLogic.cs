using System.Collections.Generic;
using TaxCalculator.Models;

namespace TaxCalculator.Contracts
{
    public interface IVatCalculationLogic
    {
        VatComponent CalculateVat(decimal vatRate, decimal inputAmount, VatInputType vatInputType);
        bool ValidTaxRate(decimal taxRates);
    }
}
