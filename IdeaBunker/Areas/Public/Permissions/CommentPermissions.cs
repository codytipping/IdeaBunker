namespace IdeaBunker.Permissions;

public static partial class PermissionsMaster
{
    public static class CommentPermissions
    {
        public const string View = "Permissions.Comments.View";
        public const string Create = "Permissions.Comments.Create";
        public const string Edit = "Permissions.Comments.Edit";
        public const string Delete = "Permissions.Comments.Delete";

        public static IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, };
        }
    }
}