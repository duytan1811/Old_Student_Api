namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRelationshipSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2470e833-06e2-41f3-ae66-2304ff6ea320"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("2ab09528-5c7b-46cc-9c6d-deae30d6d94d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3665a38e-b7a4-4753-ad7a-29436698c4ff"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("384cc30a-4aa8-4e24-842d-1450535ab0de"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("84971619-c6c6-4ebe-b1b3-c375bcdedaca"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("afb3da2b-60f7-4c97-9770-5d8216350fc0"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bb43643d-926d-4b4a-9bcd-701622e2ac74"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c1272ae8-5c2d-4eaf-b721-d87baafbc615"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("d6fdb850-eb7d-4008-be68-e2f7190f1364"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e44665a5-2530-4476-86ff-5277063c19ed"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e9caacb5-f2ce-4b86-bd2f-5b833ee4218e"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fa5d8c59-4412-4a45-b0de-aa5abe6bf5d0"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("2470e833-06e2-41f3-ae66-2304ff6ea320"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("2ab09528-5c7b-46cc-9c6d-deae30d6d94d"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("3665a38e-b7a4-4753-ad7a-29436698c4ff"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("384cc30a-4aa8-4e24-842d-1450535ab0de"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("84971619-c6c6-4ebe-b1b3-c375bcdedaca"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("afb3da2b-60f7-4c97-9770-5d8216350fc0"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("bb43643d-926d-4b4a-9bcd-701622e2ac74"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("c1272ae8-5c2d-4eaf-b721-d87baafbc615"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("d6fdb850-eb7d-4008-be68-e2f7190f1364"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("e44665a5-2530-4476-86ff-5277063c19ed"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("e9caacb5-f2ce-4b86-bd2f-5b833ee4218e"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("fa5d8c59-4412-4a45-b0de-aa5abe6bf5d0"), null, null, "email", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJB8A2ZGb5FJHgdKwUV/b9CAiEpp0e3HwK7rQTVDKay6fQhUepTC/ckDRC1kULlTMA==");
        }
    }
}
