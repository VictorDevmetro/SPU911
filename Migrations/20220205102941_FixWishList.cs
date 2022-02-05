using Microsoft.EntityFrameworkCore.Migrations;

namespace SPU911.Migrations
{
    public partial class FixWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InWishList",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InWishList",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
