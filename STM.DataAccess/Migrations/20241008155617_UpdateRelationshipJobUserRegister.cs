namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateRelationshipJobUserRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("081b1742-65ff-44db-9915-bde4967a95af"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("162021ff-7fc8-4314-8d7f-e931beb506b1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("28822e6b-14fd-48e8-8ed2-89eb1f482d2a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2b91462c-232a-434e-8cc9-c171a084d840"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3d1517e8-acc8-4789-af5b-5a6a7b036295"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4e31687c-64d6-407a-b8ef-14325acd2a8e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("680b42b1-e2a3-405c-a01f-52e6249b1049"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7c3ef994-e911-44da-a6d3-3a1325176ca7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9045fc19-e85d-47b0-85f6-b8c35c33fa91"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("af2c4d2c-72de-4cea-9c04-1992023051ea"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c8f14bdd-1a80-4a4c-b20e-729aa2108721"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("eab877b7-c428-4822-825d-9bfc5416577e"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("2620f253-36b6-4a7a-a965-4a8160409526"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("433a72d5-9792-4b5e-82e5-f10b9cf90952"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("56ff3bb3-f47e-4f69-9b48-2e6d643afc4c"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("5b942598-b3c2-4526-9e0a-7ce151cd2570"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("73146138-6446-4c15-86cd-615b0623f4e2"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("89edd189-84fd-4e63-9613-11f684f03c18"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("8bb6ac8d-c809-4277-93db-8b74be6adfc0"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("a62f92bb-4151-4893-b878-456d62b27ec4"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("bc647ee0-1d45-467a-8c3a-da8cf8ac87c6"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("cec2c352-55e1-4464-a906-c5b688d4b05b"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("d8053750-db24-4edc-835c-fff1e696354f"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("f6466957-90c6-4e2f-8c7c-19c3a6809195"), null, null, "timeZone", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAED/MbR+xS0b/OKJyZNGXopqRW3RP4lQZdDLXVkHkG/4f8rK6kCwaOYuwwQ6DKEdNhA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2620f253-36b6-4a7a-a965-4a8160409526"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("433a72d5-9792-4b5e-82e5-f10b9cf90952"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("56ff3bb3-f47e-4f69-9b48-2e6d643afc4c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("5b942598-b3c2-4526-9e0a-7ce151cd2570"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("73146138-6446-4c15-86cd-615b0623f4e2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("89edd189-84fd-4e63-9613-11f684f03c18"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8bb6ac8d-c809-4277-93db-8b74be6adfc0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a62f92bb-4151-4893-b878-456d62b27ec4"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bc647ee0-1d45-467a-8c3a-da8cf8ac87c6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cec2c352-55e1-4464-a906-c5b688d4b05b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d8053750-db24-4edc-835c-fff1e696354f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f6466957-90c6-4e2f-8c7c-19c3a6809195"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("081b1742-65ff-44db-9915-bde4967a95af"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("162021ff-7fc8-4314-8d7f-e931beb506b1"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("28822e6b-14fd-48e8-8ed2-89eb1f482d2a"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("2b91462c-232a-434e-8cc9-c171a084d840"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("3d1517e8-acc8-4789-af5b-5a6a7b036295"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("4e31687c-64d6-407a-b8ef-14325acd2a8e"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("680b42b1-e2a3-405c-a01f-52e6249b1049"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("7c3ef994-e911-44da-a6d3-3a1325176ca7"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("9045fc19-e85d-47b0-85f6-b8c35c33fa91"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("af2c4d2c-72de-4cea-9c04-1992023051ea"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("c8f14bdd-1a80-4a4c-b20e-729aa2108721"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("eab877b7-c428-4822-825d-9bfc5416577e"), null, null, "currency", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFoSyilmSGllG3eDPY6wMt5sJQFebbwmptb4UdsSd3aC6Bsr0yn6/ksH7SMUzPOSig==");
        }
    }
}
