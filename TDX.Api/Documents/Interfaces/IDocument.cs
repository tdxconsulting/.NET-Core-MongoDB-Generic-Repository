using System;
namespace TDX.Api.Documents
{
    public interface IDocument
    {
        string Id { get; set; }

        string ParentId { get; set; }

        DateTime Created { get; set; }

        string CreatedBy { get; set; }

        DateTime Updated { get; set; }

        string UpdatedBy { get; set; }

        DateTime SoftDeleted { get; set; }

        string SoftDeletedBy { get; set; }

        bool IsSoftDeleted { get; set; }

        bool IsActive { get; set; }
    }
}
