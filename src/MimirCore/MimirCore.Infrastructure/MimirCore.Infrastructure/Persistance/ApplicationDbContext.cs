using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using MimirCore.Application.Infrastructure;
using MimirCore.Domain.Entities;

namespace MimirCore.Infrastructure.Persistance;

public class ApplicationDbContext : ApplicationDbContextBase, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<DatabaseParamsConfig> databaseParamsOptions,
        IMediator mediator,
        IAuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, mediator, auditableEntitySaveChangesInterceptor, databaseParamsOptions)
    {
    }

    public override Assembly EntityConfigurationAssembly => Assembly.GetExecutingAssembly();

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<ShiftTemplate> ShiftTemplates => Set<ShiftTemplate>();
    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<TicketAttachment> TicketAttachments => Set<TicketAttachment>();
    public DbSet<TicketCategory> TicketCategories => Set<TicketCategory>();
    public DbSet<TicketComment> TicketComments => Set<TicketComment>();
    public DbSet<TicketHistory> TicketHistories => Set<TicketHistory>();
    public DbSet<TimeLog> TimeLogs => Set<TimeLog>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
}

public abstract class ApplicationDbContextBase : DbContext
{
    private readonly IMediator _mediator;
    private readonly IAuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private readonly DatabaseParamsConfig _databaseParams;

    public abstract Assembly EntityConfigurationAssembly { get; }

    protected ApplicationDbContextBase(
        DbContextOptions options,
        IMediator mediator,
        IAuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor,
        IOptions<DatabaseParamsConfig> databaseParamsOptions)
        : base(options)
    {
        this._mediator = mediator;
        this._auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        this._databaseParams = databaseParamsOptions.Value;
    }

    protected sealed override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(this.EntityConfigurationAssembly);
        base.OnModelCreating(builder);
        builder.HasDefaultSchema(this._databaseParams.DatabaseSchema);
        this.OnModelCreatingInternal(builder);
    }

    protected virtual void OnModelCreatingInternal(ModelBuilder modelBuilder)
    {
    }

    protected sealed override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors((IInterceptor) this._auditableEntitySaveChangesInterceptor);
    }

    public sealed override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
        await _mediator.DispatchDomainEvents(this);
        return await base.SaveChangesAsync(cancellationToken);
    }
}

public static class MediatorExtensions
{
    public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context)
    {
        BaseEntity[] array = context.ChangeTracker.Entries<BaseEntity>().Where<EntityEntry<BaseEntity>>((Func<EntityEntry<BaseEntity>, bool>) (e => e.Entity.DomainEvents.Count != 0)).Select<EntityEntry<BaseEntity>, BaseEntity>((Func<EntityEntry<BaseEntity>, BaseEntity>) (e => e.Entity)).ToArray<BaseEntity>();
        List<BaseEvent> list = ((IEnumerable<BaseEntity>) array).SelectMany<BaseEntity, BaseEvent>((Func<BaseEntity, IEnumerable<BaseEvent>>) (e => (IEnumerable<BaseEvent>) e.DomainEvents)).ToList<BaseEvent>();
        ((IEnumerable<BaseEntity>) array).ToList<BaseEntity>().ForEach((Action<BaseEntity>) (e => e.ClearDomainEvents()));
        foreach (BaseEvent notification in list)
            await mediator.Publish<BaseEvent>(notification);
    }
}

public abstract class BaseEntity
{
    private readonly List<BaseEvent> _domainEvents = new List<BaseEvent>();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents
    {
        get => (IReadOnlyCollection<BaseEvent>) this._domainEvents.AsReadOnly();
    }

    public void AddDomainEvent(BaseEvent domainEvent) => this._domainEvents.Add(domainEvent);

    public void RemoveDomainEvent(BaseEvent domainEvent) => this._domainEvents.Remove(domainEvent);

    public void ClearDomainEvents() => this._domainEvents.Clear();
}

public abstract class BaseEvent : INotification
{
}

public sealed class DatabaseParamsConfig
{
    public const string SectionName = "DatabaseParams";

    public string DatabaseSchema { get; init; } = "eit";
}

public interface IAuditableEntitySaveChangesInterceptor : IInterceptor
{
    InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result);

    ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default (CancellationToken));

    void UpdateEntities(DbContext? context);
}