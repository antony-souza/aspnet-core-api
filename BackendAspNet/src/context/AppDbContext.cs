using BackendAspNet.modules.user.entity;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<UserEntity> User { get; set; }

}