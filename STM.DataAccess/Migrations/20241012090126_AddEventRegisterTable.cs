namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddEventRegisterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EventRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BelongToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRegisters_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventRegisters_Users_UserId",
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
                    { new Guid("10ff9ac5-a259-4d65-aa7e-8cf380c73b02"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("18e16188-b140-4a48-872b-3da088a77c4e"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("38e56956-c95c-4353-b1f2-bf844f72bb5b"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("3c68e844-7c0b-4e7b-b1bb-1dcab3b628e1"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("4c160980-a169-4387-b2ac-9bcc9838745b"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("8ec2fd43-8596-468a-b666-f5dc66afc49b"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("99e51f2d-b4ee-48b9-8479-4b7dbc30d8fd"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("a604a433-a166-4a36-bc9f-53c6e1f9c0e8"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("b55a9b51-360d-4665-9787-a2dc2d8e3d94"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("c592a60a-1beb-43f6-a58a-2775ce3fba1b"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("eba4ce6d-c9a8-403d-8430-101d80e08ad8"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("ef8805bf-2d26-4fa4-96bb-3d5bd12eaab3"), null, null, "webName", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKV8HRI+urvmgTh+0168lwITN/LSo62Yq10guBnWsHN3lwuAA67cX4WpIw2zBslvww==");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegisters_NewsId",
                table: "EventRegisters",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegisters_UserId",
                table: "EventRegisters",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRegisters");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("10ff9ac5-a259-4d65-aa7e-8cf380c73b02"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("18e16188-b140-4a48-872b-3da088a77c4e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("38e56956-c95c-4353-b1f2-bf844f72bb5b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3c68e844-7c0b-4e7b-b1bb-1dcab3b628e1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4c160980-a169-4387-b2ac-9bcc9838745b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8ec2fd43-8596-468a-b666-f5dc66afc49b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("99e51f2d-b4ee-48b9-8479-4b7dbc30d8fd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a604a433-a166-4a36-bc9f-53c6e1f9c0e8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b55a9b51-360d-4665-9787-a2dc2d8e3d94"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c592a60a-1beb-43f6-a58a-2775ce3fba1b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("eba4ce6d-c9a8-403d-8430-101d80e08ad8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ef8805bf-2d26-4fa4-96bb-3d5bd12eaab3"));

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
    }
}
