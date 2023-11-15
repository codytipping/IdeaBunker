namespace IdeaBunker.Data;

public class UsersDefault
{
    private const string FirstName = "Permissions";
    private const string LastName = "Master";
    private const string UserName = "Permissions Master";
    private const string Email = "permissionsmaster@email.com";
    private const string Password = "123Pa$$word!";

    public static string GetFirstName() { return FirstName; }
    public static string GetLastName() { return LastName; }
    public static string GetUserName() { return UserName; }
    public static string GetEmail() { return Email; }
    public static string GetPassword() { return Password; }
}