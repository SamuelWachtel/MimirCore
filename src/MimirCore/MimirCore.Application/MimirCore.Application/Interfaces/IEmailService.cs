namespace MimirCore.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = false);
    Task SendEmailAsync(IEnumerable<string> to, string subject, string body, bool isHtml = false);
    Task SendTemplateEmailAsync<T>(string to, string templateName, T model) where T : class;
}