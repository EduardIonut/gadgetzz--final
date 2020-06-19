using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Services
{

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // incomplet
            return Task.CompletedTask;
        }
    }
}
