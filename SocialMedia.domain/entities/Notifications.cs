﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.domain.entities
{
    public class Notifications
    {
        public int Id { get; set; } 

        public int UserId { get; set; } 

        public string NotificationType { get; set; } = string.Empty; 

        public string Message { get; set; } = string.Empty; 

        public bool IsRead { get; set; } = false; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public Users Recipient { get; set; }
    }
}