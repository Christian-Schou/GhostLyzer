using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostMetrics.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorAnalyticsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagAnalytics_Tag_TagId",
                table: "TagAnalytics");

            migrationBuilder.DropTable(
                name: "AuthorAnalytics");

            migrationBuilder.DropTable(
                name: "PostAnalytics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagAnalytics",
                table: "TagAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_TagAnalytics_TagId",
                table: "TagAnalytics");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TagAnalytics");

            migrationBuilder.RenameTable(
                name: "TagAnalytics",
                newName: "BaseAnalytics");

            migrationBuilder.RenameColumn(
                name: "Uniques",
                table: "BaseAnalytics",
                newName: "UniquesFromSiteCreation");

            migrationBuilder.RenameColumn(
                name: "TotalTime",
                table: "BaseAnalytics",
                newName: "TotalTimeFromCreation");

            migrationBuilder.RenameColumn(
                name: "ReturningVisitors",
                table: "BaseAnalytics",
                newName: "ReturningVisitorsFromSiteCreation");

            migrationBuilder.RenameColumn(
                name: "PageViews",
                table: "BaseAnalytics",
                newName: "PageViewsFromSiteCreation");

            migrationBuilder.AlterColumn<Guid>(
                name: "TagId",
                table: "BaseAnalytics",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "BaseAnalytics",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseAnalytics",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "BaseAnalytics",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseAnalytics",
                table: "BaseAnalytics",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnalyticsEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PageViews = table.Column<int>(type: "integer", nullable: false),
                    Uniques = table.Column<int>(type: "integer", nullable: false),
                    ReturningVisitors = table.Column<int>(type: "integer", nullable: false),
                    TotalTime = table.Column<int>(type: "integer", nullable: false),
                    BaseAnalyticsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalyticsEntry_BaseAnalytics_BaseAnalyticsId",
                        column: x => x.BaseAnalyticsId,
                        principalTable: "BaseAnalytics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseAnalytics_AuthorId",
                table: "BaseAnalytics",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAnalytics_PostId",
                table: "BaseAnalytics",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseAnalytics_TagId",
                table: "BaseAnalytics",
                column: "TagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticsEntry_BaseAnalyticsId",
                table: "AnalyticsEntry",
                column: "BaseAnalyticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAnalytics_Authors_AuthorId",
                table: "BaseAnalytics",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAnalytics_Posts_PostId",
                table: "BaseAnalytics",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAnalytics_Tag_TagId",
                table: "BaseAnalytics",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseAnalytics_Authors_AuthorId",
                table: "BaseAnalytics");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAnalytics_Posts_PostId",
                table: "BaseAnalytics");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAnalytics_Tag_TagId",
                table: "BaseAnalytics");

            migrationBuilder.DropTable(
                name: "AnalyticsEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseAnalytics",
                table: "BaseAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_BaseAnalytics_AuthorId",
                table: "BaseAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_BaseAnalytics_PostId",
                table: "BaseAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_BaseAnalytics_TagId",
                table: "BaseAnalytics");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BaseAnalytics");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseAnalytics");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "BaseAnalytics");

            migrationBuilder.RenameTable(
                name: "BaseAnalytics",
                newName: "TagAnalytics");

            migrationBuilder.RenameColumn(
                name: "UniquesFromSiteCreation",
                table: "TagAnalytics",
                newName: "Uniques");

            migrationBuilder.RenameColumn(
                name: "TotalTimeFromCreation",
                table: "TagAnalytics",
                newName: "TotalTime");

            migrationBuilder.RenameColumn(
                name: "ReturningVisitorsFromSiteCreation",
                table: "TagAnalytics",
                newName: "ReturningVisitors");

            migrationBuilder.RenameColumn(
                name: "PageViewsFromSiteCreation",
                table: "TagAnalytics",
                newName: "PageViews");

            migrationBuilder.AlterColumn<Guid>(
                name: "TagId",
                table: "TagAnalytics",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TagAnalytics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagAnalytics",
                table: "TagAnalytics",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorAnalytics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PageViews = table.Column<int>(type: "integer", nullable: false),
                    ReturningVisitors = table.Column<int>(type: "integer", nullable: false),
                    TotalTime = table.Column<int>(type: "integer", nullable: false),
                    Uniques = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorAnalytics_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostAnalytics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PageViews = table.Column<int>(type: "integer", nullable: false),
                    ReturningVisitors = table.Column<int>(type: "integer", nullable: false),
                    TotalTime = table.Column<int>(type: "integer", nullable: false),
                    Uniques = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostAnalytics_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagAnalytics_TagId",
                table: "TagAnalytics",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorAnalytics_AuthorId",
                table: "AuthorAnalytics",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostAnalytics_PostId",
                table: "PostAnalytics",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagAnalytics_Tag_TagId",
                table: "TagAnalytics",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
