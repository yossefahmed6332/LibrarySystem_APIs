using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class LibraryDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbAddresses_Person_PersonId",
                table: "TbAddresses");

            migrationBuilder.DropIndex(
                name: "IX_TbAddresses_PersonId",
                table: "TbAddresses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "TbAddresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbBooksCopies_Barcode",
                table: "TbBooksCopies",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbBooks_ISBN",
                table: "TbBooks",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PhoneNumber",
                table: "Person",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_TbAddresses_AddressId",
                table: "Person",
                column: "AddressId",
                principalTable: "TbAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_TbAddresses_AddressId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_TbBooksCopies_Barcode",
                table: "TbBooksCopies");

            migrationBuilder.DropIndex(
                name: "IX_TbBooks_ISBN",
                table: "TbBooks");

            migrationBuilder.DropIndex(
                name: "IX_Person_AddressId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_Email",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PhoneNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "TbAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbAddresses_PersonId",
                table: "TbAddresses",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAddresses_Person_PersonId",
                table: "TbAddresses",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
