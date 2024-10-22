namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveSurveyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyTemplate_SurveyTemplateId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "SurveyTemplate");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_SurveyTemplateId",
                table: "Surveys");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0310db65-f61f-46b5-8bcf-19678a6f71c0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("03e28188-053c-4c17-885f-898794057052"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("069a0c85-c867-4c45-9537-bd23f4d4db04"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0abd6cf3-feb3-4a0a-9f70-725f34a9eb6e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1489e3c4-942d-4d3a-bb1e-d39d6cff4fbf"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("39de26b2-2efb-4e25-8b00-691368507d8f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("46b70662-cebe-4043-8eff-8b9d8c7d8fbb"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("92de5a53-28fc-45e8-9f28-ef503a486c5e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a6eb717a-2a65-4897-bd56-952a7bd1fcdb"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a893f9c2-7beb-4ed7-9a42-3a8ba64ebabd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b25a6cd2-7143-4e87-b4e3-234529f02a97"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("eaf3726c-c8f6-4728-a371-ebcae2b89cec"));

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "SurveyTemplateId",
                table: "Surveys");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "QuestionIds",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("2470e833-06e2-41f3-ae66-2304ff6ea320"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("2ab09528-5c7b-46cc-9c6d-deae30d6d94d"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("3665a38e-b7a4-4753-ad7a-29436698c4ff"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("384cc30a-4aa8-4e24-842d-1450535ab0de"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("84971619-c6c6-4ebe-b1b3-c375bcdedaca"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("afb3da2b-60f7-4c97-9770-5d8216350fc0"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("bb43643d-926d-4b4a-9bcd-701622e2ac74"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("c1272ae8-5c2d-4eaf-b721-d87baafbc615"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("d6fdb850-eb7d-4008-be68-e2f7190f1364"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("e44665a5-2530-4476-86ff-5277063c19ed"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("e9caacb5-f2ce-4b86-bd2f-5b833ee4218e"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("fa5d8c59-4412-4a45-b0de-aa5abe6bf5d0"), null, null, "email", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJB8A2ZGb5FJHgdKwUV/b9CAiEpp0e3HwK7rQTVDKay6fQhUepTC/ckDRC1kULlTMA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2470e833-06e2-41f3-ae66-2304ff6ea320"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2ab09528-5c7b-46cc-9c6d-deae30d6d94d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3665a38e-b7a4-4753-ad7a-29436698c4ff"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("384cc30a-4aa8-4e24-842d-1450535ab0de"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("84971619-c6c6-4ebe-b1b3-c375bcdedaca"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("afb3da2b-60f7-4c97-9770-5d8216350fc0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bb43643d-926d-4b4a-9bcd-701622e2ac74"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c1272ae8-5c2d-4eaf-b721-d87baafbc615"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d6fdb850-eb7d-4008-be68-e2f7190f1364"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e44665a5-2530-4476-86ff-5277063c19ed"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e9caacb5-f2ce-4b86-bd2f-5b833ee4218e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fa5d8c59-4412-4a45-b0de-aa5abe6bf5d0"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "QuestionIds",
                table: "Surveys");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyTemplateId",
                table: "Surveys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SurveyTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTemplate", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0310db65-f61f-46b5-8bcf-19678a6f71c0"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("03e28188-053c-4c17-885f-898794057052"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("069a0c85-c867-4c45-9537-bd23f4d4db04"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("0abd6cf3-feb3-4a0a-9f70-725f34a9eb6e"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("1489e3c4-942d-4d3a-bb1e-d39d6cff4fbf"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("39de26b2-2efb-4e25-8b00-691368507d8f"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("46b70662-cebe-4043-8eff-8b9d8c7d8fbb"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("92de5a53-28fc-45e8-9f28-ef503a486c5e"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("a6eb717a-2a65-4897-bd56-952a7bd1fcdb"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("a893f9c2-7beb-4ed7-9a42-3a8ba64ebabd"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("b25a6cd2-7143-4e87-b4e3-234529f02a97"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("eaf3726c-c8f6-4728-a371-ebcae2b89cec"), null, null, "currency", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOEnrpgsLPxzkbSufPfDVVN0AjcQjYOIG8UEZ8oiqBhIFy3GT2rsF2O7/1uObpCfPQ==");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyTemplateId",
                table: "Surveys",
                column: "SurveyTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_SurveyTemplate_SurveyTemplateId",
                table: "Surveys",
                column: "SurveyTemplateId",
                principalTable: "SurveyTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
