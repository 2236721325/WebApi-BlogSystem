namespace MyBlog.API.Models
{
    public class WriterInfo : BaseId
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public DateTime CreateTime { get; set; }
        public List<BlogNews> BlogNewses { get; set; }

    }
}
