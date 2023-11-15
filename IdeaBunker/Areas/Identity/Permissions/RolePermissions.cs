namespace IdeaBunker.Permissions;

public static partial class PermissionsMaster 
{
    public static class RolePermissions
    {
        public const string View = "Permissions.Roles.View";
        public const string Create = "Permissions.Roles.Create";
        public const string Edit = "Permissions.Roles.Edit";
        public const string Delete = "Permissions.Roles.Delete";
        public const string Assign = "Permissions.Roles.Assign";

        public static IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, Assign, };
        }
    }
}