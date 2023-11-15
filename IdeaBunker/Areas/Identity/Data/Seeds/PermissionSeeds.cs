namespace IdeaBunker.Seeds;

public class PermissionSeeds
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        if (module == "Categories")
        {
            return new List<string>
                {
                    Categories.View,
                    Categories.Create,
                    Categories.Edit,
                    Categories.Delete,
                    Categories.Publish,
                };
        }
        else if (module == "Comments")
        {
            return new List<string>()
                {
                    Comments.Create,
                    Comments.View,
                    Comments.Edit,
                    Comments.Delete,
                };
        }
        else if (module == "Documents")
        {
            return new List<string>()
                {
                    Documents.View,
                    Documents.Upload,
                    Documents.Download,
                    Documents.Delete,
                };
        }
        else if (module == "PermissionSet")
        {
            return new List<string>()
                {
                    PermissionSet.View,
                };
        }
        else if (module == "Projects")
        {
            return new List<string>()
                {
                    Projects.View,
                    Projects.Create,
                    Projects.Edit,
                    Projects.Delete,
                    Projects.Publish,
                    Projects.Vote,
                };
        }
        else
        {
            return new List<string>()
                {
                    Roles.View,
                    Roles.Create,
                    Roles.Edit,
                    Roles.Delete,
                    Roles.Assign,
                };
        }
    }
    public static class Categories
    {
        public const string View = "Permissions.Categories.View";
        public const string Create = "Permissions.Categories.Create";
        public const string Edit = "Permissions.Categories.Edit";
        public const string Delete = "Permissions.Categories.Delete";
        public const string Publish = "Permissions.Categories.Publish";
    }
    public static class Comments
    {
        public const string View = "Permissions.Comments.View";
        public const string Create = "Permissions.Comments.Create";
        public const string Edit = "Permissions.Comments.Edit";
        public const string Delete = "Permissions.Comments.Delete";
    }
    public static class Documents
    {
        public const string View = "Permissions.Documents.View";
        public const string Upload = "Permissions.Documents.Upload";
        public const string Download = "Permissions.Documents.Download";
        public const string Delete = "Permissions.Documents.Delete";
    }
    public static class PermissionSet
    {
        public const string View = "Permissions.PermissionSet.View";
    }
    public static class Projects
    {
        public const string View = "Permissions.Projects.View";
        public const string Create = "Permissions.Projects.Create";
        public const string Edit = "Permissions.Projects.Edit";
        public const string Delete = "Permissions.Projects.Delete";
        public const string Publish = "Permissions.Projects.Publish";
        public const string Vote = "Permissions.Projects.Vote";
    }
    public static class Roles
    {
        public const string View = "Permissions.Roles.View";
        public const string Create = "Permissions.Roles.Create";
        public const string Edit = "Permissions.Roles.Edit";
        public const string Delete = "Permissions.Roles.Delete";
        public const string Assign = "Permissions.Roles.Assign";
    }
}