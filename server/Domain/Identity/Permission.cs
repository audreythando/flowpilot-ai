namespace server.Domain.Identity;

public sealed class Permission
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}