using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfases
{
    public interface IUserDBContext
    {
        public DbSet<Domain.User> Users { get; set; }
        Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
    }
}