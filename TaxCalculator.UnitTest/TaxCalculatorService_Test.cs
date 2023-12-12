using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using TaxCalculator.Core.CalculationManagement.Service;
using TaxCalculator.Core.CalculationManagement.Service.Calculator;
using TaxCalculator.Core.CalculationManagement.Service.Data;
using TaxCalculator.DB;
using TaxCalculator.DB.Tables;
using TaxCalculator.Model.Dto;
using TaxCalculator.Model.Enum;

namespace TaxCalculator.UnitTest
{
    [TestFixture]
    public class TaxCalculatorService_Test
    { 
        private CalculatorService _calculatorService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<TaxCalculatorDbContext>()
                    .Options;
            var _dbContext = new Mock<TaxCalculatorDbContext>(options);
            _dbContext.Setup(x => x.PostalCodes).ReturnsDbSet(DataHelper.PostalCodeList);
            _dbContext.Setup(x => x.PayRangeSettings).ReturnsDbSet(DataHelper.PayRangeSettingModelList);
            _dbContext.Setup(x => x.TaxtTypes).ReturnsDbSet(DataHelper.TaxTypes);
            _dbContext.Setup(x => x.CalculationTypes).ReturnsDbSet(DataHelper.CalculationTypes);
            _dbContext.Setup<DbSet<CalculationResult>>(x => x.CalculationResults).ReturnsDbSet(new List<CalculationResult>(){
                new CalculationResult()
            {
                PayAmount = 1,
                PayRangeSettingId = 1,
                PostalCodeId = 1,
                TaxAmount = 1,
            }});

            DataService _dbDataService = new DataService(_dbContext.Object);

            _calculatorService = new CalculatorService(_dbDataService);
        }

        #region Validation
        [Test]
        public async Task Calculate_NullRequest_ReturnsError()
        {
            var calculateResult = await _calculatorService.CalculateAsync(null);
            Assert.IsFalse(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.ErrorList.Count == 1);
        }

        [Test]
        public async Task Calculate_EmptyRequestProperties_ReturnsErrors()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto());
            Assert.IsFalse(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.ErrorList.Count == 2);
        }

        [Test]
        public async Task Calculate_ValidRequest_CallGetPayRangeSettingAsync()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 500,
                PostalCode = "12345",
            });

            Assert.IsFalse(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.ErrorList.Count == 1);
        }
        #endregion

        #region Progresive
        [Test]
        public async Task Calculate_372951_ResultTest()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 372951,
                PostalCode = "7441",
            });

            Assert.IsTrue(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.Data.TaxAmount == 130532.85M);
            Assert.IsEmpty(calculateResult.ErrorList);
        }

        [Test]
        public async Task Calculate_171551_ResultTest()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 171551,
                PostalCode = "7441",
            });

            Assert.IsTrue(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.Data.TaxAmount == 56611.83M);
            Assert.IsEmpty(calculateResult.ErrorList);
        }

        [Test]
        public async Task Calculate_82250_ResultTest()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 82250,
                PostalCode = "1000",
            });

            Assert.IsTrue(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.Data.TaxAmount == 20562.50M);
            Assert.IsEmpty(calculateResult.ErrorList);
        }
        #endregion

        //Flat rate
        [Test]
        public async Task Calculate_200000_ResultTest()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 200000,
                PostalCode = "7000",
            });

            Assert.IsTrue(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.Data.TaxAmount == 35000M);
            Assert.IsEmpty(calculateResult.ErrorList);
        }

        #region Flat Value
        [Test]
        public async Task Calculate_200000_FVResultTest()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 200000,
                PostalCode = "A100",
            });

            Assert.IsTrue(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.Data.TaxAmount == 10000M);
            Assert.IsEmpty(calculateResult.ErrorList);
        }
         
        [Test]
        public async Task Calculate_19999_ResultTest()
        {
            var calculateResult = await _calculatorService.CalculateAsync(new Model.Dto.CalculateRequestDto()
            {
                Amount = 199999,
                PostalCode = "A100",
            });

            Assert.IsTrue(calculateResult.IsSuccessfull);
            Assert.IsTrue(calculateResult.Data.TaxAmount == 9999.95M);
            Assert.IsEmpty(calculateResult.ErrorList);
        }
        #endregion

        [Test]
        public async Task GetCalculations_EmptyResultTest()
        {  
            var calculateResult = await _calculatorService.GetCalculationsAsync(new GetCalculationsRequestDto(){ });

            Assert.IsTrue(calculateResult.IsSuccessfull); 
            Assert.IsEmpty(calculateResult.ErrorList);
            Assert.IsNotEmpty(calculateResult.Data);
        }


    }
}