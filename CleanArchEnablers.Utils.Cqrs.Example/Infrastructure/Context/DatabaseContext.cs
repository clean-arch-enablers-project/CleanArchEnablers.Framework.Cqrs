using CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Context;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
}