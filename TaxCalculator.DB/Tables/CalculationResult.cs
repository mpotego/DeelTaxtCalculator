namespace TaxCalculator.DB.Tables
{
    public class CalculationResult
    {
        public long Id { get; set; }
        public long PostalCodeId { get; set; }
        public decimal PayAmount { get; set; }
        public long PayRangeSettingId { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public List<PostalCode> PostalCodes { get; set; }
        public List<PayRangeSetting> PayRangeSetting { get; set; }   
    }
}
