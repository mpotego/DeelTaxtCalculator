using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Model.Dto
{
    public class GetCalculationsResponseDto : DtoBase
    {
        public List<CalculationResultDto> Data { get; set; } = new List<CalculationResultDto>();
    }

    public class CalculationResultDto
    {
        public long Id { get; set; }
        public long PostalCodeId { get; set; }
        public string PostalCode { get; set; }
        public decimal PayAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public int TaxtTypeId { get; set; }
        public string TaxtTypeName{ get; set; }
        public long AppliedTaxId { get; set; }
        public string AppliedTax{ get; set; }
        public DateTime Created { get; set; }  
    }
}
