namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2d53fcde-b4d6-4eaf-9759-92c441df77c4"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3a7f6ede-0f76-420f-9208-55887b4ee641"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("5e334b98-004e-49d0-8393-e351b9ef9510"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("617775c3-1c01-4cee-bc02-47c2ae070000"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("71de6491-4cfe-4bf3-9a2c-a58e7b80dad8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("73608215-c2be-499a-8dfe-2b199ee4a5c6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7a07ec9e-33ff-402b-b4ab-cc3159c213c0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("99704c79-a937-4869-83c8-839f8e02292b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bee04c23-3411-4099-9554-6b43b0f100e1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c8fe1dbb-236f-433d-85a3-f7f6a5381588"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ec031553-6b9a-409d-bc6f-b2a3518e6e6d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fbbc014b-434a-47cb-8767-317dfe28e51b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsTeacher",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("19b67f70-9d0b-4f9b-83a6-d8b4c40f0311"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("2a3373ff-65b3-40ce-8043-51a829cd0fc5"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("3c989e26-a953-49c1-8aa2-87bc71d4c573"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("4168abf9-6035-4b1e-bba4-ad541290d9d3"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("753222fe-1305-4b9d-90ec-7f72b0967934"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("78d2f8f0-5e51-4c34-8c95-12f944ab223f"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("8a8d6e3d-f6ac-4816-aa9b-d693b0b6c2a6"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("929e3880-5c15-4d31-8047-3d7da7cbd118"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("9b86c549-3189-4fd3-915a-300d6ed2e91c"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("bcdfc7af-1e2c-41a1-9f23-7199eecce863"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("d203f04e-da14-44af-8d5f-f4da0141f45d"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("e970f254-f3c1-465f-a1af-2be7da94b11e"), null, null, "district", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELDVsvy3zncb5N0mjACSNTjCtXBggD2w2tR+Qo4N7RfxbRbW/8FeA1FHiEBl2mYxoA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("19b67f70-9d0b-4f9b-83a6-d8b4c40f0311"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2a3373ff-65b3-40ce-8043-51a829cd0fc5"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3c989e26-a953-49c1-8aa2-87bc71d4c573"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4168abf9-6035-4b1e-bba4-ad541290d9d3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("753222fe-1305-4b9d-90ec-7f72b0967934"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("78d2f8f0-5e51-4c34-8c95-12f944ab223f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8a8d6e3d-f6ac-4816-aa9b-d693b0b6c2a6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("929e3880-5c15-4d31-8047-3d7da7cbd118"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9b86c549-3189-4fd3-915a-300d6ed2e91c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bcdfc7af-1e2c-41a1-9f23-7199eecce863"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d203f04e-da14-44af-8d5f-f4da0141f45d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e970f254-f3c1-465f-a1af-2be7da94b11e"));

            migrationBuilder.DropColumn(
                name: "IsTeacher",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("2d53fcde-b4d6-4eaf-9759-92c441df77c4"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("3a7f6ede-0f76-420f-9208-55887b4ee641"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("5e334b98-004e-49d0-8393-e351b9ef9510"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("617775c3-1c01-4cee-bc02-47c2ae070000"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("71de6491-4cfe-4bf3-9a2c-a58e7b80dad8"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("73608215-c2be-499a-8dfe-2b199ee4a5c6"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("7a07ec9e-33ff-402b-b4ab-cc3159c213c0"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("99704c79-a937-4869-83c8-839f8e02292b"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("bee04c23-3411-4099-9554-6b43b0f100e1"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("c8fe1dbb-236f-433d-85a3-f7f6a5381588"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("ec031553-6b9a-409d-bc6f-b2a3518e6e6d"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("fbbc014b-434a-47cb-8767-317dfe28e51b"), null, null, "currency", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJlkB+q6TQhgOj8YIZRBtmc9CfvgCXMoHJm/biKwTz/lZHeZeai+lzEqG+PXaAXOgQ==");
        }
    }
}
