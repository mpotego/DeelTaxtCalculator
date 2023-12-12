namespace TaxCalculator.DB.Tables
{
    public class CalculationType 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PayRangeSetting> PayRangeSettings { get; set; }
    }
}
