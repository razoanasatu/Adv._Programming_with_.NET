using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.Controllers
{
    [RoutePrefix("api/rsvp")]
    public class RSVPController : ApiController
    {
        
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllRSVPs()
        {
            try
            {
                var data = RSVPService.Get(); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetRSVPById(int id)
        {
            try
            {
                var data = RSVPService.Get(id); 
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "RSVP not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

      
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateRSVP(RSVPDTO rsvp)
        {
            try
            {
                var success = RSVPService.Create(rsvp);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "RSVP created successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "RSVP creation failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateRSVP(RSVPDTO rsvp)
        {
            try
            {
                var success = RSVPService.Update(rsvp);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "RSVP updated successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "RSVP update failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

       
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteRSVP(int id)
        {
            try
            {
                var success = RSVPService.Delete(id);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "RSVP deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "RSVP not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
