namespace CCS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Validators;
    using Criteria;
    using Data;

    public class PatientService : BaseService
    {
        private readonly Func<IUCareDataContext> _contextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService"/> class.
        /// </summary>
        /// <param name="contextFactory">The context factory.</param>
        public PatientService(Func<IUCareDataContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        /// <summary>
        /// Searches the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>ServiceResponse&lt;IList&lt;Patient&gt;&gt;.</returns>
        public ServiceResponse<IList<Patient>> Find(PatientSearchCriteria criteria)
        {
            Func<IList<Patient>> func = delegate
            {
                using (var context = _contextFactory())
                {
                    return context.AsQueryable<Patient>().Apply(criteria).ToList();
                }
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Gets a patient by its id. Throws an exception if not found.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ServiceResponse&lt;Patient&gt;.</returns>
        public ServiceResponse<Patient> Get(int id)
        {
            Func<Patient> func = delegate
            {
                using (var context = _contextFactory())
                {
                    return context.Get<Patient>(id);
                }
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Saves the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="userName">Name of the user making changes.</param>
        /// <returns>ServiceResponse&lt;Patient&gt;.</returns>
        public ServiceResponse<Patient> Save(Patient patient, string userName)
        {
            Func<Patient> func = delegate
            {
                Authorize(patient, userName);
                Validate(patient, new PatientValidator());

                using (var context = _contextFactory())
                {
                    return context.Save(patient, userName);
                }
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Updates the first name of a patient.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>ServiceResponse&lt;Patient&gt;.</returns>
        public ServiceResponse<Patient> UpdateFirstName(int id, string firstName, string userName)
        {
            Func<Patient> func = delegate
            {
                using (var context = _contextFactory())
                {
                    var patient = context.Get<Patient>(id);
                    if (patient == null)
                        throw new ArgumentOutOfRangeException("Entity not found");

                    patient.NameFirst = firstName;

                    Authorize(patient, userName);
                    Validate(patient, new PatientValidator());

                    return context.Save(patient, userName);
                }
            };
            return this.Execute(func);
        }
    }
}