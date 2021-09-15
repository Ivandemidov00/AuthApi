using System;
using MediatR;

namespace Application.User.Queries.GetDetails
{
    public class GetUserDetailsQuery:IRequest<UserDetailsVm>
        {
            public Int32 id { get; set; }
        }
    
}