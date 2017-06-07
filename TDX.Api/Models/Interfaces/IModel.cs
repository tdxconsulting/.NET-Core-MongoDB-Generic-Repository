using System;
namespace TDX.Api.Models
{
    public interface IModel
    {
        string Id { get; set; }

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
