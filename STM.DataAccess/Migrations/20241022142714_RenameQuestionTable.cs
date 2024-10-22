namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("061ee926-1274-40b6-98c3-82cf68083888"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("34bbc1b0-b7ab-49e7-9e74-db1b6b4693c3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("55499f06-6670-4ed6-9b72-f27e00e80e91"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6dcc1c35-45dd-47ab-8c79-ddd21c5ce786"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("79c0769a-b9b3-4312-a980-2afa42e6b5f3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("885184fe-ea91-475b-8c35-3eec7726d732"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a6e84c2a-b0c8-43e7-bf14-76a03e7fde12"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a8682cfb-0fa2-4fd7-be27-229ad3f566ad"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cb58b935-135e-4e2b-ac14-f930c0327178"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ce966bee-77ef-4fd3-8581-2edc829cc61b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e86478f3-596a-4022-bd16-881828dce96a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fde3bb8a-f5f6-469b-aa15-57fe7e6d4e5c"));

            migrationBuilder.RenameColumn(
                name: "SurveyTypeEnum",
                table: "SurveyTemplate",
                newName: "Type");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "SurveyTemplate",
                newName: "SurveyTypeEnum");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("061ee926-1274-40b6-98c3-82cf68083888"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("34bbc1b0-b7ab-49e7-9e74-db1b6b4693c3"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("55499f06-6670-4ed6-9b72-f27e00e80e91"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("6dcc1c35-45dd-47ab-8c79-ddd21c5ce786"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("79c0769a-b9b3-4312-a980-2afa42e6b5f3"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("885184fe-ea91-475b-8c35-3eec7726d732"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("a6e84c2a-b0c8-43e7-bf14-76a03e7fde12"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("a8682cfb-0fa2-4fd7-be27-229ad3f566ad"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("cb58b935-135e-4e2b-ac14-f930c0327178"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("ce966bee-77ef-4fd3-8581-2edc829cc61b"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("e86478f3-596a-4022-bd16-881828dce96a"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("fde3bb8a-f5f6-469b-aa15-57fe7e6d4e5c"), null, null, "phone", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBaaZRaHKAlQqOmtlcbTWSLgt8NWmVT3Sr2m6Oqfz+c47794keYtsFe/WSmORtIocQ==");
        }
    }
}
