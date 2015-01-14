namespace CCS.Core
{
    using System;

    public interface IAuditableEntity : IEntity
    {
        string LastModifiedUser { get; set; }
        DateTime LastModifiedDate { get; set; }
        DateTime DateCreated { get; set; }
    }
}
