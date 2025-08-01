using MimirCore.Application.Models;
using MimirCore.Application.Models.Employee;
using MimirCore.Application.Models.Shift;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.Interfaces;

public interface ICsvExportService
{
    Task<byte[]> ExportEmployeesAsync(IEnumerable<EmployeeDto> employees);
    Task<byte[]> ExportShiftsAsync(IEnumerable<ShiftDto> shifts);
    Task<byte[]> ExportTicketsAsync(IEnumerable<TicketDto> tickets);
}