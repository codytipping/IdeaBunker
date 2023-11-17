namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class User : BasePermissions 
    {
        public override IList<string> GetList()
        {
            return new List<string>();
        }
    }
}