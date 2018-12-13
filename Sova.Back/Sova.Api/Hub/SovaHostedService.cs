using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Sova.Api.Models;

namespace Sova.Api
{
    public class SovaHostedService : IHostedService, IDisposable
    {
        /// <summary>
        /// seconds
        /// </summary>
        private const int Delay = 3;
        
        private readonly IHubContext<SovaHub> _hub;
        private readonly MessageStorage _storage;
        private Timer _timer;
        

        public SovaHostedService(IHubContext<SovaHub> hub, MessageStorage storage)
        {
            _hub = hub;
            _storage = storage;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(Delay));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var message = new Message();
            try
            {
                _hub.Clients?.All.SendAsync("newMessage", message);
                _storage.AddItem(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _storage.Clear();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}