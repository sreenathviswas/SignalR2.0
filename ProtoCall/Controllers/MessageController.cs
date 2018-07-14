using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ProtoCall
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<ApplicationHub> _hubContext;
        public MessageController(IHubContext<ApplicationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("/message")]
        public Task PostMessage(ChatMessage message)
        {
            return _hubContext.Clients.All.SendAsync("Send", message.Message);
        }
    }
}