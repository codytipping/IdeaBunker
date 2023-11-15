namespace IdeaBunker.Permissions;

public partial class PermissionsMaster 
{
    public class RolePermissions : BasePermissions
    {
        public const string View = "Permissions.Roles.View";
        public const string Create = "Permissions.Roles.Create";
        public const string Edit = "Permissions.Roles.Edit";
        public const string Delete = "Permissions.Roles.Delete";
        public const string Assign = "Permissions.Roles.Assign";

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, Assign, };
        }
    }
}