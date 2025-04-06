using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Context;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
}