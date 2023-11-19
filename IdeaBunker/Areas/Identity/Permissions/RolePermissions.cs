namespace IdeaBunker.Permissions;

public partial class PermissionsMaster 
{
    public class Role : BasePermissions
    {
        public const string View = "PermissionsMaster.Role.View";
        public const string Create = "PermissionsMaster.Role.Create";
        public const string Edit = "PermissionsMaster.Role.Edit";
        public const string Delete = "PermissionsMaster.Role.Delete";
        public const string Assign = "PermissionsMaster.Role.Assign";

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, Assign, };
        }
    }
}