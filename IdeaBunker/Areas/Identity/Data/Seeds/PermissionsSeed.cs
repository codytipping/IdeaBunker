using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Policy;

namespace IdeaBunker.Seeds;

public static class Categories
{
    
}

public static class Comments
{
    
}

public static class Documents
{
    
}

public static class Projects
{
    public const string View = "Permissions.Projects.View";
    public const string Create = "Permissions.Projects.Create";
    public const string Edit = "Permissions.Projects.Edit";
    public const string Delete = "Permissions.Projects.Delete";
    public const string Publish = "Permissions.Projects.Publish";
    public const string Vote = "Permissions.Projects.Vote";

    public static IList<string> GetAllPermissions()
    {
        return new List<string> { View, Create, Edit, Delete, Publish, Vote, };
    }
}