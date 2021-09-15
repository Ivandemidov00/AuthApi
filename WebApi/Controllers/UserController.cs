using System;
using System.Threading.Tasks;
using Application.User.Queries.GetDetails;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UserController:ControllersBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet("get-my-info")]
        public async Task<ActionResult<UserDetailsVm>> get(Int32 id)
        {
           
            var query = new GetUserDetailsQuery()
            {
                id = 1
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}