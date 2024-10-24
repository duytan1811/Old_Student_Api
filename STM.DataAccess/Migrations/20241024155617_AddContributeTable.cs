namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddContributeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2eb44447-ddbe-4329-80ae-a80d10053f9d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("4812ed21-c138-4364-801a-bfd305c72595"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6d397fd9-a1ef-4a3b-a85e-6104e23b277b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7c841188-49b7-4368-bdc6-3355ae146914"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9ef0e341-0b60-4f96-834a-f651d4440220"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a0067f74-65bb-410e-af2e-3287c62260ca"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a245d721-fb1b-43e3-a8c2-cdd308354ec7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ae0577eb-f896-4b6d-af82-bf4ee4dcd045"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("b9ad0008-1278-4bba-bb72-eff5e3fc54d8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bb169229-f509-417a-a3e2-8e76e345018c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d77b6247-f3e3-4826-a1f3-24848d4b740b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ec3051e9-9374-487c-84c2-d46279deab79"));

            migrationBuilder.CreateTable(
                name: "Contributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("09bc7b73-bc2c-434f-8fba-9691dfb82231"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("2403e017-2576-4baa-b06b-45a9025e67b7"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("3e68257d-dc44-4c55-8517-9863062430f3"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("5428f03f-1de9-4ceb-bc78-f78e25b10b91"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("62d2feb7-3220-454f-963c-5bd33e78f024"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("6a1ed4e5-03c1-4cf3-9b8e-c4851426dbe8"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("6c27cf8d-50fe-4e39-9fa9-3ad40e8046fd"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("a3acc3d0-a502-4c7d-8b62-f6b314f6503a"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("a5745186-5963-4e3d-b42d-f6972b7e2543"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("c29133f1-87d6-4be8-8f6c-e49289d8be21"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("c8fc165a-2d93-46b8-9f17-4869e9709fb4"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("e79e54a8-d8cd-44f3-9838-9065352b65bb"), null, null, "currency", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELRDJvJEFE3qDJgumLBDtZ/qw2WT42pKqn4aSD7NWdTpUqNHE3DPOik1Fe3fS7ozew==");

            migrationBuilder.CreateIndex(
                name: "IX_Contributes_StudentId",
                table: "Contributes",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributes");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("09bc7b73-bc2c-434f-8fba-9691dfb82231"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2403e017-2576-4baa-b06b-45a9025e67b7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3e68257d-dc44-4c55-8517-9863062430f3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("5428f03f-1de9-4ceb-bc78-f78e25b10b91"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("62d2feb7-3220-454f-963c-5bd33e78f024"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6a1ed4e5-03c1-4cf3-9b8e-c4851426dbe8"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6c27cf8d-50fe-4e39-9fa9-3ad40e8046fd"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a3acc3d0-a502-4c7d-8b62-f6b314f6503a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a5745186-5963-4e3d-b42d-f6972b7e2543"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c29133f1-87d6-4be8-8f6c-e49289d8be21"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c8fc165a-2d93-46b8-9f17-4869e9709fb4"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e79e54a8-d8cd-44f3-9838-9065352b65bb"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("2eb44447-ddbe-4329-80ae-a80d10053f9d"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("4812ed21-c138-4364-801a-bfd305c72595"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("6d397fd9-a1ef-4a3b-a85e-6104e23b277b"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("7c841188-49b7-4368-bdc6-3355ae146914"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("9ef0e341-0b60-4f96-834a-f651d4440220"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("a0067f74-65bb-410e-af2e-3287c62260ca"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("a245d721-fb1b-43e3-a8c2-cdd308354ec7"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("ae0577eb-f896-4b6d-af82-bf4ee4dcd045"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("b9ad0008-1278-4bba-bb72-eff5e3fc54d8"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("bb169229-f509-417a-a3e2-8e76e345018c"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("d77b6247-f3e3-4826-a1f3-24848d4b740b"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("ec3051e9-9374-487c-84c2-d46279deab79"), null, null, "email", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGQ6J+HbJ13GzmxYN4PmFm0DuTKga6AXmmRea0+B65dl5GvPZVs4rIUPYxpPKhaOJg==");
        }
    }
}
