namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class CategoryPermissions : BasePermissions
    {
        public const string View = "Permissions.Categories.View";
        public const string Create = "Permissions.Categories.Create";
        public const string Edit = "Permissions.Categories.Edit";
        public const string Delete = "Permissions.Categories.Delete";

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, };
        }
    }
}