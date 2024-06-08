namespace VisitorSecuritySys.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}
