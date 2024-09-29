namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateFKStuden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1eedfc00-458e-423b-8b18-2c496f410a5a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("59e0a3e3-999a-44cc-9a04-bfd00c781de2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("67b5d6c9-05eb-4e04-b94c-f988db4591cd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("72bac300-ba6e-46ee-8ef4-388d180813df"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8407c284-10c7-4265-ad3c-bf4c39c797b2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8545e3b5-e690-449f-a148-49c2cb97b117"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("887c5997-2de1-425b-ab0a-4c83eede7fb7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9da6e96b-bb4e-4ce9-a7f3-cf00059c1f20"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c1645e29-a50b-48e5-ae59-d358b6f0ce0a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e44122a2-00a4-4200-87a9-3300dfbc0b37"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e95e97ac-e87f-433d-8f67-b3c58749db88"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fe611bf2-3abb-45c8-9c1f-bf4676d9f69e"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

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
                    { new Guid("1eedfc00-458e-423b-8b18-2c496f410a5a"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("59e0a3e3-999a-44cc-9a04-bfd00c781de2"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("67b5d6c9-05eb-4e04-b94c-f988db4591cd"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("72bac300-ba6e-46ee-8ef4-388d180813df"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("8407c284-10c7-4265-ad3c-bf4c39c797b2"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("8545e3b5-e690-449f-a148-49c2cb97b117"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("887c5997-2de1-425b-ab0a-4c83eede7fb7"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("9da6e96b-bb4e-4ce9-a7f3-cf00059c1f20"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("c1645e29-a50b-48e5-ae59-d358b6f0ce0a"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("e44122a2-00a4-4200-87a9-3300dfbc0b37"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("e95e97ac-e87f-433d-8f67-b3c58749db88"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("fe611bf2-3abb-45c8-9c1f-bf4676d9f69e"), null, null, "province", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELrLYT/aWiZHwKUAVsbhFZ0lu6a3WiDy/d1hvfSs+xQJC3AeGCfkwpaF0sCXw5ZFuA==");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }
    }
}
