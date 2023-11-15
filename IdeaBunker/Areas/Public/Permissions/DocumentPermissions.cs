using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Differencing;

namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class DocumentPermissions : BasePermissions
    {
        public const string View = "Permissions.Documents.View";
        public const string Upload = "Permissions.Documents.Upload";
        public const string Download = "Permissions.Documents.Download";
        public const string Delete = "Permissions.Documents.Delete";

        public override IList<string> GetList()
        {
            return new List<string> { View, Upload, Download, Delete, };
        }
    }
}