namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddStudentAchievementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "StudentAchievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAchievements_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0d7c8dc4-facc-44d6-a325-febb910e77f7"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("14209333-92c4-44cb-b0ae-3da275cec47d"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("14e930b0-31fd-4ad1-9e68-80f3b2e612e0"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("1602f7b8-cc74-46ba-a18c-8ec021e4b13e"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("32df5c3c-2017-45c4-8732-fd3ee4744c94"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("6630324f-4962-47d6-8b73-61d7190c0db0"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("722a4170-8032-4762-bbba-61cb36961e34"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("8025341c-2038-49bd-b1f6-01bbfa906bc9"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("b7aebc13-c6c2-4bc1-bc0f-16ac10773884"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("df61e86f-863b-4018-aeae-64e137b91589"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("ecd8a8d5-fee4-462d-bc20-5c454f1c75ee"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("f9c1286e-3bd8-4d8b-bfa2-1b17480ef178"), null, null, "village", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHRfsz2hlUgjaveaphnY45vffNopdIZHSrtKBdmKosNXsQTL1bRc3G+kB7ybqtJccA==");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAchievements_StudentId",
                table: "StudentAchievements",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAchievements");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0d7c8dc4-facc-44d6-a325-febb910e77f7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("14209333-92c4-44cb-b0ae-3da275cec47d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("14e930b0-31fd-4ad1-9e68-80f3b2e612e0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1602f7b8-cc74-46ba-a18c-8ec021e4b13e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("32df5c3c-2017-45c4-8732-fd3ee4744c94"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6630324f-4962-47d6-8b73-61d7190c0db0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("722a4170-8032-4762-bbba-61cb36961e34"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8025341c-2038-49bd-b1f6-01bbfa906bc9"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b7aebc13-c6c2-4bc1-bc0f-16ac10773884"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("df61e86f-863b-4018-aeae-64e137b91589"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ecd8a8d5-fee4-462d-bc20-5c454f1c75ee"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f9c1286e-3bd8-4d8b-bfa2-1b17480ef178"));

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
    }
}
