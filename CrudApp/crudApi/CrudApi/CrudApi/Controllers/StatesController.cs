using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CrudApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StatesController : ApiController
    {
        BusinessLogic BL = new BusinessLogic();
      

        [HttpGet]
        [Route("states/getStates")]
        public HttpResponseMessage getStates()
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_GetStates();
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, Response);

            }

        }
        [HttpPost]
        [Route("states/AddState")]
        public HttpResponseMessage AddState(State state)
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_Addstate(state);
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }

        [HttpGet]
        [Route("states/getStateById/{stateid}")]
        public HttpResponseMessage getCountryById(string stateid)
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_getStateById(stateid);
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }


        [HttpPost]
        [Route("states/DeleteState/{stateid}")]
        public HttpResponseMessage DeleteState(string stateid)
        {
            string Response = string.Empty;
            try
            {
                var res = BL.bl_DeleteState(stateid);
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }
    }
}