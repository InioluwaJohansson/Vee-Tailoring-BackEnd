using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Entities;

namespace Vee_Tailoring.Context;

public class TailoringContext: DbContext
{
    public TailoringContext(DbContextOptions<TailoringContext> optionsBuilder): base(optionsBuilder)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ArmType> ArmTypes { get; set; }
    public DbSet<ClothCategory> ClothCategories { get; set; }
    public DbSet<ClothGender> ClothGender { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<DefaultPrice> DefaultPrices { get; set; }
    public DbSet<Pattern> Patterns { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Style> Styles { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderMeasurement> OrderMeasurements { get; set; }
    public DbSet<OrderAddress> OrderAddresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Complaint> Complaints { get; set; }
    public DbSet<Token> Token { get; set; }
    public DbSet<Email> Email { get; set; }
    public DbSet<Card> Card { get; set; }
}
