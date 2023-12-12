namespace TaxCalculator.DB.Tables
{
    public class PostalCode 
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int TaxTypeId { get; set; }
        public TaxType TaxType { get; set; }
        public List<CalculationResult> CalculationResult { get; set; }
    }
}
