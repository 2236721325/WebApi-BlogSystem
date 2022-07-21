using AutoMapper;
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
    public class WriterInfoController : ControllerBase
    {
        private readonly IBaseService<WriterInfo> WriterInfoService;
        private readonly IMapper mapper;

        public WriterInfoController(IBaseService<WriterInfo> WriterInfoService, IMapper mapper)
        {
            this.WriterInfoService = WriterInfoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetAll()
        {
            var WriterInfoList = await WriterInfoService.Query();
            if (WriterInfoList == null || WriterInfoList.Count == 0) return ApiResultHelper.Error("没有作者数据");
            else
            {
                return ApiResultHelper.Success(mapper.Map<List<WriterInfoDTO>>(WriterInfoList));
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetById(int id)
        {
            var WriterInfo = await WriterInfoService.FindAsync(id);
            if (WriterInfo == null) return ApiResultHelper.Error("找不到该作者");
            else
            {
                return ApiResultHelper.Success(mapper.Map<WriterInfoDTO>(WriterInfo));
            }
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Post(string name, string username, string userpwd)
        {
            WriterInfo writer = new WriterInfo
            {
                Name = name,
                UserName = username,
                UserPwd = userpwd
            };
            var oldWriters = await WriterInfoService.Query(e => e.Name == name);
            if (oldWriters!= null&&oldWriters.Count!=0) return ApiResultHelper.Error("账号已经存在");
            try
            {
                await WriterInfoService.AddAsync(writer);
                return ApiResultHelper.Success(mapper.Map<WriterInfoDTO>(writer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiResultHelper.Error("添加失败,或许是账号或密码太长了！");
            }
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            try
            {
                await WriterInfoService.RemoveAsync(id);
                return ApiResultHelper.Success("删除成功");

            }
            catch (Exception)
            {
                return ApiResultHelper.Error("删除失败");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ApiResult>> Put(int id,string userPwd)
        {
            var WriterInfo = await WriterInfoService.FindAsync(id);
            if (WriterInfo == null) return ApiResultHelper.Error("没有该作者");
            try
            {
                WriterInfo.UserPwd = userPwd;
                await WriterInfoService.UpdateAsync(WriterInfo);
                return ApiResultHelper.Success(mapper.Map<WriterInfoDTO>(WriterInfo));
            }
            catch (Exception)
            {
                return ApiResultHelper.Error("修改失败！");
            }
        }
        [HttpGet]
        public async Task<ApiResult> GetWriterInfoPage(int page, int size)
        {
            RefAsync<int> total = 0;
            var WriterInfoList = await WriterInfoService.Query(page, size, total);
            if (WriterInfoList == null || WriterInfoList.Count == 0) return ApiResultHelper.Error("找不到该页文章数据！");
            try
            {
                var WriterInfoDTO = mapper.Map<List<WriterInfoDTO>>(WriterInfoList);
                return ApiResultHelper.Success(WriterInfoDTO, total);
            }
            catch (Exception)
            {
                return ApiResultHelper.Error("映射错误");
            }
        }
    }
}