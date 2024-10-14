namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateEventRegisterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EventRegisters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "EventRegisters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Email",
                table: "EventRegisters");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "EventRegisters");

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
        }
    }
}
