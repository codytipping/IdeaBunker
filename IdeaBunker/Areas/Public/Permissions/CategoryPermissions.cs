namespace IdeaBunker.Permissions;

public static partial class PermissionsMaster
{
    public static class CategoryPermissions
    {
        public const string View = "Permissions.Categories.View";
        public const string Create = "Permissions.Categories.Create";
        public const string Edit = "Permissions.Categories.Edit";
        public const string Delete = "Permissions.Categories.Delete";

        public static IList<string> GetList()
        {
            return new List<string> { View, Create, Delete, Edit, };
        }
    }
}