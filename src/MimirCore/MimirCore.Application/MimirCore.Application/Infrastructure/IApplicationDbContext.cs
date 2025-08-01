using Microsoft.EntityFrameworkCore;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Infrastructure;

public interface IApplicationDbContext
{
    DbSet<Department> Departments { get; }
    DbSet<Employee> Employees { get; }
    DbSet<LeaveRequest> LeaveRequests { get; }
    DbSet<LeaveType> LeaveTypes { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<Position> Positions { get; }
    DbSet<Role> Roles { get; }
    DbSet<RolePermission> RolePermissions { get; }
    DbSet<Shift> Shifts { get; }
    DbSet<ShiftTemplate> ShiftTemplates { get; }
    DbSet<SystemSetting> SystemSettings { get; }
    DbSet<Team> Teams { get; }
    DbSet<Ticket> Tickets { get; }
    DbSet<TicketAttachment> TicketAttachments { get; }
    DbSet<TicketCategory> TicketCategories { get; }
    DbSet<TicketComment> TicketComments { get; }
    DbSet<TicketHistory> TicketHistories { get; }
    DbSet<TimeLog> TimeLogs { get; }
    DbSet<User> Users { get; }
    DbSet<UserRole> UserRoles { get; }
}

