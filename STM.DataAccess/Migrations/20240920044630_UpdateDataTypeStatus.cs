namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateDataTypeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0b9a83e0-bbd3-4197-bf8b-777e79b48d74"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("25a5aebf-8194-4c33-b669-9f52ab7e37a7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("626ed4e1-96aa-4005-89ca-01fe9c522b4b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8468c47c-28db-4c2c-982a-6f31756418af"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9e5f09c6-f5e2-45d2-b3b8-eee5e79fb8ca"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a6247467-f8fe-4866-bae3-7605a863c903"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b26123b3-b484-4b43-863b-22e9e9b7b9a5"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c0db4064-7ffa-4352-a57d-008ce68683ba"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d8dcccbb-72f3-4450-96f6-313f793841b2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e6c4366d-f032-4ae1-ad80-708a1f44559e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f0dfaf13-d7a9-4c2d-91ac-301cd5e30a4a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f804b51b-0b70-4a7d-a344-b5395963103e"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 256);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("018ac162-58e8-4378-a88a-eef6def01ff1"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("11d73fcd-56fe-41be-9a90-e5e96cd0c55f"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("23807f87-487d-460c-8781-0c8b89cd64ec"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("40bfde2b-55d9-47ff-b239-c2a95c64011e"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("69c765c1-062e-4d6c-aa98-3c37d71e998e"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("6ca79348-8019-4e75-a565-69f1e45f1c4a"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("8369d33f-daa7-4524-a840-e8074bc326dd"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("90d262ca-9de0-46c9-abdc-08f7dc357600"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("a528e3ad-c82a-45d0-aa12-a897e80f19f2"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("dadbd51d-e425-4f31-949b-201218d2f27f"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("eceebdb4-41af-4291-a07c-d75cc53b3197"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("f7ef1b70-08cc-4e8c-a13d-1741e1562448"), null, null, "webName", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                columns: new[] { "PasswordHash", "Status" },
                values: new object[] { "AQAAAAEAACcQAAAAEOR3E65ivnXb/45cWAxk2AHB6hrc0GsZxGoWzXoNEYqR5/XDXg1pKkEiubfc1+nPkQ==", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("018ac162-58e8-4378-a88a-eef6def01ff1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("11d73fcd-56fe-41be-9a90-e5e96cd0c55f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("23807f87-487d-460c-8781-0c8b89cd64ec"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("40bfde2b-55d9-47ff-b239-c2a95c64011e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("69c765c1-062e-4d6c-aa98-3c37d71e998e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6ca79348-8019-4e75-a565-69f1e45f1c4a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8369d33f-daa7-4524-a840-e8074bc326dd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("90d262ca-9de0-46c9-abdc-08f7dc357600"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a528e3ad-c82a-45d0-aa12-a897e80f19f2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("dadbd51d-e425-4f31-949b-201218d2f27f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("eceebdb4-41af-4291-a07c-d75cc53b3197"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f7ef1b70-08cc-4e8c-a13d-1741e1562448"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: true,
                defaultValue: 256,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0b9a83e0-bbd3-4197-bf8b-777e79b48d74"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("25a5aebf-8194-4c33-b669-9f52ab7e37a7"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("626ed4e1-96aa-4005-89ca-01fe9c522b4b"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("8468c47c-28db-4c2c-982a-6f31756418af"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("9e5f09c6-f5e2-45d2-b3b8-eee5e79fb8ca"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("a6247467-f8fe-4866-bae3-7605a863c903"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("b26123b3-b484-4b43-863b-22e9e9b7b9a5"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("c0db4064-7ffa-4352-a57d-008ce68683ba"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("d8dcccbb-72f3-4450-96f6-313f793841b2"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("e6c4366d-f032-4ae1-ad80-708a1f44559e"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("f0dfaf13-d7a9-4c2d-91ac-301cd5e30a4a"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("f804b51b-0b70-4a7d-a344-b5395963103e"), null, null, "Address", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                columns: new[] { "PasswordHash", "Status" },
                values: new object[] { "AQAAAAEAACcQAAAAEBG+r+DajF77LzRgWDLH3DZlouZbyaUj56LqyOBSyMn0FrSaSOtDvrRBgJxWW3wV0Q==", null });
        }
    }
}
