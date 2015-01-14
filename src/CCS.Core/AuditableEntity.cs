namespace CCS.Core
{
    using System;

    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        public string LastModifiedUser { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
