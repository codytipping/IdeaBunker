namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class Document : BasePermissions
    {
        public const string View = "PermissionsMaster.Document.View";
        public const string Upload = "PermissionsMaster.Document.Upload";
        public const string Download = "PermissionsMaster.Document.Download";
        public const string Delete = "PermissionsMaster.Document.Delete";

        public override IList<string> GetList()
        {
            return new List<string> { View, Upload, Download, Delete, };
        }
    }
}