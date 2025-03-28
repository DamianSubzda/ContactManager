using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmailSent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents");

            migrationBuilder.AlterColumn<int>(
                name: "EmailCampaignId",
                table: "EmailSents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents",
                column: "EmailCampaignId",
                principalTable: "EmailCampaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents");

            migrationBuilder.AlterColumn<int>(
                name: "EmailCampaignId",
                table: "EmailSents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents",
                column: "EmailCampaignId",
                principalTable: "EmailCampaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
