namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddApplyJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("71facee8-0765-4545-a16f-20ce16cfd87b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8fc5d6d9-96c8-4d42-8ee7-c7a6e3b17bf4"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9112fddc-4d20-43e5-a6bf-2a620c3726ee"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9f026a0e-dcf6-4625-8fe8-9089ab32215d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a3713177-127e-4608-bd90-436d760497f8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a97adf6d-65fe-4b22-adf7-929e81221246"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bdf0887d-c7fa-40b6-9abd-f4c971327692"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cf58594b-234a-4b21-b93f-642af77d62bf"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d1a62479-90be-4196-894c-bdd10cebcae7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e6180d6b-ff00-4771-9f95-20339ef05f3d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ed2544c6-d81c-4698-823c-d604858295cc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ee63bbc4-0b04-468f-b3c3-22fc815f4890"));

            migrationBuilder.RenameColumn(
                name: "Descriotion",
                table: "JobUserRegisters",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "JobUserRegisters",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Content",
                table: "JobUserRegisters");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "JobUserRegisters",
                newName: "Descriotion");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("71facee8-0765-4545-a16f-20ce16cfd87b"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("8fc5d6d9-96c8-4d42-8ee7-c7a6e3b17bf4"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("9112fddc-4d20-43e5-a6bf-2a620c3726ee"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("9f026a0e-dcf6-4625-8fe8-9089ab32215d"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("a3713177-127e-4608-bd90-436d760497f8"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("a97adf6d-65fe-4b22-adf7-929e81221246"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("bdf0887d-c7fa-40b6-9abd-f4c971327692"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("cf58594b-234a-4b21-b93f-642af77d62bf"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("d1a62479-90be-4196-894c-bdd10cebcae7"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("e6180d6b-ff00-4771-9f95-20339ef05f3d"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("ed2544c6-d81c-4698-823c-d604858295cc"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("ee63bbc4-0b04-468f-b3c3-22fc815f4890"), null, null, "province", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFKogmPIRJJpPJVbV+c6O4xtF3NOYmlJ8UGsIV8iSnfAT0TP0peSIWhRDMQ/d7bAwg==");
        }
    }
}
