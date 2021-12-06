using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Data
{
  public class SportDbContext : DbContext
  {
    private readonly IMediator _mediator;

    public SportDbContext(DbContextOptions<KaizenContext> options, IMediator mediator) : base(options)
    {
      _mediator = mediator;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      var entities = ChangeTracker.Entries<DomainEntity>().ToList();

      var events = new List<INotification>();
      foreach (var entity in entities)
      {
        var domainEntity = entity.Entity;

        events.AddRange(domainEntity.Events);
        domainEntity.ClearEvents();
      }

      var result = await base.SaveChangesAsync(cancellationToken);

      foreach (var @event in events)
      {
        await _mediator.Publish(@event, cancellationToken);
      }

      return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<AuthToken> AuthTokens { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<GlobalCategory> GlobalCategories { get; set; }
    public DbSet<Idea> Ideas { get; set; }
    public DbSet<SelectedCategory> IdeaCategory { get; set; }
    public DbSet<IdeaImages> Images { get; set; }
    public DbSet<KaizenUser> KaizenUsers { get; set; }
    public DbSet<KaizenUserUserGroup> KaizenUserUserGroup { get; set; }
    public DbSet<NavAccessRights> NavAccessRights { get; set; }
    public DbSet<NavGroup> NavGroup { get; set; }
    public DbSet<NavItem> NavItem { get; set; }
    public DbSet<NavTab> NavTab { get; set; }
    public DbSet<NotificationSettings> NotificationSettings { get; set; }
    public DbSet<PaymentItem> PaymentItem { get; set; }
    public DbSet<PriceDefinition> PriceDefinition { get; set; }
    public DbSet<RedeemingVoucher> RedeemingVoucher { get; set; }
    public DbSet<ShopDefinition> ShopDefinition { get; set; }
    public DbSet<Site> Site { get; set; }
    public DbSet<StatResult> StatResult { get; set; }
    public DbSet<UserGroup> UserGroup { get; set; }
    public DbSet<VoucherDefinition> VoucherDefinition { get; set; }
    public DbSet<WeChatIdeas> WeChatIdeasLog { get; set; }
    public DbSet<PointDefinition> PointDefinitions { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<VoucherRedeem> VoucherRedeem { get; set; }
  }

  public static class SportDbContextExtensions
  {
    public static IServiceCollection AddSportDbContext(this IServiceCollection services, string connection)
    {
      services.AddDbContext<SportDbContext>(options => { options.UseSqlServer(connection); });

      return services;
    }
  }
}