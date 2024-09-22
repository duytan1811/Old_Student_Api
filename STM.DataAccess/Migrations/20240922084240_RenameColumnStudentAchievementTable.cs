namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameColumnStudentAchievementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0d7c8dc4-facc-44d6-a325-febb910e77f7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("14209333-92c4-44cb-b0ae-3da275cec47d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("14e930b0-31fd-4ad1-9e68-80f3b2e612e0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1602f7b8-cc74-46ba-a18c-8ec021e4b13e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("32df5c3c-2017-45c4-8732-fd3ee4744c94"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6630324f-4962-47d6-8b73-61d7190c0db0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("722a4170-8032-4762-bbba-61cb36961e34"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8025341c-2038-49bd-b1f6-01bbfa906bc9"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b7aebc13-c6c2-4bc1-bc0f-16ac10773884"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("df61e86f-863b-4018-aeae-64e137b91589"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ecd8a8d5-fee4-462d-bc20-5c454f1c75ee"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f9c1286e-3bd8-4d8b-bfa2-1b17480ef178"));

            migrationBuilder.RenameColumn(
                name: "FormDate",
                table: "StudentAchievements",
                newName: "FromDate");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("181315e0-6221-4677-91bc-e775091343bc"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("1fa761f3-1663-4b22-aaa5-eeb28b78a0b0"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("473dae45-5ea8-4719-9f0e-559f4d786114"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("4d5fdbb2-9082-4dd1-b42d-546341c5bd42"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("665b6f71-3824-4752-8794-8223293f36e1"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("6841538c-c5dc-4fa2-8bfe-81b2229b5641"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("8c095de1-dcc4-403f-9614-f6ac5b7f096b"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("9f86144c-b3ca-4e12-9ced-eeeb921f070e"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("a0d56d82-8266-45c4-ad15-6db083488c9a"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("c400f3af-d036-48b8-9c23-a1faca1398fe"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("c547db04-24ad-4e32-9d5c-80f9d0454a49"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("e4459a51-2d9e-4daa-ae50-3982ac22d7f1"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKVOJFKouuBILJnbrfQVOPPQTqlQ1iyhq0CGbLJNuiID/evCjVI4fTxfhdgrBTu5OA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("181315e0-6221-4677-91bc-e775091343bc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1fa761f3-1663-4b22-aaa5-eeb28b78a0b0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("473dae45-5ea8-4719-9f0e-559f4d786114"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4d5fdbb2-9082-4dd1-b42d-546341c5bd42"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("665b6f71-3824-4752-8794-8223293f36e1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6841538c-c5dc-4fa2-8bfe-81b2229b5641"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8c095de1-dcc4-403f-9614-f6ac5b7f096b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9f86144c-b3ca-4e12-9ced-eeeb921f070e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a0d56d82-8266-45c4-ad15-6db083488c9a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c400f3af-d036-48b8-9c23-a1faca1398fe"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c547db04-24ad-4e32-9d5c-80f9d0454a49"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e4459a51-2d9e-4daa-ae50-3982ac22d7f1"));

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "StudentAchievements",
                newName: "FormDate");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0d7c8dc4-facc-44d6-a325-febb910e77f7"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("14209333-92c4-44cb-b0ae-3da275cec47d"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("14e930b0-31fd-4ad1-9e68-80f3b2e612e0"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("1602f7b8-cc74-46ba-a18c-8ec021e4b13e"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("32df5c3c-2017-45c4-8732-fd3ee4744c94"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("6630324f-4962-47d6-8b73-61d7190c0db0"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("722a4170-8032-4762-bbba-61cb36961e34"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("8025341c-2038-49bd-b1f6-01bbfa906bc9"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("b7aebc13-c6c2-4bc1-bc0f-16ac10773884"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("df61e86f-863b-4018-aeae-64e137b91589"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("ecd8a8d5-fee4-462d-bc20-5c454f1c75ee"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("f9c1286e-3bd8-4d8b-bfa2-1b17480ef178"), null, null, "village", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHRfsz2hlUgjaveaphnY45vffNopdIZHSrtKBdmKosNXsQTL1bRc3G+kB7ybqtJccA==");
        }
    }
}
