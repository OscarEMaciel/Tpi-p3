using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Sale> Transactions { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<SysAdmin> SysAdmins { get; set; }
    public DbSet<Admin> Admins { get; set; }



    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de las relaciones entre entidades
        modelBuilder.Entity<SaleDetail>()
             .HasKey(sd => new { sd.SaleId, sd.ItemId });

         modelBuilder.Entity<SaleDetail>()
             .HasOne(sd => sd.Sale)
             .WithMany(s => s.TransactionDetails)
             .HasForeignKey(sd => sd.SaleId);

         modelBuilder.Entity<SaleDetail>()
             .HasOne(sd => sd.Item)
             .WithMany()
             .HasForeignKey(sd => sd.ItemId);

        // Configuración adicional de entidades si es necesario
        modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

        base.OnModelCreating(modelBuilder);
    }
}

