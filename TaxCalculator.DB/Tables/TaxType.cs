namespace TaxCalculator.DB.Tables
{
    public class TaxType 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PayRangeSetting> PayRangeSettings { get; set; }
        public List<PostalCode> PostalCodes { get; set; } 
    }
}
