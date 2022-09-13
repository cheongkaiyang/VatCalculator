using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Contracts;
using TaxCalculator.Dto;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    [ApiController]
    public class VatController : ControllerBase
    {
        private readonly ILogger<VatController> _logger;
        private readonly IVatCalculationLogic _vatLogic;

        public VatController(ILogger<VatController> logger, IVatCalculationLogic vatLogic)
        {
            _logger = logger;
            _vatLogic = vatLogic;
        }

        /// <summary>
        /// API call to get VAT calculation details
        /// </summary>
        /// <param name="vatRate">VAT Rate</param>
        /// <param name="inputAmount">Input Amount</param>
        /// <param name="inputType">Input Type</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/GetDetail/{vatRate}/{inputAmount}/{inputType}")]
        public ActionResult<VatDetailDto> VatDetail(decimal vatRate, decimal inputAmount, VatInputType inputType)
        {
            if (!_vatLogic.ValidTaxRate(vatRate) || vatRate <= 0)
            {
                return BadRequest("Invalid tax rate entered");
            }
            if (inputAmount <= 0)
            {
                return BadRequest("Input amount must be greater than 0");
            }

            var vatComponent = _vatLogic.CalculateVat(vatRate, inputAmount, inputType);

            var response = new VatDetailDto()
            {
                VatRate = vatRate,
                VatAmount = vatComponent.VatAmount,
                GrossAmount = vatComponent.GrossAmount,
                NetAmount = vatComponent.NetAmount,
            };

            return response;
        }
    }
}
