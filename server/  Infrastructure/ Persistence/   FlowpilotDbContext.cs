using Microsoft.EntityFrameworkCore;
using server.Domain.Identity;

namespace server.Infrastructure.Persistence;

public sealed class FlowpilotDbContext : DbContext
{
    public FlowpilotDbContext(DbContextOptions<FlowpilotDbContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(250);

            entity.HasIndex(x => x.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("permissions");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Code)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(250);

            entity.HasIndex(x => x.Code)
                .IsUnique();
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.ToTable("role_permissions");

            entity.HasKey(x => new { x.RoleId, x.PermissionId });

            entity.HasOne(x => x.Role)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = RbacSeedData.AdminRoleId,
                Name = RoleNames.Admin,
                Description = "Full administrative access across workflows, AI governance, and RBAC."
            },
            new Role
            {
                Id = RbacSeedData.DesignerRoleId,
                Name = RoleNames.Designer,
                Description = "Can create and manage workflows and use workflow design AI features."
            },
            new Role
            {
                Id = RbacSeedData.ReviewerRoleId,
                Name = RoleNames.Reviewer,
                Description = "Can review submissions and use AI reviewer assistance."
            },
            new Role
            {
                Id = RbacSeedData.RequesterRoleId,
                Name = RoleNames.Requester,
                Description = "Can access requester-facing workflow functionality."
            }
        );

        modelBuilder.Entity<Permission>().HasData(
            server.Domain.Identity.Permissions.All
                .Select(code => new Permission
                {
                    Id = RbacSeedData.PermissionIds[code],
                    Code = code,
                    Description = code
                })
                .ToArray()
        );

        var roleIds = new Dictionary<string, Guid>
        {
            [RoleNames.Admin] = RbacSeedData.AdminRoleId,
            [RoleNames.Designer] = RbacSeedData.DesignerRoleId,
            [RoleNames.Reviewer] = RbacSeedData.ReviewerRoleId,
            [RoleNames.Requester] = RbacSeedData.RequesterRoleId
        };

        var rolePermissions = RolePermissionMappings.Map
            .SelectMany(roleMapping => roleMapping.Value.Select(permissionCode => new RolePermission
            {
                RoleId = roleIds[roleMapping.Key],
                PermissionId = RbacSeedData.PermissionIds[permissionCode]
            }))
            .ToArray();

        modelBuilder.Entity<RolePermission>().HasData(rolePermissions);
    }
}