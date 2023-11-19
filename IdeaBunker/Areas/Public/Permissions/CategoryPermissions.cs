namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class Category : BasePermissions
    {
        public const string View = "PermissionsMaster.Category.View";
        public const string Create = "PermissionsMaster.Category.Create";
        public const string Edit = "PermissionsMaster.Category.Edit";
        public const string Delete = "PermissionsMaster.Category.Delete";
        public const string Publish = "PermissionsMaster.Category.Publish";       

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, Publish, };
        }
    }
}