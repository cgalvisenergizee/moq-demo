using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
