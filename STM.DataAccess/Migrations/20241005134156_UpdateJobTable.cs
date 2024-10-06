namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("175798d6-8951-4b86-935f-6e2929928756"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("18de3d85-2c79-4313-b6dd-0efc66978c90"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("19f1ddc6-dd2b-49f5-8277-6ef46069c893"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("87358fba-31c8-4041-b20a-9f0d2cd327a0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("97f6e56e-3b70-44f3-abb6-4bd6fa405f8a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9afc0ddd-01ee-4c89-be86-6247b6b941ed"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9c8db0fa-5547-4627-91f7-2946a972f6ba"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ba64f365-85d7-4462-9340-f7094c6b72ed"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bbc64f69-6f83-488d-9793-80e5338cd4a5"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c0a15588-3679-48b1-bada-b75c196701e1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cdd4ed9f-7417-45b6-8ed4-482ea1bf1fca"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cfdf9572-5525-49f3-9301-b524150af848"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkType",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "Jobs");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("175798d6-8951-4b86-935f-6e2929928756"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("18de3d85-2c79-4313-b6dd-0efc66978c90"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("19f1ddc6-dd2b-49f5-8277-6ef46069c893"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("87358fba-31c8-4041-b20a-9f0d2cd327a0"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("97f6e56e-3b70-44f3-abb6-4bd6fa405f8a"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("9afc0ddd-01ee-4c89-be86-6247b6b941ed"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("9c8db0fa-5547-4627-91f7-2946a972f6ba"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("ba64f365-85d7-4462-9340-f7094c6b72ed"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("bbc64f69-6f83-488d-9793-80e5338cd4a5"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("c0a15588-3679-48b1-bada-b75c196701e1"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("cdd4ed9f-7417-45b6-8ed4-482ea1bf1fca"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("cfdf9572-5525-49f3-9301-b524150af848"), null, null, "timeZone", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMf9ISqryfHWPjwVu4O/Kf7JhbyQ04HSdRdBgHDGPMX+NvaPJesNT+l1xCJKaUP/dQ==");
        }
    }
}
