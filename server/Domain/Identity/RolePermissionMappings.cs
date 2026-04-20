namespace server.Domain.Identity;

public static class RolePermissionMappings
{
    public static readonly Dictionary<string, string[]> Map = new()
    {
        [RoleNames.Admin] =
        [
            Permissions.Workflows.View,
            Permissions.Workflows.Create,
            Permissions.Workflows.Edit,
            Permissions.Workflows.Publish,
            Permissions.Submissions.ViewAssigned,
            Permissions.Submissions.ViewAll,
            Permissions.Submissions.Review,
            Permissions.Ai.WorkflowGenerate,
            Permissions.Ai.WorkflowCritique,
            Permissions.Ai.SubmissionSummarize,
            Permissions.Ai.SubmissionRecommend,
            Permissions.Governance.AuditView,
            Permissions.Governance.RbacManage
        ],

        [RoleNames.Designer] =
        [
            Permissions.Workflows.View,
            Permissions.Workflows.Create,
            Permissions.Workflows.Edit,
            Permissions.Ai.WorkflowGenerate,
            Permissions.Ai.WorkflowCritique
        ],

        [RoleNames.Reviewer] =
        [
            Permissions.Workflows.View,
            Permissions.Submissions.ViewAssigned,
            Permissions.Submissions.Review,
            Permissions.Ai.SubmissionSummarize,
            Permissions.Ai.SubmissionRecommend
        ],

        [RoleNames.Requester] =
        [
            Permissions.Workflows.View
        ]
    };
}