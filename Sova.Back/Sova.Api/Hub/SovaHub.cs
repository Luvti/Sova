using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Sova.Api.Models;

namespace Sova.Api
{
    public class SovaHub: Hub
    {
        private readonly MessageStorage _storage;
        
        public SovaHub(MessageStorage storage)
        {
            _storage = storage;
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("messages", _storage.GetAll());
            return base.OnConnectedAsync();
        }
        
    }
}
