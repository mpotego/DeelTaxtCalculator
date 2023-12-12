using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.CalculationManagement.Service;
using TaxCalculator.DB.Tables;

namespace TaxCalculator.DB
{
    public class TaxCalculatorDbContext : DbContext
    { 
        public virtual DbSet<TaxType> TaxtTypes { get; set; }
        public virtual DbSet<CalculationType> CalculationTypes { get; set; }
        public virtual DbSet<PayRangeSetting> PayRangeSettings { get; set; }
        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<CalculationResult> CalculationResults { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            #region Seeding LookUpData

            modelBuilder.Entity<TaxType>().HasData(
                DataHelper.TaxTypes
                //new TaxType { Id = 1, Description = "Progressive", Name = "Progressive" },
                //new TaxType { Id = 2, Description = "FlatRate", Name = "FlatRate" },
                //new TaxType { Id = 3, Description = "FlatValue", Name = "FlatValue" }
                );

            modelBuilder.Entity<CalculationType>().HasData(
                DataHelper.CalculationTypes
                //new CalculationType { Id = 1, Description = "Percentage", Name = "Percentage" },
                //new CalculationType { Id = 2, Description = "FlatRate", Name = "FlatValue" }
                );
            #endregion

            #region Seeding TestData

            modelBuilder.Entity<PostalCode>().HasData(
                DataHelper.PostalCodeList
            //new PostalCode() { Id = 1, Code = "7441", TaxTypeId = 1 },
            //new PostalCode() { Id = 2, Code = "1000", TaxTypeId = 1 },
            //new PostalCode() { Id = 3, Code = "7000", TaxTypeId = 2 },
            //new PostalCode() { Id = 4, Code = "A100", TaxTypeId = 3 }
            );

            modelBuilder.Entity<PayRangeSetting>().HasData(
                DataHelper.PayRangeSettingModelList
            //new PayRangeSetting() { Id = 1, TaxTypeId = 1, CalculationTypeId = 1, CalculationValue = 10, From = 0, To = 8350 },
            //new PayRangeSetting() { Id = 2, TaxTypeId = 1, CalculationTypeId = 1, CalculationValue = 15, From = 8351, To = 33950 },
            //new PayRangeSetting() { Id = 3, TaxTypeId = 1, CalculationTypeId = 1, CalculationValue = 25, From = 33951, To = 82250 },
            //new PayRangeSetting() { Id = 4, TaxTypeId = 1, CalculationTypeId = 1, CalculationValue = 28, From = 82251, To = 171550 },
            //new PayRangeSetting() { Id = 5, TaxTypeId = 1, CalculationTypeId = 1, CalculationValue = 33, From = 171551, To = 372950 },
            //new PayRangeSetting() { Id = 6, TaxTypeId = 1, CalculationTypeId = 1, CalculationValue = 35, From = 372951, To = null },

            //new PayRangeSetting() { Id = 7, TaxTypeId = 3, CalculationTypeId = 1, CalculationValue = 5, From = 0, To = 199999 },
            //new PayRangeSetting() { Id = 8, TaxTypeId = 3, CalculationTypeId = 2, CalculationValue = 10000, From = 200000, To = null },

            //new PayRangeSetting() { Id = 9, TaxTypeId = 2, CalculationTypeId = 1, CalculationValue = (decimal)17.5, From = 0, To = null }
            );

            #endregion
        }
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options)
       : base(options)
        {
        }
    }
}
