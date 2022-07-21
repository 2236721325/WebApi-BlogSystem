namespace MyBlog.API.Models.DTOS
{
    public class WriterInfoDTO : BaseId
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
