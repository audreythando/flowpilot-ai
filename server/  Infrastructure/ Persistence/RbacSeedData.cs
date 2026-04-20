using server.Domain.Identity;

namespace server.Infrastructure.Persistence;

public static class RbacSeedData
{
    public static readonly Guid AdminRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid DesignerRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid ReviewerRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid RequesterRoleId = Guid.Parse("44444444-4444-4444-4444-444444444444");

    public static readonly Dictionary<string, Guid> PermissionIds = new()
    {
        [Permissions.Workflows.View] = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
        [Permissions.Workflows.Create] = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
        [Permissions.Workflows.Edit] = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
        [Permissions.Workflows.Publish] = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),

        [Permissions.Submissions.ViewAssigned] = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
        [Permissions.Submissions.ViewAll] = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
        [Permissions.Submissions.Review] = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"),

        [Permissions.Ai.WorkflowGenerate] = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc1"),
        [Permissions.Ai.WorkflowCritique] = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc2"),
        [Permissions.Ai.SubmissionSummarize] = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc3"),
        [Permissions.Ai.SubmissionRecommend] = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc4"),

        [Permissions.Governance.AuditView] = Guid.Parse("dddddddd-dddd-dddd-dddd-ddddddddddd1"),
        [Permissions.Governance.RbacManage] = Guid.Parse("dddddddd-dddd-dddd-dddd-ddddddddddd2")
    };
}