using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimirCore.Domain.Entities;

namespace MimirCore.Infrastructure.Persistance;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsRelational())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (await _context.Roles.AnyAsync())
        {
            return;
        }

        await SeedRolesAsync();
        await SeedPermissionsAsync();
        await SeedRolePermissionsAsync();
        await SeedLeaveTypesAsync();
        await SeedTicketCategoriesAsync();
        await SeedShiftTemplatesAsync();
        await SeedSystemSettingsAsync();

        await _context.SaveChangesAsync();
    }

    private async Task SeedRolesAsync()
    {
        if (await _context.Roles.AnyAsync())
        {
            return;
        }

        _context.Roles.AddRange(
            new Role 
            { 
                Name = "Admin", 
                Description = "System Administrator", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new Role 
            { 
                Name = "HR Manager", 
                Description = "HR Manager", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new Role 
            { 
                Name = "Department Chief", 
                Description = "Department Chief", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new Role 
            { 
                Name = "Team Leader", 
                Description = "Team Leader", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new Role 
            { 
                Name = "Employee", 
                Description = "Regular Employee", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new Role 
            { 
                Name = "IT Support", 
                Description = "IT Support Staff", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            }
        );
    }

    private async Task SeedPermissionsAsync()
    {
        if (await _context.Permissions.AnyAsync())
        {
            return;
        }

        _context.Permissions.AddRange(
            new Permission { Name = "Users.View", Description = "View users", Module = "Users", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Users.Create", Description = "Create users", Module = "Users", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Users.Edit", Description = "Edit users", Module = "Users", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Users.Delete", Description = "Delete users", Module = "Users", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "Employees.View", Description = "View employees", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Employees.Create", Description = "Create employees", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Employees.Edit", Description = "Edit employees", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Employees.Delete", Description = "Delete employees", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "Teams.View", Description = "View teams", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Teams.Create", Description = "Create teams", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Teams.Edit", Description = "Edit teams", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Teams.Delete", Description = "Delete teams", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "Departments.View", Description = "View departments", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Departments.Create", Description = "Create departments", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Departments.Edit", Description = "Edit departments", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Departments.Delete", Description = "Delete departments", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "Leaves.View", Description = "View leave requests", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Leaves.Create", Description = "Create leave requests", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Leaves.Approve", Description = "Approve leave requests", Module = "HR", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "Shifts.View", Description = "View shifts", Module = "Shifts", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Shifts.Create", Description = "Create shifts", Module = "Shifts", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Shifts.Edit", Description = "Edit shifts", Module = "Shifts", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Shifts.Delete", Description = "Delete shifts", Module = "Shifts", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "Tickets.View", Description = "View tickets", Module = "Tickets", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Tickets.Create", Description = "Create tickets", Module = "Tickets", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Tickets.Edit", Description = "Edit tickets", Module = "Tickets", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Tickets.Assign", Description = "Assign tickets", Module = "Tickets", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "Tickets.Close", Description = "Close tickets", Module = "Tickets", CreatedBy = "System", ModifiedBy = "System" },
            
            new Permission { Name = "System.Settings", Description = "Manage system settings", Module = "System", CreatedBy = "System", ModifiedBy = "System" },
            new Permission { Name = "System.Reports", Description = "View system reports", Module = "System", CreatedBy = "System", ModifiedBy = "System" }
        );
    }

    private async Task SeedRolePermissionsAsync()
    {
        if (await _context.RolePermissions.AnyAsync())
        {
            return;
        }

        var roles = await _context.Roles.ToListAsync();
        var permissions = await _context.Permissions.ToListAsync();

        var adminRole = roles.First(r => r.Name == "Admin");
        var hrManagerRole = roles.First(r => r.Name == "HR Manager");
        var deptChiefRole = roles.First(r => r.Name == "Department Chief");
        var teamLeaderRole = roles.First(r => r.Name == "Team Leader");
        var employeeRole = roles.First(r => r.Name == "Employee");
        var itSupportRole = roles.First(r => r.Name == "IT Support");

        var rolePermissions = new List<RolePermission>();

        foreach (var permission in permissions)
        {
            rolePermissions.Add(new RolePermission 
            { 
                RoleId = adminRole.Id, 
                PermissionId = permission.Id, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            });
        }

        var hrPermissions = permissions.Where(p => 
            p.Module == "HR" || 
            p.Name.StartsWith("Users.") || 
            p.Name == "System.Reports").ToList();
        
        foreach (var permission in hrPermissions)
        {
            rolePermissions.Add(new RolePermission 
            { 
                RoleId = hrManagerRole.Id, 
                PermissionId = permission.Id, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            });
        }

        var deptPermissions = permissions.Where(p => 
            p.Name.StartsWith("Teams.") || 
            p.Name.StartsWith("Employees.View") || 
            p.Name.StartsWith("Employees.Edit") ||
            p.Name.StartsWith("Leaves.") ||
            p.Name.StartsWith("Shifts.")).ToList();
        
        foreach (var permission in deptPermissions)
        {
            rolePermissions.Add(new RolePermission 
            { 
                RoleId = deptChiefRole.Id, 
                PermissionId = permission.Id, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            });
        }

        var teamPermissions = permissions.Where(p => 
            p.Name == "Teams.View" || 
            p.Name == "Teams.Edit" ||
            p.Name == "Employees.View" || 
            p.Name == "Leaves.View" ||
            p.Name == "Leaves.Approve" ||
            p.Name.StartsWith("Shifts.")).ToList();
        
        foreach (var permission in teamPermissions)
        {
            rolePermissions.Add(new RolePermission 
            { 
                RoleId = teamLeaderRole.Id, 
                PermissionId = permission.Id, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            });
        }

        var empPermissions = permissions.Where(p => 
            p.Name == "Employees.View" || 
            p.Name == "Teams.View" ||
            p.Name == "Leaves.View" ||
            p.Name == "Leaves.Create" ||
            p.Name == "Shifts.View" ||
            p.Name == "Tickets.View" ||
            p.Name == "Tickets.Create").ToList();
        
        foreach (var permission in empPermissions)
        {
            rolePermissions.Add(new RolePermission 
            { 
                RoleId = employeeRole.Id, 
                PermissionId = permission.Id, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            });
        }

        var itPermissions = permissions.Where(p => 
            p.Name.StartsWith("Tickets.") ||
            p.Name == "Employees.View" ||
            p.Name == "Teams.View").ToList();
        
        foreach (var permission in itPermissions)
        {
            rolePermissions.Add(new RolePermission 
            { 
                RoleId = itSupportRole.Id, 
                PermissionId = permission.Id, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            });
        }

        _context.RolePermissions.AddRange(rolePermissions);
    }

    private async Task SeedLeaveTypesAsync()
    {
        if (await _context.LeaveTypes.AnyAsync())
        {
            return;
        }

        _context.LeaveTypes.AddRange(
            new LeaveType 
            { 
                Name = "Annual Leave", 
                Description = "Annual vacation leave", 
                MaxDaysPerYear = 25, 
                RequiresApproval = true, 
                IsPaid = true, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new LeaveType 
            { 
                Name = "Sick Leave", 
                Description = "Medical leave", 
                MaxDaysPerYear = 10, 
                RequiresApproval = false, 
                IsPaid = true, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new LeaveType 
            { 
                Name = "Personal Leave", 
                Description = "Personal time off", 
                MaxDaysPerYear = 5, 
                RequiresApproval = true, 
                IsPaid = false, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new LeaveType 
            { 
                Name = "Maternity Leave", 
                Description = "Maternity leave", 
                MaxDaysPerYear = 180, 
                RequiresApproval = true, 
                IsPaid = true, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new LeaveType 
            { 
                Name = "Paternity Leave", 
                Description = "Paternity leave", 
                MaxDaysPerYear = 14, 
                RequiresApproval = true, 
                IsPaid = true, 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            }
        );
    }

    private async Task SeedTicketCategoriesAsync()
    {
        if (await _context.TicketCategories.AnyAsync())
        {
            return;
        }

        _context.TicketCategories.AddRange(
            new TicketCategory 
            { 
                Name = "IT Support", 
                Description = "IT related issues", 
                Color = "#007bff", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new TicketCategory 
            { 
                Name = "HR Request", 
                Description = "HR related requests", 
                Color = "#28a745", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new TicketCategory 
            { 
                Name = "Facilities", 
                Description = "Facility management", 
                Color = "#ffc107", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new TicketCategory 
            { 
                Name = "Finance", 
                Description = "Finance related issues", 
                Color = "#dc3545", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new TicketCategory 
            { 
                Name = "General", 
                Description = "General inquiries", 
                Color = "#6c757d", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            }
        );
    }

    private async Task SeedShiftTemplatesAsync()
    {
        if (await _context.ShiftTemplates.AnyAsync())
        {
            return;
        }

        _context.ShiftTemplates.AddRange(
            new ShiftTemplate 
            { 
                Name = "Morning Shift", 
                StartTime = new TimeSpan(8, 0, 0), 
                EndTime = new TimeSpan(16, 0, 0), 
                DurationMinutes = 480, 
                ShiftType = "Morning", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new ShiftTemplate 
            { 
                Name = "Evening Shift", 
                StartTime = new TimeSpan(16, 0, 0), 
                EndTime = new TimeSpan(24, 0, 0), 
                DurationMinutes = 480, 
                ShiftType = "Evening", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new ShiftTemplate 
            { 
                Name = "Night Shift", 
                StartTime = new TimeSpan(0, 0, 0), 
                EndTime = new TimeSpan(8, 0, 0), 
                DurationMinutes = 480, 
                ShiftType = "Night", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            }
        );
    }

    private async Task SeedSystemSettingsAsync()
    {
        if (await _context.SystemSettings.AnyAsync())
        {
            return;
        }

        _context.SystemSettings.AddRange(
            new SystemSetting 
            { 
                Key = "Company.Name", 
                Value = "Your Company Name", 
                Description = "Company name displayed throughout the system", 
                Category = "General", 
                DataType = "String", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new SystemSetting 
            { 
                Key = "Shifts.AutoApprove", 
                Value = "false", 
                Description = "Automatically approve shift changes", 
                Category = "Shifts", 
                DataType = "Boolean", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new SystemSetting 
            { 
                Key = "Tickets.AutoAssign", 
                Value = "false", 
                Description = "Automatically assign tickets to available staff", 
                Category = "Tickets", 
                DataType = "Boolean", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            },
            new SystemSetting 
            { 
                Key = "Leaves.MaxAdvanceDays", 
                Value = "30", 
                Description = "Maximum days in advance to request leave", 
                Category = "Leaves", 
                DataType = "Integer", 
                CreatedBy = "System", 
                ModifiedBy = "System" 
            }
        );
    }
}
