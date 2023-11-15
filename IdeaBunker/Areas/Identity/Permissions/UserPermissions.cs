namespace IdeaBunker.Permissions;

public partial class PermissionsMaster
{
    public class UserPermissions : BasePermissions 
    {
        public override IList<string> GetList()
        {
            return new List<string>();
        }
    }
}