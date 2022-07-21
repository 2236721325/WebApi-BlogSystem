using AutoMapper;

namespace MyBlog.API.Models.DTOS
{
    public class BlogNewsDTO:BaseId
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int TypeInfoId { get; set; }

        public int WriterInfoId { get; set; }

        public int BrowseCount { get; set; }
        public int LikeCount { get; set; }

    }
}
