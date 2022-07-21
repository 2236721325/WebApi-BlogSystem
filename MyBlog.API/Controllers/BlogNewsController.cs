using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Common;
using MyBlog.API.Models;
using MyBlog.API.Models.DTOS;
using MyBlog.API.Services;
using MyBlog.WebApi.Services.ApiResult;

namespace MyBlog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBaseService<BlogNews> blogNewsService;
        private readonly IMapper mapper;

        public BlogNewsController(IBaseService<BlogNews> blogNewsService,IMapper mapper)
        {
            this.blogNewsService = blogNewsService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetAll()
        {
            var blogNewsList = await blogNewsService.Query();
            if (blogNewsList==null|| blogNewsList.Count == 0 ) return ApiResultHelper.Error("没有文章数据");
            else
            {
                return ApiResultHelper.Success(mapper.Map<List<BlogNewsDTO>>(blogNewsList));
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetByWriterId(int writerid)
        {
            var blogNewsList = await blogNewsService.Query(e => e.WriterInfoId == writerid);
            if (blogNewsList == null|| blogNewsList.Count==0) return ApiResultHelper.Error("找不到该文章");
            else
            {
                return ApiResultHelper.Success(mapper.Map<List<BlogNewsDTO>>(blogNewsList));
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetById(int id)
        {
            var blogNews = await blogNewsService.FindAsync(id);
            if (blogNews == null) return ApiResultHelper.Error("找不到该文章");
            else
            {
                return ApiResultHelper.Success(mapper.Map<BlogNewsDTO>(blogNews));
            }
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Post(string title,string content, int typeInfoId,int writerid)
        {
            BlogNews blogNews = new BlogNews
            {
                Content = content,
                Title = title,
                TypeInfoId = typeInfoId,
                WriterInfoId = writerid
            };
            try
            {
                await blogNewsService.AddAsync(blogNews);
                return ApiResultHelper.Success(mapper.Map<BlogNewsDTO>(blogNews));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiResultHelper.Error("添加失败，服务器发生错误！"+ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            try
            {
                await blogNewsService.RemoveAsync(id);
                return ApiResultHelper.Success("删除成功");

            }
            catch (Exception)
            {
                return ApiResultHelper.Error("删除失败");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ApiResult>> Put(int id, string title, string content, int typeid)
        {
            var blogNews = await blogNewsService.FindAsync(id);
            if (blogNews == null) return ApiResultHelper.Error("没有找到该文章");
            blogNews.Title = title;
            blogNews.Content = content;
            blogNews.TypeInfoId = typeid;
            try
            {
                await blogNewsService.UpdateAsync(blogNews);
                return ApiResultHelper.Success(mapper.Map<BlogNewsDTO>(blogNews));
            }
            catch (Exception)
            {
                return ApiResultHelper.Error("修改失败！");
            }
        }
        [HttpGet]
        public async Task<ApiResult> GetBlogNewsPage(int page, int size)
        {
            RefAsync<int> total = 0;
            var blognewsList = await blogNewsService.Query(page, size, total);
            if (blognewsList == null || blognewsList.Count == 0) return ApiResultHelper.Error("找不到该页文章数据！");
            try
            {
                var blognewsDTO = mapper.Map<List<BlogNewsDTO>>(blognewsList);
                return ApiResultHelper.Success(blognewsDTO, total);
            }
            catch (Exception)
            {
                return ApiResultHelper.Error("映射错误");
            }
        }
    }
}
