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
public class TypeInfoController : ControllerBase
{
    private readonly IBaseService<TypeInfo> TypeInfoService;
    private readonly IMapper mapper;

    public TypeInfoController(IBaseService<TypeInfo> TypeInfoService, IMapper mapper)
    {
        this.TypeInfoService = TypeInfoService;
        this.mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<ApiResult>> GetAll()
    {
        var TypeInfoList = await TypeInfoService.Query();
        if (TypeInfoList == null || TypeInfoList.Count == 0) return ApiResultHelper.Error("没有类型数据");
        else
        {
            return ApiResultHelper.Success(mapper.Map<List<TypeInfoDTO>>(TypeInfoList));
        }
    }
    [HttpGet]
    public async Task<ActionResult<ApiResult>> GetById(int id)
    {
        var TypeInfo = await TypeInfoService.FindAsync(id);
        if (TypeInfo == null) return ApiResultHelper.Error("找不到该类型");
        else
        {
            return ApiResultHelper.Success(mapper.Map<TypeInfoDTO>(TypeInfo));
        }
    }
    [HttpPost]
    public async Task<ActionResult<ApiResult>> Post(string name)
    {
        TypeInfo typeInfo = new TypeInfo
        {
            Name=name
        };
        try
        {
            await TypeInfoService.AddAsync(typeInfo);
            return ApiResultHelper.Success(mapper.Map<TypeInfoDTO>(typeInfo));
        }
        catch (Exception)
        {
            return ApiResultHelper.Error("添加失败，服务器发生错误！");
        }
    }
    [HttpDelete]
    public async Task<ActionResult<ApiResult>> Delete(int id)
    {
        try
        {
            await TypeInfoService.RemoveAsync(id);
            return ApiResultHelper.Success("删除成功");

        }
        catch (Exception)
        {
            return ApiResultHelper.Error("删除失败");
        }
    }
    [HttpPut]
    public async Task<ActionResult<ApiResult>> Put(int id,string name)
    {
        var typeInfo = await TypeInfoService.FindAsync(id);
        if (typeInfo == null) return ApiResultHelper.Error("没有找到该类型");
        typeInfo.Name = name;
        try
        {
            await TypeInfoService.UpdateAsync(typeInfo);
            return ApiResultHelper.Success(typeInfo);
        }
        catch (Exception)
        {
            return ApiResultHelper.Error("修改失败！");
        }
    }
    [HttpGet]
    public async Task<ApiResult> GetTypeInfoPage(int page, int size)
    {
        RefAsync<int> total = 0;
        var TypeInfoList = await TypeInfoService.Query(page, size, total);
        if (TypeInfoList == null || TypeInfoList.Count == 0) return ApiResultHelper.Error("找不到该页类型数据！");
        try
        {
            var TypeInfoDTO = mapper.Map<List<TypeInfoDTO>>(TypeInfoList);
            return ApiResultHelper.Success(TypeInfoDTO, total);
        }
        catch (Exception)
        {
            return ApiResultHelper.Error("映射错误");
        }
    }
}
}
