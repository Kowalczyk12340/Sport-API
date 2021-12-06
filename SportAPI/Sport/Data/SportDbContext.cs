using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportAPI.Sport.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SportAPI.Sport.Data
{
  public class SportDbContext : DbContext
  {
    private readonly IMediator _mediator;

    public SportDbContext(DbContextOptions<SportDbContext> options, IMediator mediator) : base(options)
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

    public DbSet<CategorySport> CategorySports { get; set; }
    public DbSet<AuthTokenConfiguration> AuthTokens { get; set; }
    public DbSet<CategorySportsman> CategorySportsmans { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Information> Informations { get; set; }
    public DbSet<Journalist> Journalists { get; set; }
    public DbSet<SportDiscipline> Disciplines { get; set; }
    public DbSet<Sportsman> Sportsmen { get; set; }
    public DbSet<SportSportsman> SportSportsmen { get; set; }
    public DbSet<StatusInformation> StatusInformations { get; set; }
    public DbSet<User> Users { get; set; }
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