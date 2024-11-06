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
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
       
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = EventService.Get(); 
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message); 
            }
        }

        
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = EventService.Get(id); 
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Event not found"); 
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
        public HttpResponseMessage Create(EventDTO obj)
        {
            try
            {
                var success = EventService.Create(obj); 
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Event created successfully"); 
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Event creation failed"); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message); 
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(EventDTO obj)
        {
            try
            {
                var success = EventService.Update(obj); 
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Event updated successfully"); 
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Event update failed"); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message); 
            }
        }

       
        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var success = EventService.Delete(id); 
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Event deleted successfully"); 
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Event not found"); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
