using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Species = table.Column<string>(nullable: false),
                    Breed = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    ShelterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.ShelterId);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Breed", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 3, "Calico", "Mouse", "Cat" },
                    { 2, 13, "Terrier", "Tookie", "Dog" },
                    { 3, 8, "Mini", "Guy", "Horse" },
                    { 4, 57, "Diamondback", "Mr. Bigglesworth", "Turtle" },
                    { 5, 2, "Mini Lop", "Sandy", "Bunny" },
                    { 6, 5, "Goldendoodle", "Celine Dion", "Dog" },
                    { 7, 16, "Sphynx", "Nood", "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "ShelterId", "City", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Portland", "Pups N' Stuff", "Oregon" },
                    { 2, "Santa Cruz", "YSPCA", "California" },
                    { 3, "Boise", "The Animal Shelter", "Idaho" },
                    { 4, "Troutdale", "PetCo", "Oregon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
