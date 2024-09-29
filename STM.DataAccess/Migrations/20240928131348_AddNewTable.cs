namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0f7cbdb2-1f9a-4196-99ae-cbf55dfffff7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1d8b2bc8-4c19-4375-b840-e84a3d56f4b8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4db18901-6426-40ab-82ec-2053f7cc8d76"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("69d610c3-de3f-4712-95a8-110c22c01ad1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6e8559f8-ded9-4c27-9b57-c1d938e97290"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("94bdde1b-9b19-487f-a22e-b09a361447bc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("99ba7f07-2ce5-4a2f-b407-96044b4ef5c2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a3ecb710-d26e-4b40-912f-f98e346c31bc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a77d4919-1c44-4c9b-bf5b-7c593f74538f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b3254c52-6528-4b12-b597-dccf2993b982"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f2fe49b2-1ff9-4185-9a08-50faf2481e5f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f6209a8a-ef7e-42b6-b543-da201337af7d"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0f7cbdb2-1f9a-4196-99ae-cbf55dfffff7"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("1d8b2bc8-4c19-4375-b840-e84a3d56f4b8"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("4db18901-6426-40ab-82ec-2053f7cc8d76"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("69d610c3-de3f-4712-95a8-110c22c01ad1"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("6e8559f8-ded9-4c27-9b57-c1d938e97290"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("94bdde1b-9b19-487f-a22e-b09a361447bc"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("99ba7f07-2ce5-4a2f-b407-96044b4ef5c2"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("a3ecb710-d26e-4b40-912f-f98e346c31bc"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("a77d4919-1c44-4c9b-bf5b-7c593f74538f"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("b3254c52-6528-4b12-b597-dccf2993b982"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("f2fe49b2-1ff9-4185-9a08-50faf2481e5f"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("f6209a8a-ef7e-42b6-b543-da201337af7d"), null, null, "webName", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMszbWb+Q/CldCgJpE09ef6j7XmOQ1eCVovITxjomO4S/yhs5O6p/aLhvkdehBKcGQ==");
        }
    }
}
