namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("05a2e051-259a-428e-ab37-f5ee6a047a35"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("17fa4a6b-c801-4eae-b4c9-1f8ca3d536f3"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("1937e5a6-c897-4fba-b44f-eb9535a47960"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("3c019392-4dea-44b3-9bf1-59d531062cee"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("5dc8dd7a-0209-4598-a923-2d7ced55a2dc"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("6ce352c2-3f32-4b82-b9b1-c5bfb2d48798"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("8391d667-51a9-4df6-b52f-444f6dc56035"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("9451d49c-d042-4855-99ba-a96dea32047c"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("a2655be4-b9c3-4499-86e8-758df4357f28"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("bd6480ce-01f7-4dc2-b844-8945cb6884c9"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("c631dc9c-49ec-430b-b8dd-86c58a23d2c1"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("e6850b0a-4446-48c3-8744-4340442c3e10"), null, null, "Address", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPWQC0TBTmSFN/sUWX+j6o7slf7xVwEAmjE/uZgjzK0wPu1twVMkEWxZpuCPB43Omg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("05a2e051-259a-428e-ab37-f5ee6a047a35"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("17fa4a6b-c801-4eae-b4c9-1f8ca3d536f3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1937e5a6-c897-4fba-b44f-eb9535a47960"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("3c019392-4dea-44b3-9bf1-59d531062cee"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("5dc8dd7a-0209-4598-a923-2d7ced55a2dc"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6ce352c2-3f32-4b82-b9b1-c5bfb2d48798"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8391d667-51a9-4df6-b52f-444f6dc56035"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("9451d49c-d042-4855-99ba-a96dea32047c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a2655be4-b9c3-4499-86e8-758df4357f28"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("bd6480ce-01f7-4dc2-b844-8945cb6884c9"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("c631dc9c-49ec-430b-b8dd-86c58a23d2c1"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e6850b0a-4446-48c3-8744-4340442c3e10"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");

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
        }
    }
}
