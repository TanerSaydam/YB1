using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class i_add_deadline_field_to_todo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DeadLine",
                table: "Todos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadLine",
                table: "Todos");
        }
    }
}
