using Microsoft.EntityFrameworkCore;

namespace MyBlog.API.Models.Context
{
    public class MyBlogContext : DbContext
    {
        public DbSet<BlogNews> BlogNewses { get; set; }
        public DbSet<WriterInfo> WriterInfos { get; set; }
        public DbSet<TypeInfo> TypeInfos { get; set; }
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            
        }
        



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BlogNews>(et =>
            {
                et.HasKey(t => t.Id);
                et.Property(t => t.Title).HasMaxLength(32);
                et.Property(t => t.CreateTime).HasDefaultValueSql("getdate()");
                et.Property(t => t.Content).HasColumnType("text");
                et.HasOne(t => t.WriterInfo).WithMany(t => t.BlogNewses);
                et.HasOne(t => t.TypeInfo).WithMany(t => t.BlogNewses);
                
            });

            builder.Entity<WriterInfo>(et =>
            {
                et.HasKey(t => t.Id);
                et.Property(t => t.CreateTime).HasDefaultValueSql("getdate()");
                et.Property(t => t.Name).HasMaxLength(12);
                et.Property(t => t.UserName).HasMaxLength(16);
                et.Property(t => t.UserPwd).HasMaxLength(64);

            });

            builder.Entity<TypeInfo>(et =>
            {
                et.HasKey(t => t.Id);
                et.Property(t => t.CreateTime).HasDefaultValueSql("getdate()");
                et.Property(t => t.Name).HasMaxLength(12);

            });
        }
      
    }
}
