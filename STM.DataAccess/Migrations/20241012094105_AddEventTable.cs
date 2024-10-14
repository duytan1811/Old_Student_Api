namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegisters_News_NewsId",
                table: "EventRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegisters_Users_UserId",
                table: "EventRegisters");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("09c69c66-adf0-4e0a-8444-4a330d5d5e80"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("204fb6ab-c09d-461a-838f-a64a410edc3b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("553b32b6-d02a-488d-9d97-25bbb637cd30"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("710e30a8-05d8-4a1c-8c0b-0449a333f2d2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8f879a1b-de02-4b83-a922-969a3933950c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("91032d35-f529-43ad-ade8-6b9db6f52013"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9797de1c-e216-4a8f-9dfe-c3d10f285b47"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9ebccb75-7684-41f3-8690-96edc6419546"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a242eff4-3d9d-46da-99d1-037b566601a6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b128503c-84c5-4147-b864-4bb60ed3d925"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d5cc836d-b9be-4ee5-8981-63a909aa5070"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e77fbc74-818a-414c-9f1e-f1971ed3b13b"));

            migrationBuilder.DropColumn(
                name: "BelongToUserId",
                table: "EventRegisters");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "EventRegisters",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegisters_NewsId",
                table: "EventRegisters",
                newName: "IX_EventRegisters_EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "News",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "EventRegisters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("02a43068-114c-414a-9bdb-06075a7e1354"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("3a6b995d-aa2e-4cde-a6c4-d8e484e37709"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("3c8f806d-28a3-4f27-8e67-c644d73f6590"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("4d5b89cf-1988-4e6b-8388-782887d480d5"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("8d60faa4-5c87-486b-be6a-5b55e3983bb7"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("a1ea5614-6e59-437d-9eaa-e23d230db157"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("a7ea005c-05ef-4312-bf5a-cf05410022aa"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("b28c9f6d-6902-41ab-ad34-5e1577f12247"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("be5886b8-d136-42d6-9af1-c4c252d210bc"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("bf3c40d1-d1be-4223-a905-2352373f40df"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("cbc6dd57-5593-4fe5-9ab2-8743877b638b"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("ece76efb-ad1d-49ec-9eab-c572106c726f"), null, null, "village", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKi30dvLeQ0q8l2ln+O9SfXB9s1x+X1wF9z/I5BCKBpgyjjwmp/SwZBXIV1b1OhXhA==");

            migrationBuilder.CreateIndex(
                name: "IX_News_EventId",
                table: "News",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegisters_Events_EventId",
                table: "EventRegisters",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegisters_Users_UserId",
                table: "EventRegisters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Events_EventId",
                table: "News",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegisters_Events_EventId",
                table: "EventRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegisters_Users_UserId",
                table: "EventRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Events_EventId",
                table: "News");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_News_EventId",
                table: "News");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("02a43068-114c-414a-9bdb-06075a7e1354"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3a6b995d-aa2e-4cde-a6c4-d8e484e37709"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3c8f806d-28a3-4f27-8e67-c644d73f6590"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4d5b89cf-1988-4e6b-8388-782887d480d5"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8d60faa4-5c87-486b-be6a-5b55e3983bb7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a1ea5614-6e59-437d-9eaa-e23d230db157"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a7ea005c-05ef-4312-bf5a-cf05410022aa"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b28c9f6d-6902-41ab-ad34-5e1577f12247"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("be5886b8-d136-42d6-9af1-c4c252d210bc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bf3c40d1-d1be-4223-a905-2352373f40df"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cbc6dd57-5593-4fe5-9ab2-8743877b638b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ece76efb-ad1d-49ec-9eab-c572106c726f"));

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventRegisters",
                newName: "NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegisters_EventId",
                table: "EventRegisters",
                newName: "IX_EventRegisters_NewsId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "EventRegisters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BelongToUserId",
                table: "EventRegisters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("09c69c66-adf0-4e0a-8444-4a330d5d5e80"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("204fb6ab-c09d-461a-838f-a64a410edc3b"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("553b32b6-d02a-488d-9d97-25bbb637cd30"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("710e30a8-05d8-4a1c-8c0b-0449a333f2d2"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("8f879a1b-de02-4b83-a922-969a3933950c"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("91032d35-f529-43ad-ade8-6b9db6f52013"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("9797de1c-e216-4a8f-9dfe-c3d10f285b47"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("9ebccb75-7684-41f3-8690-96edc6419546"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("a242eff4-3d9d-46da-99d1-037b566601a6"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("b128503c-84c5-4147-b864-4bb60ed3d925"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("d5cc836d-b9be-4ee5-8981-63a909aa5070"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("e77fbc74-818a-414c-9f1e-f1971ed3b13b"), null, null, "webName", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJqaOtfgomdZQs1gqrnGw7GnuX3AMiOyAEXHiAX44kYvevYf3h3K8tdwbVNrId1dUA==");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegisters_News_NewsId",
                table: "EventRegisters",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegisters_Users_UserId",
                table: "EventRegisters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
