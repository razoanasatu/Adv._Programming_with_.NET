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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        
        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserDTO user)
        {
            try
            {
                var success = UserService.Register(user);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "User registered successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Registration failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var isAuthenticated = UserService.VerifyCredentials(login.Uname, login.Password);
                if (isAuthenticated)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Login successful");
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserService.Get();
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
                var data = UserService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(UserDTO user)
        {
            try
            {
                var success = UserService.Update(user);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User updated successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Update failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

       
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var success = UserService.Delete(id);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
