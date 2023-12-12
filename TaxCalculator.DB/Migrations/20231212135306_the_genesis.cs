using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.DB.Migrations
{
    public partial class the_genesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCodeId = table.Column<long>(type: "bigint", nullable: false),
                    PayAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayRangeSettingId = table.Column<long>(type: "bigint", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxtTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxtTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayRangeSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    To = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CalculationTypeId = table.Column<int>(type: "int", nullable: false),
                    CalculationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayRangeSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayRangeSettings_CalculationTypes_CalculationTypeId",
                        column: x => x.CalculationTypeId,
                        principalTable: "CalculationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayRangeSettings_TaxtTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxtTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostalCodes_TaxtTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxtTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculationResultPayRangeSetting",
                columns: table => new
                {
                    CalculationResultsId = table.Column<long>(type: "bigint", nullable: false),
                    PayRangeSettingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResultPayRangeSetting", x => new { x.CalculationResultsId, x.PayRangeSettingId });
                    table.ForeignKey(
                        name: "FK_CalculationResultPayRangeSetting_CalculationResults_CalculationResultsId",
                        column: x => x.CalculationResultsId,
                        principalTable: "CalculationResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalculationResultPayRangeSetting_PayRangeSettings_PayRangeSettingId",
                        column: x => x.PayRangeSettingId,
                        principalTable: "PayRangeSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculationResultPostalCode",
                columns: table => new
                {
                    CalculationResultId = table.Column<long>(type: "bigint", nullable: false),
                    PostalCodesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResultPostalCode", x => new { x.CalculationResultId, x.PostalCodesId });
                    table.ForeignKey(
                        name: "FK_CalculationResultPostalCode_CalculationResults_CalculationResultId",
                        column: x => x.CalculationResultId,
                        principalTable: "CalculationResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalculationResultPostalCode_PostalCodes_PostalCodesId",
                        column: x => x.PostalCodesId,
                        principalTable: "PostalCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CalculationTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Percentage", "Percentage" },
                    { 2, "FlatRate", "FlatValue" }
                });

            migrationBuilder.InsertData(
                table: "TaxtTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Progressive", "Progressive" },
                    { 2, "FlatRate", "FlatRate" },
                    { 3, "FlatValue", "FlatValue" }
                });

            migrationBuilder.InsertData(
                table: "PayRangeSettings",
                columns: new[] { "Id", "CalculationTypeId", "CalculationValue", "From", "TaxTypeId", "To" },
                values: new object[,]
                {
                    { 1L, 1, 10m, 0m, 1, 8350m },
                    { 2L, 1, 15m, 8351m, 1, 33950m },
                    { 3L, 1, 25m, 33951m, 1, 82250m },
                    { 4L, 1, 28m, 82251m, 1, 171550m },
                    { 5L, 1, 33m, 171551m, 1, 372950m },
                    { 6L, 1, 35m, 372951m, 1, null },
                    { 7L, 1, 5m, 0m, 3, 199999m },
                    { 8L, 2, 10000m, 200000m, 3, null },
                    { 9L, 1, 17.5m, 0m, 2, null }
                });

            migrationBuilder.InsertData(
                table: "PostalCodes",
                columns: new[] { "Id", "Code", "TaxTypeId" },
                values: new object[,]
                {
                    { 1L, "7441", 1 },
                    { 2L, "1000", 1 },
                    { 3L, "7000", 2 },
                    { 4L, "A100", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationResultPayRangeSetting_PayRangeSettingId",
                table: "CalculationResultPayRangeSetting",
                column: "PayRangeSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculationResultPostalCode_PostalCodesId",
                table: "CalculationResultPostalCode",
                column: "PostalCodesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayRangeSettings_CalculationTypeId",
                table: "PayRangeSettings",
                column: "CalculationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayRangeSettings_TaxTypeId",
                table: "PayRangeSettings",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCodes_TaxTypeId",
                table: "PostalCodes",
                column: "TaxTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationResultPayRangeSetting");

            migrationBuilder.DropTable(
                name: "CalculationResultPostalCode");

            migrationBuilder.DropTable(
                name: "PayRangeSettings");

            migrationBuilder.DropTable(
                name: "CalculationResults");

            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "CalculationTypes");

            migrationBuilder.DropTable(
                name: "TaxtTypes");
        }
    }
}
