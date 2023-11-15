namespace IdeaBunker.Data;

public class RolesDefault
{
    private const string Name = "PermissionsMaster";
    private const string ClaimType = "Permission";
    public static string GetName() { return Name; }
    public static string GetClaimType() { return ClaimType; }
}