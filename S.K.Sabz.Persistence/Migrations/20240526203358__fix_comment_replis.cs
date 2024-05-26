using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S.K.Sabz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _fix_comment_replis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentCommentId",
                table: "PostComments",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 27, 0, 3, 57, 986, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 27, 0, 3, 57, 986, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 27, 0, 3, 57, 986, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_ParentCommentId",
                table: "PostComments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_ParentCommentId",
                table: "PostComments",
                column: "ParentCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_ParentCommentId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_ParentCommentId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "PostComments");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 26, 22, 18, 42, 758, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 26, 22, 18, 42, 758, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 26, 22, 18, 42, 758, DateTimeKind.Local).AddTicks(5815));
        }
    }
}
