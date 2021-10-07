using Microsoft.EntityFrameworkCore.Migrations;

namespace InspiringMagazine20056663Prac3.Data.Migrations
{
    public partial class CreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    email = table.Column<string>(nullable: false),
                    familyName = table.Column<string>(nullable: false),
                    givenName = table.Column<string>(nullable: false),
                    dateOfBirth = table.Column<string>(nullable: true),
                    mobileNumber = table.Column<string>(nullable: false),
                    postalCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Magazine",
                columns: table => new
                {
                    magazineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    magazineName = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazine", x => x.magazineID);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    magazineID = table.Column<int>(nullable: false),
                    customerEmail = table.Column<string>(nullable: true),
                    numOfIssues = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subscription_Customer_customerEmail",
                        column: x => x.customerEmail,
                        principalTable: "Customer",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscription_Magazine_magazineID",
                        column: x => x.magazineID,
                        principalTable: "Magazine",
                        principalColumn: "magazineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_customerEmail",
                table: "Subscription",
                column: "customerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_magazineID",
                table: "Subscription",
                column: "magazineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Magazine");
        }
    }
}
