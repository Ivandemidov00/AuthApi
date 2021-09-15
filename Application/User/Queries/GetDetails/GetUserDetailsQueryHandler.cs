
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exception;
using Application.Interfases;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries.GetDetails
{
    public class GetUserDetailsQueryHandler:IRequestHandler<GetUserDetailsQuery,UserDetailsVm>
    {
        
        private readonly IUserDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IUserDBContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext
                .Users
                .Where(p =>p.Id ==request.id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null || entity.Id != request.id)
            {
                throw new NotFoundException(nameof(Task), request.id);
            }

            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
    
}