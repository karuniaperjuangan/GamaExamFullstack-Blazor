using Microsoft.EntityFrameworkCore.Migrations;

namespace GamaExamFullstack.Migrations
{
    public partial class WebMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dCreators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    institute = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dCreators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    institute = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dParticipants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dContests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    NumOfQuestion = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dContests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dContests_dCreators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "dCreators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dContestsAttempt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightAnswer = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<float>(type: "float(24)", nullable: false),
                    ContestId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dContestsAttempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dContestsAttempt_dContests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "dContests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dContestsAttempt_dParticipants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "dParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    Answers_A = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Answers_B = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Answers_C = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Answers_D = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Answers_E = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TrueAnswer = table.Column<string>(type: "char(1)", nullable: false),
                    ContestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dQuestions_dContests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "dContests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "char(1)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    ContestAttemptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_dContestsAttempt_ContestAttemptId",
                        column: x => x.ContestAttemptId,
                        principalTable: "dContestsAttempt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_dQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "dQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dContests_CreatorId",
                table: "dContests",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_dContestsAttempt_ContestId",
                table: "dContestsAttempt",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_dContestsAttempt_ParticipantId",
                table: "dContestsAttempt",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_dQuestions_ContestId",
                table: "dQuestions",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_ContestAttemptId",
                table: "QuestionAnswer",
                column: "ContestAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "dContestsAttempt");

            migrationBuilder.DropTable(
                name: "dQuestions");

            migrationBuilder.DropTable(
                name: "dParticipants");

            migrationBuilder.DropTable(
                name: "dContests");

            migrationBuilder.DropTable(
                name: "dCreators");
        }
    }
}
