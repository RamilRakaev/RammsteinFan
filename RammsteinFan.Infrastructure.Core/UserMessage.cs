using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class UserMessage : IUserMessage
    {
        public UserMessage()
        {
            SendingDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string TextMessage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SendingDate { get; set; }
    }
}
