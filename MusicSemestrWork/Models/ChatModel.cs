using System;
using System.Collections.Generic;

namespace MusicSemestrWork.Models
{
    public class ChatModel
    {
        public List<ChatUser> Users;  // Все пользователи чата

        public List<ChatMessage> Messages; // все сообщения

        public ChatModel()
        {
            Users = new List<ChatUser>();
            Messages = new List<ChatMessage>();

            Messages.Add(new ChatMessage()
            {
                Text = "Чат запущен " + DateTime.Now
            });
        }
    }

    public class ChatUser
    {
        public string Name;
        public DateTime LoginTime;
        public DateTime LastPing;
    }

    public class ChatMessage
    {
        // автор сообщения, если null - автор сервер
        public ChatUser User;
        // время сообщения
        public DateTime Date = DateTime.Now;
        // текст сообщения
        public string Text = "";
    }
}
