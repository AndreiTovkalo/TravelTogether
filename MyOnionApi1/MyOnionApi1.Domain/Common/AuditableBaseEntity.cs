using System;

namespace MyOnionApi1.Domain.Common
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}