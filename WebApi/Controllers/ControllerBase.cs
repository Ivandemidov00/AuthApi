using System;
using System.Security.Claims;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/account/")]
    public abstract class ControllersBase:ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        internal Int32 IGuid => !User.Identity.IsAuthenticated
            ? 0
            : Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
    
}