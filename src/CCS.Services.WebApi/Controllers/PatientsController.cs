namespace CCS.Services.WebApi.Controllers
{
    using System.Net;
    using System.Web.Http;
    using Core;
    using Microsoft.Practices.Unity;

    [RoutePrefix("patient")]
    public class PatientsController : ApiController
    {
        [Dependency]
        public PatientService PatientService { get; set; }

        [HttpGet]
        [Route("{id}")]
        public Patient Get(int id)
        {
            var response = this.PatientService.Get(id);
            if (response.HasError)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return response.Result;
        }
    }
}