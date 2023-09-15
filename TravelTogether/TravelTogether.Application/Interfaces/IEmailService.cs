using System.Threading.Tasks;
using TravelTogether.Application.DTOs.Email;

namespace TravelTogether.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}