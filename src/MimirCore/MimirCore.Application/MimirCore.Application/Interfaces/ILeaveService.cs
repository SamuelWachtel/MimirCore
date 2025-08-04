using MimirCore.Application.Models.Leave;

namespace MimirCore.Application.Interfaces;

public interface ILeaveService
{
    Task<LeaveRequestDto> GetByIdAsync(Guid id);
    Task<IEnumerable<LeaveRequestDto>> GetByEmployeeAsync(Guid employeeId);
    Task<IEnumerable<LeaveRequestDto>> GetPendingApprovalsAsync(Guid approverId);
    Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto createLeaveRequestDto);
    Task UpdateAsync(UpdateLeaveRequestDto updateLeaveRequestDto);
    Task ApproveAsync(Guid leaveRequestId, Guid approverId, string? comments = null);
    Task RejectAsync(Guid leaveRequestId, Guid approverId, string comments);
    Task<int> GetRemainingLeaveDaysAsync(Guid employeeId, Guid leaveTypeId, int year);
}