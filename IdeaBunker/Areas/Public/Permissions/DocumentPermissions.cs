namespace IdeaBunker.Permissions;

public static partial class PermissionsMaster
{
    public static class DocumentPermissions
    {
        public const string View = "Permissions.Documents.View";
        public const string Upload = "Permissions.Documents.Upload";
        public const string Download = "Permissions.Documents.Download";
        public const string Delete = "Permissions.Documents.Delete";

        public static IList<string> GetList()
        {
            return new List<string> { View, Upload, Download, Delete, };
        }
    }
}