namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

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
                columns: new[] { "Name", "PasswordHash" },
                values: new object[] { "Admin", "AQAAAAEAACcQAAAAEKVOJFKouuBILJnbrfQVOPPQTqlQ1iyhq0CGbLJNuiID/evCjVI4fTxfhdgrBTu5OA==" });
        }
    }
}
