using Microsoft.AspNet.Mvc;
using MyJoints.Core.Intrefaces.Repositories;
using MyJoints.DataAcceess.Context;
using MyJoints.Filters;
using MyJoints.ViewModel.Users;
using System;
using System.Collections.Generic;

namespace MyJoints.WebApi.Controllers
{
    [Route("api/user")]
    [MyJointsExceptionFilterAttribute]
    public class UserController : Controller
    {
        [FromServices]
        public IUserRepository UserRepository { get; set; }

        [HttpGet]
        public IEnumerable<User> Query()
        {
            var result = UserRepository.GetList();
            return result;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            var user = UserRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Save([FromBody] User user)
        {
            if (user == null)
            {
                return HttpBadRequest();
            }

            if (user.Id == 0)
            {
                UserRepository.Create(user);
                return CreatedAtRoute("GetUser", new { controller = "User", id = user.Id }, user);
            }
            else
            {
                UserRepository.Update(user);
                return new NoContentResult();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserRepository.Delete(id);
        }
    }
}
