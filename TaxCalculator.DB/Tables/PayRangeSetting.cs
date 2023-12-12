
namespace TaxCalculator.DB.Tables
{
    public class PayRangeSetting 
    {
        public long Id { get; set; }
        public int TaxTypeId { get; set; }
        public decimal From { get; set; }
        public decimal? To { get; set; }
        public int CalculationTypeId { get; set; }
        public decimal CalculationValue { get; set; }

        public CalculationType CalculationType { get; set; }
        public TaxType TaxtType { get; set; }
        public List<CalculationResult> CalculationResults { get; set; }
    }
}
