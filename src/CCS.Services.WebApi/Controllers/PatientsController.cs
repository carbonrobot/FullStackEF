namespace CCS.Services.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Core;
    using Criteria;
    using Microsoft.Practices.Unity;

    [RoutePrefix("patients")]
    public class PatientsController : ApiController
    {
        [Dependency]
        public PatientService PatientService { get; set; }

        // Getting a patient by id
        [HttpGet]
        [Route("{id}")]
        public Patient Get(int id)
        {
            var response = this.PatientService.Get(id);
            HttpAssert.Success(response);
            HttpAssert.IsNotNull(response);

            return response.Result;
        }

        // Creating or updating a patient by passing the entire model
        [HttpPost]
        [Route("")]
        public Patient Update(Patient patient)
        {
            var response = this.PatientService.Save(patient, "");
            HttpAssert.Success(response);
            
            return response.Result;
        }

        // Updating partial data on a patient
        [HttpPost]
        [Route("{id}/firstName")]
        public Patient UpdateFirstName(int id, [FromBody]string firstName)
        {
            var response = this.PatientService.UpdateFirstName(id, firstName, "");
            HttpAssert.Success(response);

            return response.Result;
        }

        // Searching for a patient with a given set of criteria
        [HttpGet]
        [Route("find")]
        public IList<Patient> Find(PatientSearchCriteria criteria)
        {
            var response = this.PatientService.Find(criteria);
            HttpAssert.Success(response);

            return response.Result;
        }

        // Executing a custom store query to generate a report and validating simple input parameters
        [HttpGet]
        [Route("{id}/tracking")]
        public PatientTrackingReport GetTracking(int id, DateTime? startDate, DateTime? endDate)
        {
            HttpRequires.IsNotNull(startDate, "Start Date is required.");
            HttpRequires.IsNotNull(endDate, "End Date is required.");
            HttpRequires.IsTrue(endDate >= startDate, "End Date must be greater than or equal to the Start Date");

            var response = PatientService.GetTrackingReport(id, startDate.Value, endDate.Value);
            HttpAssert.Success(response);
            HttpAssert.IsNotNull(response);

            return response.Result;
        }
    }
}