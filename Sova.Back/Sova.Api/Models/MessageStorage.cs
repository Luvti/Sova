using System.Collections.Generic;

namespace Sova.Api.Models
{
    public class MessageStorage
    {
        private readonly LinkedList<Message> _messages;

        public MessageStorage()
        {
            _messages = new LinkedList<Message>();
        }

        public void AddItem(Message message)
        {
            _messages.AddFirst(message);
        }

        public void Clear()
        {
            _messages.Clear();
        }

        public LinkedList<Message> GetAll()
        {
            return _messages;
        }
    }
}