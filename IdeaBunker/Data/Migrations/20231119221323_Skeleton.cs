using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdeaBunker.Migrations
{
    /// <inheritdoc />
    public partial class Skeleton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentsEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoteType = table.Column<bool>(type: "bit", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimantNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameAndRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RankId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoriesStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CategoriesStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UsersLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsersToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpvoteCount = table.Column<int>(type: "int", nullable: false),
                    DownvoteCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectsStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProjectsStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesClaim_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CategoriesStatus",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "17934f81-570b-4ed3-bec2-74946278d82f", "", "Approved" },
                    { "34576490-8250-452b-a052-a48be8f13f46", "", "Pending" },
                    { "3fd4b0f4-d882-431a-b6f6-e5d8ee09d871", "", "Archive" },
                    { "b2df4af1-c3e8-40a9-a95d-e1686744ce58", "", "Unpublished" },
                    { "cefadc65-eda5-40f6-a186-1b7a384a1d27", "", "Active" }
                });

            migrationBuilder.InsertData(
                table: "ProjectsStatus",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "1829cfb0-003c-4f98-9ec2-b599dd0aea4c", "", "Waitlist" },
                    { "456e8f06-2433-4189-a605-152b47be69af", "", "Unpublished" },
                    { "4fa89dc3-40d5-4eb8-b789-1bec37f1fbc9", "", "Active" },
                    { "7853f0b5-617c-4a29-8396-6285857f28a5", "", "Denied" },
                    { "885de3d0-1fb8-422e-8bf2-dde517f85d2d", "", "Pending" },
                    { "ca74dcc5-d84d-4ac7-86ed-d7d890bd68da", "", "Completed" },
                    { "f6ae6340-ab94-41d7-8782-10ce41b72a85", "", "Archive" },
                    { "fccf0e80-c904-4eac-9303-ad6e8a500d94", "", "Approved" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "49b402ba-9643-40c6-b9cb-63407a5bb30f", "", "Default" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "StatusId", "UserId" },
                values: new object[,]
                {
                    { "0ed0332f-69e5-4bd0-8e37-1db6ec52d143", "", "Performing Operations, Transporting", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null },
                    { "487cdca2-913a-4c7d-b767-82e73c691e52", "", "Chemistry, Metallurgy", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null },
                    { "d342870d-397b-4b1b-bcc5-5e4086828935", "", "Mechanical Engineering", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null },
                    { "d880ea24-4797-4393-a777-2ffd14b8889f", "", "Physics", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null },
                    { "e1fa8704-a22f-4f72-8d8a-4fa5f2d3c0fc", "", "Textiles, Paper", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null },
                    { "f0e83429-6f66-4efd-a6de-87118f607760", "", "Electricity", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null },
                    { "fdc05ee5-af3b-44b3-97f6-ab54af061cb2", "", "Fixed Constructions", "b2df4af1-c3e8-40a9-a95d-e1686744ce58", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_StatusId",
                table: "Categories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectId",
                table: "Comments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                table: "Documents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaim_RoleId",
                table: "RolesClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RankId",
                table: "Users",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersClaim_UserId",
                table: "UsersClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogin_UserId",
                table: "UsersLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRole_RoleId",
                table: "UsersRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesEvent");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CommentsEvent");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentsEvent");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ProjectsEvent");

            migrationBuilder.DropTable(
                name: "RolesClaim");

            migrationBuilder.DropTable(
                name: "RolesEvent");

            migrationBuilder.DropTable(
                name: "UsersClaim");

            migrationBuilder.DropTable(
                name: "UsersEvent");

            migrationBuilder.DropTable(
                name: "UsersLogin");

            migrationBuilder.DropTable(
                name: "UsersRole");

            migrationBuilder.DropTable(
                name: "UsersToken");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProjectsStatus");

            migrationBuilder.DropTable(
                name: "CategoriesStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
