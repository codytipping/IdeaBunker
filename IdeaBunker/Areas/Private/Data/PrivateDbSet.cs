using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context
{
    public DbSet<Clearance> Clearances { get; set; }
    public DbSet<Directorate> Directorates { get; set; }
    public DbSet<DirectorateEvent> DirectoratesEvent { get; set; }
    public DbSet<DirectorateProject> DirectoratesProject { get; set; }
    public DbSet<DirectorateRole> DirectoratesRole { get; set; }
    public DbSet<DirectorateUser> DirectoratesUser { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<DivisionEvent> DivisionsEvent { get; set; }
    public DbSet<DivisionProject> DivisionsProject { get; set; }
    public DbSet<DivisionRole> DivisionsRole { get; set; }
    public DbSet<DivisionUser> DivisionsUser { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<ProjectTaskEvent> ProjectTasksEvent { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<SectionEvent> SectionsEvent { get; set; }
    public DbSet<SectionProject> SectionsProject { get; set; }
    public DbSet<SectionRole> SectionsRole { get; set; }
    public DbSet<SectionUser> SectionsUser { get; set; }
    public DbSet<StatusProjectTask> StatusProjectTasks { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamEvent> TeamsEvent { get; set; }
    public DbSet<TeamProject> TeamsProject { get; set; }
    public DbSet<TeamRole> TeamsRole { get; set; }
    public DbSet<TeamUser> TeamsUser { get; set; }
}