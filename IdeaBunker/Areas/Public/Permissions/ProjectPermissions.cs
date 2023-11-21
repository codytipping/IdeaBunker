namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class Project : BasePermissions
    {
        public const string View = "PermissionsMaster.Project.View";
        public const string Create = "PermissionsMaster.Project.Create";
        public const string Edit = "PermissionsMaster.Project.Edit";
        public const string Delete = "PermissionsMaster.Project.Delete";
        public const string Publish = "PermissionsMaster.Project.Publish";
        public const string Vote = "PermissionsMaster.Project.Vote";

        public override IList<string> GetList()
        {
            return new List<string> { View, Create, Edit, Delete, Publish, Vote, };
        }
    }
}