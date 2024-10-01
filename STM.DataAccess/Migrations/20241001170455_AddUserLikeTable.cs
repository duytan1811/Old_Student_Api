namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddUserLikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1a38ef3e-ffef-4ad5-8b75-b3f7e5085486"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("327f78e2-4cf4-49cd-97f4-8edbc6c230f7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6cca4273-1b67-4080-a128-c9d74da0212b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("7217700f-8770-4d74-bd1e-f4adff937790"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8ade4443-6da4-4705-85db-deb2351dac36"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("91a2bf73-8a08-45c7-9b28-4fbdca7bcfbe"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a8e0ba85-2445-4751-a8a9-5ac362ac8166"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("afd06bfe-563b-462b-8ef5-eafb6520d96b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ec49ac4c-c24d-4cd7-ac33-201a897d3d6f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f419bcd3-a08d-40f9-8246-6d9c4238fb71"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("f7f2a426-a095-456e-9288-76eeabc85389"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fb0ec041-48ed-4878-88d3-d04e45820c9c"));

            migrationBuilder.CreateTable(
                name: "UserLikeNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikeNews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("0b4edb6a-ad68-4777-bcab-ebb5b7be6ef3"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("0cc90966-0a69-4c10-b9c0-e263d0ae7f53"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("18a595c4-fc44-4460-b590-ccfb7036f640"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("1acb6f93-ab9b-4adf-8ba3-fbbfab16514c"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("35dbae08-75af-42b5-8bcc-324bcf874532"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("6586bb15-3a46-4834-a74a-3087cb95a4b3"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("8af205d3-39e6-4e94-bc16-6d580c72cd6d"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("99eec5cd-f056-4727-84cc-d1a338b43753"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("ac805beb-374b-420e-b05e-3eb74fdd984f"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("ae003b14-ecfe-44c2-ac59-a87b81fd7b12"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("cf5a6524-4b25-44d2-bd1f-aa707c969116"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("fa8ad071-5d4e-4468-ab70-073e08a1fb44"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGmZJ0x10qWJb1PPyoquyhCNuuq2SsgsXHeowokGRLX3E0h3lkjZuU+VdYIn6OVQpQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikeNews");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0b4edb6a-ad68-4777-bcab-ebb5b7be6ef3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("0cc90966-0a69-4c10-b9c0-e263d0ae7f53"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("18a595c4-fc44-4460-b590-ccfb7036f640"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("1acb6f93-ab9b-4adf-8ba3-fbbfab16514c"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("35dbae08-75af-42b5-8bcc-324bcf874532"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6586bb15-3a46-4834-a74a-3087cb95a4b3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("8af205d3-39e6-4e94-bc16-6d580c72cd6d"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("99eec5cd-f056-4727-84cc-d1a338b43753"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ac805beb-374b-420e-b05e-3eb74fdd984f"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ae003b14-ecfe-44c2-ac59-a87b81fd7b12"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cf5a6524-4b25-44d2-bd1f-aa707c969116"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fa8ad071-5d4e-4468-ab70-073e08a1fb44"));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("1a38ef3e-ffef-4ad5-8b75-b3f7e5085486"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("327f78e2-4cf4-49cd-97f4-8edbc6c230f7"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("6cca4273-1b67-4080-a128-c9d74da0212b"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("7217700f-8770-4d74-bd1e-f4adff937790"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("8ade4443-6da4-4705-85db-deb2351dac36"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("91a2bf73-8a08-45c7-9b28-4fbdca7bcfbe"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("a8e0ba85-2445-4751-a8a9-5ac362ac8166"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("afd06bfe-563b-462b-8ef5-eafb6520d96b"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("ec49ac4c-c24d-4cd7-ac33-201a897d3d6f"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("f419bcd3-a08d-40f9-8246-6d9c4238fb71"), null, null, "phone", 1, "general", null, null, null },
                    { new Guid("f7f2a426-a095-456e-9288-76eeabc85389"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("fb0ec041-48ed-4878-88d3-d04e45820c9c"), null, null, "district", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHctTkbL22gobMvSv08CSXVjFGMW56kFvP/GN82krIkbN4kpygTJcz1aQz+w/ubhMg==");
        }
    }
}
