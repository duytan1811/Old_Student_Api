namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddNewsTableContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0b6877d6-7a0c-4ab1-9e2e-eb010c3fae63"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("12bfb091-c853-40f0-b424-6688f50375bd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("54f8dfa4-76d3-4ff3-b314-5eda698cc756"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("5b70e532-7ddf-4c32-9794-ca5c96290583"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("798542a6-dca9-45c3-b8e4-584f6c64cdf1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7e0a4739-1801-4c35-b65b-d31595f8bfb8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9b791c09-7f75-4a14-9dbe-f059eb097c10"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b81c34cf-ae18-46e9-919a-ba3c1ae4394b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c398b806-b20f-48ad-9243-b189d0d3acf3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d2dc8ad8-c5cf-490f-9a48-d48424a14cc6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fb4d9e5d-041e-48d2-8210-752e44e2374e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fd90597c-1acc-4eab-9fae-ee6727fc85aa"));

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountMember = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewComments_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("118b8168-c5e0-4d39-9057-8dd2ac6c686a"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("43c45e0d-f49d-4856-a30b-4de00b6df6e2"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("6f0f96b5-3fc5-48c6-b50b-91342f9e8f3a"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("77649768-f20d-49e9-9d00-cb3c9ca003a2"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("88f3680a-124f-4d30-874d-82f645ded346"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("8b41d162-d343-4361-8ee5-1c434ed30a5e"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("9453da22-ef9a-4a34-8475-81e534fcba2a"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("a8a26005-4a7e-4daf-962b-36b7b9becd3c"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("c106ee6a-6b2c-4689-9308-8b2ed771cce6"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("e3f2541e-38cf-48d3-b3f2-fc0d68118c6c"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("f24e4a95-5c30-44da-957e-e81529d87b2b"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("ff934fca-fb2e-4284-a450-d102c6b1744f"), null, null, "village", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK3ge5vpr6kEjgf3u2licwlOHmA6TzpRFHSDVzzEfHEDySSlvcZ7XQuKf6CsEF97nw==");

            migrationBuilder.CreateIndex(
                name: "IX_NewComments_NewId",
                table: "NewComments",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_NewComments_UserId",
                table: "NewComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewComments");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("118b8168-c5e0-4d39-9057-8dd2ac6c686a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("43c45e0d-f49d-4856-a30b-4de00b6df6e2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6f0f96b5-3fc5-48c6-b50b-91342f9e8f3a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("77649768-f20d-49e9-9d00-cb3c9ca003a2"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("88f3680a-124f-4d30-874d-82f645ded346"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8b41d162-d343-4361-8ee5-1c434ed30a5e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9453da22-ef9a-4a34-8475-81e534fcba2a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a8a26005-4a7e-4daf-962b-36b7b9becd3c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c106ee6a-6b2c-4689-9308-8b2ed771cce6"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e3f2541e-38cf-48d3-b3f2-fc0d68118c6c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f24e4a95-5c30-44da-957e-e81529d87b2b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ff934fca-fb2e-4284-a450-d102c6b1744f"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0b6877d6-7a0c-4ab1-9e2e-eb010c3fae63"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("12bfb091-c853-40f0-b424-6688f50375bd"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("54f8dfa4-76d3-4ff3-b314-5eda698cc756"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("5b70e532-7ddf-4c32-9794-ca5c96290583"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("798542a6-dca9-45c3-b8e4-584f6c64cdf1"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("7e0a4739-1801-4c35-b65b-d31595f8bfb8"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("9b791c09-7f75-4a14-9dbe-f059eb097c10"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("b81c34cf-ae18-46e9-919a-ba3c1ae4394b"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("c398b806-b20f-48ad-9243-b189d0d3acf3"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("d2dc8ad8-c5cf-490f-9a48-d48424a14cc6"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("fb4d9e5d-041e-48d2-8210-752e44e2374e"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("fd90597c-1acc-4eab-9fae-ee6727fc85aa"), null, null, "phone", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEC+gpv/qdtLvSIPzKUB5plc0QUx15PSvrPt/7q4z72O/UW8S76pKgAo81+JVwG2znQ==");
        }
    }
}
