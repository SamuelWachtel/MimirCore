using MimirCore.Application.Models;
using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(int userId, string title, string message, string type = "info");
    Task SendBulkNotificationAsync(IEnumerable<int> userIds, string title, string message, string type = "info");
    Task<IEnumerable<Notification>> GetUserNotificationsAsync(int userId, bool unreadOnly = false);
    Task MarkAsReadAsync(int notificationId);
}