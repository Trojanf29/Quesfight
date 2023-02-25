using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesFight.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuesCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionName = table.Column<string>(type: "NVARCHAR(45)", nullable: false),
                    RestrictTime = table.Column<int>(type: "int", nullable: false),
                    NumberOfQuestion = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuesCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(45)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Avatar = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    Bio = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    Token = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice1 = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Choice2 = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Choice3 = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CorrectChoice = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    QuesCollectionId = table.Column<int>(type: "int", nullable: false),
                    FinishTime = table.Column<int>(type: "int", nullable: false),
                    CompletedQuestion = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearnRecords_QuesCollections_QuesCollectionId",
                        column: x => x.QuesCollectionId,
                        principalTable: "QuesCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearnRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    Content = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuesMatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesCollectionId = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuesMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuesMatch_QuesCollections_QuesCollectionId",
                        column: x => x.QuesCollectionId,
                        principalTable: "QuesCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuesMatch_Users_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collection_Question",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection_Question", x => new { x.QuestionId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_Collection_Question_QuesCollections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "QuesCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collection_Question_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesMatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    FinishTime = table.Column<int>(type: "int", nullable: false),
                    CompletedQuestion = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRecords_QuesMatch_QuesMatchId",
                        column: x => x.QuesMatchId,
                        principalTable: "QuesMatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchRecords_Users_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collection_Question_CollectionId",
                table: "Collection_Question",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnRecords_QuesCollectionId",
                table: "LearnRecords",
                column: "QuesCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnRecords_UserId",
                table: "LearnRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_PlayerId",
                table: "MatchRecords",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_QuesMatchId",
                table: "MatchRecords",
                column: "QuesMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuesMatch_QuesCollectionId",
                table: "QuesMatch",
                column: "QuesCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuesMatch_WinnerId",
                table: "QuesMatch",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GenreId",
                table: "Questions",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collection_Question");

            migrationBuilder.DropTable(
                name: "LearnRecords");

            migrationBuilder.DropTable(
                name: "MatchRecords");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuesMatch");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "QuesCollections");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
