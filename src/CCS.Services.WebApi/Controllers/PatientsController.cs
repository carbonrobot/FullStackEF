namespace CCS.Services.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using Core;
    using Criteria;
    using Microsoft.Practices.Unity;

    [RoutePrefix("patients")]
    public class PatientsController : ApiController
    {
        [Dependency]
        public PatientService PatientService { get; set; }

        [HttpGet]
        [Route("find")]
        public IList<Patient> Find(PatientSearchCriteria criteria)
        {
            var response = this.PatientService.Find(criteria);
            if (response.HasError)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return response.Result;
        }

        [HttpGet]
        [Route("{id}")]
        public Patient Get(int id)
        {
            var response = this.PatientService.Get(id);
            if (response.HasError)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            if (response.Result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return response.Result;
        }

        [HttpPost]
        [Route("")]
        public Patient Update(Patient patient)
        {
            var response = this.PatientService.Save(patient, "");
            if (response.HasError)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return response.Result;
        }

        [HttpPost]
        [Route("")]
        public Patient UpdateFirstName(int id, [FromBody]string firstName)
        {
            var response = this.PatientService.UpdateFirstName(id, firstName, "");
            if (response.HasError)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return response.Result;
        }
    }
}