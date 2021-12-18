using System;
namespace MusicSemestrWork.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
        public string Image { get; set; }
    }
}
