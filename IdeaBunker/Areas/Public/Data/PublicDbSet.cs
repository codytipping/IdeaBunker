using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryEvent> CategoriesEvent { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentEvent> CommentsEvent { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentEvent> DocumentsEvent { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectEvent> ProjectsEvent { get; set; }
    public DbSet<StatusCategory> StatusCategories { get; set; }
    public DbSet<StatusProject> StatusProjects { get; set; }
}