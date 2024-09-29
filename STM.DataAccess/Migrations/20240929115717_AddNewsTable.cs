namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddNewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("07b87706-ce4b-4c05-a638-cb63e6cf39da"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("70077e24-a670-4260-9d3a-e3de86f3f1cf"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("793ff693-7bd8-4336-9279-ea9bec40252b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("825a2513-ce13-40c2-a6e5-ae8dbc38a275"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("866861e5-71cf-48a0-bfca-c56d2303070b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8e6a9507-6db4-4976-8902-66f8f0ef2bbf"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("aa11f037-1aa4-4db9-9a52-5af5fe7a7c4b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bb6f4c5b-da4d-48d4-88e4-e14b8fe82679"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bec790dd-987f-4611-b75a-03be06432974"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c7e89116-a9a3-470b-9dad-801767cbc0bd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("eeb45bba-bf70-4c5d-9906-f3f79d7026c2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f535a697-78a5-4929-94d7-c0338fbd55fc"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0b6877d6-7a0c-4ab1-9e2e-eb010c3fae63"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("12bfb091-c853-40f0-b424-6688f50375bd"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("54f8dfa4-76d3-4ff3-b314-5eda698cc756"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("5b70e532-7ddf-4c32-9794-ca5c96290583"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("798542a6-dca9-45c3-b8e4-584f6c64cdf1"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("7e0a4739-1801-4c35-b65b-d31595f8bfb8"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("9b791c09-7f75-4a14-9dbe-f059eb097c10"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("b81c34cf-ae18-46e9-919a-ba3c1ae4394b"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("c398b806-b20f-48ad-9243-b189d0d3acf3"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("d2dc8ad8-c5cf-490f-9a48-d48424a14cc6"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("fb4d9e5d-041e-48d2-8210-752e44e2374e"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("fd90597c-1acc-4eab-9fae-ee6727fc85aa"), null, null, "phone", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEC+gpv/qdtLvSIPzKUB5plc0QUx15PSvrPt/7q4z72O/UW8S76pKgAo81+JVwG2znQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0b6877d6-7a0c-4ab1-9e2e-eb010c3fae63"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("12bfb091-c853-40f0-b424-6688f50375bd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("54f8dfa4-76d3-4ff3-b314-5eda698cc756"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("5b70e532-7ddf-4c32-9794-ca5c96290583"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("798542a6-dca9-45c3-b8e4-584f6c64cdf1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7e0a4739-1801-4c35-b65b-d31595f8bfb8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9b791c09-7f75-4a14-9dbe-f059eb097c10"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b81c34cf-ae18-46e9-919a-ba3c1ae4394b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c398b806-b20f-48ad-9243-b189d0d3acf3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d2dc8ad8-c5cf-490f-9a48-d48424a14cc6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fb4d9e5d-041e-48d2-8210-752e44e2374e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fd90597c-1acc-4eab-9fae-ee6727fc85aa"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("07b87706-ce4b-4c05-a638-cb63e6cf39da"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("70077e24-a670-4260-9d3a-e3de86f3f1cf"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("793ff693-7bd8-4336-9279-ea9bec40252b"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("825a2513-ce13-40c2-a6e5-ae8dbc38a275"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("866861e5-71cf-48a0-bfca-c56d2303070b"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("8e6a9507-6db4-4976-8902-66f8f0ef2bbf"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("aa11f037-1aa4-4db9-9a52-5af5fe7a7c4b"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("bb6f4c5b-da4d-48d4-88e4-e14b8fe82679"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("bec790dd-987f-4611-b75a-03be06432974"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("c7e89116-a9a3-470b-9dad-801767cbc0bd"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("eeb45bba-bf70-4c5d-9906-f3f79d7026c2"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("f535a697-78a5-4929-94d7-c0338fbd55fc"), null, null, "email", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOvcIsY81T7yA2BfmG4zcceIve02ssuqG+SJrg4em1/J4WRrTrTYmbsmNSI7CBnfmg==");
        }
    }
}
