using BackendAspNet.modules.category.entity;
using BackendAspNet.modules.order.entity;
using BackendAspNet.modules.product.entity;
using BackendAspNet.modules.store.entity;
using BackendAspNet.modules.user.entity;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNet.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<UserEntity> User { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<ProductEntity> Product { get; set; }
    public DbSet<StoreEntity> Store { get; set; }
    public DbSet<OrderEntity> Sale { get; set; }
}