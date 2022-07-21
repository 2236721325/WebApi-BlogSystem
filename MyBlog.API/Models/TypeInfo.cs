namespace MyBlog.API.Models
{
    public class TypeInfo : BaseId
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }

        public List<BlogNews> BlogNewses { get; set; }
    }
}
