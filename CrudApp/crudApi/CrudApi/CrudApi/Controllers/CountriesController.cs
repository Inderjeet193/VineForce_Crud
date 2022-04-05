using BusinessLayer;
using ModelLayer;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CrudApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CountriesController : ApiController
    {

        BusinessLogic BL= new BusinessLogic();
         
        [HttpGet]
        [Route("countries/getCountries")]
        public HttpResponseMessage getCountries()
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_GetCountries();
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }

        [HttpGet]
        [Route("countries/getCountryById/{CountryId}")]
        public HttpResponseMessage getCountryById(string CountryId)
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_getCountryById(CountryId );
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }

        [HttpPost]
        [Route("countries/AddCountry")]
        public HttpResponseMessage AddCountry(Countries Countries)
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_AddCountries(Countries);
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }

        [HttpPost]
        [Route("countries/DeleteCountry/{CountryId}")]
        public HttpResponseMessage DeleteState(string CountryId)
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_DeleteCountry(CountryId);
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }
    }
}