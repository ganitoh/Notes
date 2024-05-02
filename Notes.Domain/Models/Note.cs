﻿namespace Notes.Domain.Models
{
    public  class Note
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string  Text { get; set; } = string.Empty;
        public DateTime  CreateAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
