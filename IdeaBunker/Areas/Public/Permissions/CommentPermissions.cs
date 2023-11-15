namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class CommentPermissions : BasePermissions
    {
        public const string View = "Permissions.Comments.View";
        public const string Create = "Permissions.Comments.Create";
        public const string Edit = "Permissions.Comments.Edit";
        public const string Delete = "Permissions.Comments.Delete";

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, };
        }
    }
}