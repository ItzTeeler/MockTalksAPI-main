using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockTalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MT_MessagingInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MT_MessagingInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MT_ProfileInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobInterviewLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locationed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MT_ProfileInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MT_ScheduleInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    InterviewPractice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypePractice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestQuestions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPartnered = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MT_ScheduleInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MT_UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MT_UserInfo", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MT_MessagingInfo");

            migrationBuilder.DropTable(
                name: "MT_ProfileInfo");

            migrationBuilder.DropTable(
                name: "MT_ScheduleInfo");

            migrationBuilder.DropTable(
                name: "MT_UserInfo");
        }
    }
}
