using Microsoft.AspNetCore.SignalR;
using SocialHub.SignalR;

namespace SocialHubAPI.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyUser(string userId, string message)
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
        }
    }
}
