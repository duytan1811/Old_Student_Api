namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateDataTypeStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfGraduation",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolYear",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentCompany",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Students",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("220d63b3-a8b7-4dbf-9d91-bdb865915abd"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("38c5e044-1132-4a3e-8c3b-e3ca72f6061c"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("4279eb06-59dc-4cd6-a77d-9df7a07fde50"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("49d091da-ce2f-4525-bbbf-d313be614c1a"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("59727a58-bbc9-4058-85b8-381fe0099006"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("6ebacecc-cc50-4c25-941d-70d45a206ad2"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("7a8d8c6f-5757-43ae-9b6a-f1f629cbb1fe"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("98bd803e-3ab7-4ffa-b438-c3af09883248"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("a0bda97a-8128-4cab-80f7-2c87d789e5d6"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("aebf2094-e928-4117-ada5-020c8091398c"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("d0e29adf-967f-48fe-9e6d-f2026ba66714"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("dd3ec825-bb02-40f8-99a2-45282795187e"), null, null, "district", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOT2264PoYVpJ7LVrz8dVDu0uLsU53ADGA9TXGqOnF3tW4VScB//r7eTtJUD8aBflQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("220d63b3-a8b7-4dbf-9d91-bdb865915abd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("38c5e044-1132-4a3e-8c3b-e3ca72f6061c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4279eb06-59dc-4cd6-a77d-9df7a07fde50"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("49d091da-ce2f-4525-bbbf-d313be614c1a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("59727a58-bbc9-4058-85b8-381fe0099006"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6ebacecc-cc50-4c25-941d-70d45a206ad2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7a8d8c6f-5757-43ae-9b6a-f1f629cbb1fe"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("98bd803e-3ab7-4ffa-b438-c3af09883248"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a0bda97a-8128-4cab-80f7-2c87d789e5d6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("aebf2094-e928-4117-ada5-020c8091398c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d0e29adf-967f-48fe-9e6d-f2026ba66714"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("dd3ec825-bb02-40f8-99a2-45282795187e"));

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Students",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfGraduation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentCompany",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

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
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOR3E65ivnXb/45cWAxk2AHB6hrc0GsZxGoWzXoNEYqR5/XDXg1pKkEiubfc1+nPkQ==");
        }
    }
}
