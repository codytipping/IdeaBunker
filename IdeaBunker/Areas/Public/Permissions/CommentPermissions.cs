namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class Comment : BasePermissions
    {
        public const string View = "PermissionsMaster.Comment.View";
        public const string Create = "PermissionsMaster.Comment.Create";
        public const string Edit = "PermissionsMaster.Comment.Edit";
        public const string Delete = "PermissionsMaster.Comment.Delete";

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, };
        }
    }
}