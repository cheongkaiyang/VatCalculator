using System.Collections.Generic;
using TaxCalculator.Contracts;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public class VatCalculationLogic: IVatCalculationLogic
    {
        public VatComponent CalculateVat(decimal vatRate, decimal inputAmount, VatInputType vatInputType)
        {
            decimal vat = 0;
            decimal gross = 0;
            decimal net = 0;
            
            switch(vatInputType)
            {
                case VatInputType.Vat:
                    vat = inputAmount;
                    net = inputAmount / vatRate;
                    gross = net + vat;

                    break;

                case VatInputType.Net:
                    net = inputAmount;
                    vat = net * vatRate;
                    gross = net + vat;

                    break;

                case VatInputType.Gross:
                    gross = inputAmount;
                    net = gross / (1 + vatRate);
                    vat = gross - net;

                    break;

                default:
                    break;
            }

            return new VatComponent()
            {
                GrossAmount = gross,
                NetAmount = net,
                VatRate = vatRate,
                VatAmount = vat
            };
        }
        public bool ValidTaxRate(decimal taxRate)
        {
            var taxRates = GetTaxRate();
            if (taxRates.Contains(taxRate))
            {
                return true;
            }

            return false;
        }

        private IList<decimal> GetTaxRate()
        {
            IList<decimal> taxRates = new List<decimal>
            {
                (decimal)0.10,
                (decimal)0.13,
                (decimal)0.20
            };

            return taxRates;
        }
    }
}
