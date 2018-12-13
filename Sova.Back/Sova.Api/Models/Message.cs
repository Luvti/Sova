using System;

namespace Sova.Api.Models
{
    public class Message
    {
        
        private readonly string[] _messageTypes = { "error", "success", "warning"};
        
        public DateTime ReceiveDate { get;  set; }
        public string MessageType { get; set; }
        public string Text { get; set; }

        public Message()
        {
            ReceiveDate = DateTime.Now;
            var random = new Random();
            var index = random.Next(0, 3);
            MessageType = _messageTypes[index];
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        }
    }
}
