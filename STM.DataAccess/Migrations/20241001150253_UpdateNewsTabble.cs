namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateNewsTabble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CountMember",
                table: "News",
                newName: "CountLike");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "CountLike",
                table: "News",
                newName: "CountMember");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

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
        }
    }
}
