using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class PreventCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents",
                column: "EmailCampaignId",
                principalTable: "EmailCampaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSents_EmailCampaigns_EmailCampaignId",
                table: "EmailSents",
                column: "EmailCampaignId",
                principalTable: "EmailCampaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
