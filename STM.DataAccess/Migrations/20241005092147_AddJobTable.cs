namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobUserRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Descriotion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUserRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobUserRegisters_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobUserRegisters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MajorId",
                table: "Jobs",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserRegisters_JobId",
                table: "JobUserRegisters",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserRegisters_UserId",
                table: "JobUserRegisters",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobUserRegisters");

            migrationBuilder.DropTable(
                name: "Jobs");

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
    }
}
