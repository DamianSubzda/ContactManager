using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedSnapshots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageSnapshot",
                table: "EmailSents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectSnapshot",
                table: "EmailSents",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageSnapshot",
                table: "EmailSents");

            migrationBuilder.DropColumn(
                name: "SubjectSnapshot",
                table: "EmailSents");
        }
    }
}
