namespace server.Domain.Identity;

public static class Permissions
{
    public static class Workflows
    {
        public const string View = "workflows.view";
        public const string Create = "workflows.create";
        public const string Edit = "workflows.edit";
        public const string Publish = "workflows.publish";
    }

    public static class Submissions
    {
        public const string ViewAssigned = "submissions.view_assigned";
        public const string ViewAll = "submissions.view_all";
        public const string Review = "submissions.review";
    }

    public static class Ai
    {
        public const string WorkflowGenerate = "ai.workflow.generate";
        public const string WorkflowCritique = "ai.workflow.critique";
        public const string SubmissionSummarize = "ai.submission.summarize";
        public const string SubmissionRecommend = "ai.submission.recommend";
    }

    public static class Governance
    {
        public const string AuditView = "audit.view";
        public const string RbacManage = "rbac.manage";
    }

    public static readonly string[] All =
    [
        Workflows.View,
        Workflows.Create,
        Workflows.Edit,
        Workflows.Publish,
        Submissions.ViewAssigned,
        Submissions.ViewAll,
        Submissions.Review,
        Ai.WorkflowGenerate,
        Ai.WorkflowCritique,
        Ai.SubmissionSummarize,
        Ai.SubmissionRecommend,
        Governance.AuditView,
        Governance.RbacManage
    ];
}