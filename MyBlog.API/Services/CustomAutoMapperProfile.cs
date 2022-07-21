using AutoMapper;
using MyBlog.API.Controllers;
using MyBlog.API.Models;
using MyBlog.API.Models.DTOS;

namespace MyBlog.API.Services
{
    /// <summary>
    /// AutoMapper包来映射
    /// </summary>
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<WriterInfo, WriterInfoDTO>();
            base.CreateMap<BlogNews, BlogNewsDTO>();
            base.CreateMap<TypeInfo, TypeInfoDTO>();
        }
    }

}

