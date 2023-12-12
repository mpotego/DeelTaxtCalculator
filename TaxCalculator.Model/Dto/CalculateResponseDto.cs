namespace TaxCalculator.Model.Dto
{
    public class CalculateResponseDto : DtoBase
    {
        public CalculateDataDto Data { get; set; }
        public CalculateResponseDto()
        {
            Data = new CalculateDataDto();
        }
    }

    public class CalculateDataDto
    {
        public long Id { get; set; }
        public string PostalCode { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
