using System.Threading.Tasks;

namespace Sova.Api
{
    public interface IHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
