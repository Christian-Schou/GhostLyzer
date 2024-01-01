using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostMetrics.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorIntegrationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebhookSecret",
                table: "SiteIntegrationDetails",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebhookSecret",
                table: "SiteIntegrationDetails");
        }
    }
}
