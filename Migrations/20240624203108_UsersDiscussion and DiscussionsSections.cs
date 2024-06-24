using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpVote.Migrations
{
    /// <inheritdoc />
    public partial class UsersDiscussionandDiscussionsSections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Discussions_DiscussionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DiscussionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DiscussionId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "DiscussionsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscussionId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussionsSections_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscussionsSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersDiscussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DiscussionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDiscussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersDiscussions_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersDiscussions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionsSections_DiscussionId",
                table: "DiscussionsSections",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionsSections_SectionId",
                table: "DiscussionsSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiscussions_DiscussionId",
                table: "UsersDiscussions",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiscussions_UserId",
                table: "UsersDiscussions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscussionsSections");

            migrationBuilder.DropTable(
                name: "UsersDiscussions");

            migrationBuilder.AddColumn<int>(
                name: "DiscussionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiscussionId",
                table: "Users",
                column: "DiscussionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Discussions_DiscussionId",
                table: "Users",
                column: "DiscussionId",
                principalTable: "Discussions",
                principalColumn: "Id");
        }
    }
}
