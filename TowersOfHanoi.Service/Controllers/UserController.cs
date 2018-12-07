using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TowersOfHanoi.Application.Users.Commands;

namespace TowersOfHanoi.Service.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {

        private readonly ICreateUserCommand _createUserCommand;

        public UserController(ICreateUserCommand createUserCommand)
        {
            _createUserCommand = createUserCommand;
        }


        public async Task<IHttpActionResult> Post(string name)
        {
            var result = await _createUserCommand.Execute(new CreateUserRequestDto {Name = name});
            return Ok(result);
        }
    }
}