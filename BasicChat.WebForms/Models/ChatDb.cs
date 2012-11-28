using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicChat.WebForms.Models
{
    public class ChatDb
    {
        private static List<Message> _db = new List<Message>();

        public static List<Message> GetAll()
        {
            return _db;
        }

        public static void Add(string item)
        {
            _db.Add(new Message { Value = item });
        }
    }
}