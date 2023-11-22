using Moflix.Core.Application.DTOs.Email;
using Moflix.Core.Domain.Settings;

namespace Moflix.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings MailSettings { get; }

        Task SendAsync(EmailRequest request);
    }
}