namespace STM.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddSurveyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComment = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyTypeEnum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_SurveyTemplate_SurveyTemplateId",
                        column: x => x.SurveyTemplateId,
                        principalTable: "SurveyTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Key", "Status", "Type", "UpdatedAt", "UpdatedById", "Value" },
                values: new object[,]
                {
                    { new Guid("061ee926-1274-40b6-98c3-82cf68083888"), null, null, "orderCodeEndWith", 1, "general", null, null, null },
                    { new Guid("34bbc1b0-b7ab-49e7-9e74-db1b6b4693c3"), null, null, "currency", 1, "general", null, null, null },
                    { new Guid("55499f06-6670-4ed6-9b72-f27e00e80e91"), null, null, "email", 1, "general", null, null, null },
                    { new Guid("6dcc1c35-45dd-47ab-8c79-ddd21c5ce786"), null, null, "orderCodeStartWith", 1, "general", null, null, null },
                    { new Guid("79c0769a-b9b3-4312-a980-2afa42e6b5f3"), null, null, "Address", 1, "general", null, null, null },
                    { new Guid("885184fe-ea91-475b-8c35-3eec7726d732"), null, null, "webName", 1, "general", null, null, null },
                    { new Guid("a6e84c2a-b0c8-43e7-bf14-76a03e7fde12"), null, null, "emailSupportCustomer", 1, "general", null, null, null },
                    { new Guid("a8682cfb-0fa2-4fd7-be27-229ad3f566ad"), null, null, "district", 1, "general", null, null, null },
                    { new Guid("cb58b935-135e-4e2b-ac14-f930c0327178"), null, null, "province", 1, "general", null, null, null },
                    { new Guid("ce966bee-77ef-4fd3-8581-2edc829cc61b"), null, null, "village", 1, "general", null, null, null },
                    { new Guid("e86478f3-596a-4022-bd16-881828dce96a"), null, null, "timeZone", 1, "general", null, null, null },
                    { new Guid("fde3bb8a-f5f6-469b-aa15-57fe7e6d4e5c"), null, null, "phone", 1, "general", null, null, null },
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b2863d1-3468-4ad0-8881-ca52cdf1307d"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBaaZRaHKAlQqOmtlcbTWSLgt8NWmVT3Sr2m6Oqfz+c47794keYtsFe/WSmORtIocQ==");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_QuestionId",
                table: "SurveyResults",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_SurveyId",
                table: "SurveyResults",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyTemplateId",
                table: "Surveys",
                column: "SurveyTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "SurveyTemplate");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("061ee926-1274-40b6-98c3-82cf68083888"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("34bbc1b0-b7ab-49e7-9e74-db1b6b4693c3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("55499f06-6670-4ed6-9b72-f27e00e80e91"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("6dcc1c35-45dd-47ab-8c79-ddd21c5ce786"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("79c0769a-b9b3-4312-a980-2afa42e6b5f3"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("885184fe-ea91-475b-8c35-3eec7726d732"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a6e84c2a-b0c8-43e7-bf14-76a03e7fde12"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("a8682cfb-0fa2-4fd7-be27-229ad3f566ad"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("cb58b935-135e-4e2b-ac14-f930c0327178"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("ce966bee-77ef-4fd3-8581-2edc829cc61b"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e86478f3-596a-4022-bd16-881828dce96a"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("fde3bb8a-f5f6-469b-aa15-57fe7e6d4e5c"));

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
    }
}
