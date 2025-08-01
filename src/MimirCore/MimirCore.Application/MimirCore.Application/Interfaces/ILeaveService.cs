using MimirCore.Application.Models;
using MimirCore.Application.Models.Leave;

namespace MimirCore.Application.Interfaces;

public interface ILeaveService
{
    Task<LeaveRequestDto> GetByIdAsync(int id);
    Task<IEnumerable<LeaveRequestDto>> GetByEmployeeAsync(int employeeId);
    Task<IEnumerable<LeaveRequestDto>> GetPendingApprovalsAsync(int approverId);
    Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto createLeaveRequestDto);
    Task UpdateAsync(UpdateLeaveRequestDto updateLeaveRequestDto);
    Task ApproveAsync(int leaveRequestId, int approverId, string? comments = null);
    Task RejectAsync(int leaveRequestId, int approverId, string comments);
    Task<int> GetRemainingLeaveDaysAsync(int employeeId, int leaveTypeId, int year);
}