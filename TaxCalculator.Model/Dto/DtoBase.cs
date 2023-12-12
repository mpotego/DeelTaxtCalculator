namespace TaxCalculator.Model.Dto
{
    public class DtoBase
    {
        public List<string> ErrorList { get;set; } = new List<string>();
        public bool IsSuccessfull => ErrorList.Count == 0;
    }
}
