namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateDataTypeNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("094c10f4-9bb6-43e8-af6c-c3668ba0148d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("293a4b1c-68a2-48a3-9cea-6fe074bb7177"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4f055441-e50a-4735-a58b-2c4cd7faf1b9"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("870ae909-6e34-4fa6-9067-1d02e16e8afc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a1aa479c-de80-4264-874d-f198ad76a9a0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a3e9b601-6cdd-489a-91b2-91b046362e7a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b55f38ab-e88b-423c-8a1c-99b47ac39a62"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e0698393-e37d-40f0-9536-7c9b78cfc576"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e4ead0cb-4519-461a-a7f5-cacf34244044"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e8853e61-0913-4351-8ff0-f61b3ac1e006"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fb39c016-5c52-4c1d-86d4-82626e4f6158"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fd947499-2e4e-4581-a2aa-dd3a03a0d743"));

            migrationBuilder.DropColumn(
                name: "CountLike",
                table: "News");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserLikeNews_NewsId",
                table: "UserLikeNews",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikeNews_News_NewsId",
                table: "UserLikeNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikeNews_News_NewsId",
                table: "UserLikeNews");

            migrationBuilder.DropIndex(
                name: "IX_UserLikeNews_NewsId",
                table: "UserLikeNews");

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

            migrationBuilder.AddColumn<int>(
                name: "CountLike",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("094c10f4-9bb6-43e8-af6c-c3668ba0148d"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("293a4b1c-68a2-48a3-9cea-6fe074bb7177"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("4f055441-e50a-4735-a58b-2c4cd7faf1b9"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("870ae909-6e34-4fa6-9067-1d02e16e8afc"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("a1aa479c-de80-4264-874d-f198ad76a9a0"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("a3e9b601-6cdd-489a-91b2-91b046362e7a"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("b55f38ab-e88b-423c-8a1c-99b47ac39a62"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("e0698393-e37d-40f0-9536-7c9b78cfc576"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("e4ead0cb-4519-461a-a7f5-cacf34244044"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("e8853e61-0913-4351-8ff0-f61b3ac1e006"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("fb39c016-5c52-4c1d-86d4-82626e4f6158"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("fd947499-2e4e-4581-a2aa-dd3a03a0d743"), null, null, "currency", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEA1/YlXGgKucbS8lg5bVqfbt5Fwz5FANKTtIcwsrcF23tJhd71PeA01VNLrviPlW3A==");
        }
    }
}
