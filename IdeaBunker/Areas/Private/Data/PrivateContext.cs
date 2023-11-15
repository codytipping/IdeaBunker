using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context
{
    public void PrivateContext(ModelBuilder builder)
    {
        DirectorateBuilder.ConfigureDirectorate(builder);
        DivisionBuilder.ConfigureDivision(builder);
        ProjectTaskBuilder.ConfigureProjectTask(builder);
        SectionBuilder.ConfigureSection(builder);
        SeedPrivateBuilder.ConfigurePrivateSeedData(builder);
        TeamBuilder.ConfigureTeam(builder);
    }
}