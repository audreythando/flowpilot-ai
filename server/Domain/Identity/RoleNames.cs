namespace server.Domain.Identity;

public static class RoleNames
{
    public const string Admin = "Admin";
    public const string Designer = "Designer";
    public const string Reviewer = "Reviewer";
    public const string Requester = "Requester";

    public static readonly string[] All =
    [
        Admin,
        Designer,
        Reviewer,
        Requester
    ];
}