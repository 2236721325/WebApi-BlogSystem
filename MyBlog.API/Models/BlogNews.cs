namespace MyBlog.API.Models
{
    public class BlogNews : BaseId
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int TypeInfoId { get; set; }
        public TypeInfo TypeInfo { get; set; }

        public int WriterInfoId { get; set; }
        public WriterInfo WriterInfo { get; set; }

        public int BrowseCount { get; set; }
        public int LikeCount { get; set; }

    }
}
