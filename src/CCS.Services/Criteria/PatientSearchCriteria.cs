namespace CCS.Services.Criteria
{
    using System;
    using System.Linq;
    using Core;

    public class PatientSearchCriteria : SearchCriteria<Patient>
    {
        public string LastName { get; set; }
        
        public override IQueryable<Patient> ApplyTo(IQueryable<Patient> query)
        {
            if (!string.IsNullOrEmpty(this.LastName))
            {
                query = query.Where(x => String.Equals(x.NameLast, this.LastName, StringComparison.InvariantCultureIgnoreCase));
            }
            return query;
        }
    }
}
