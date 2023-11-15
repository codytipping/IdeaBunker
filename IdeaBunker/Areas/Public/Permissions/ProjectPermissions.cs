namespace IdeaBunker.Permissions;

public static partial class PermissionsMaster
{
    public static class ProjectPermissions
    {
        public const string View = "Permissions.Projects.View";
        public const string Create = "Permissions.Projects.Create";
        public const string Edit = "Permissions.Projects.Edit";
        public const string Delete = "Permissions.Projects.Delete";
        public const string Publish = "Permissions.Projects.Publish";
        public const string Vote = "Permissions.Projects.Vote";

        public static IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, Publish, Vote, };
        }
    }
}   