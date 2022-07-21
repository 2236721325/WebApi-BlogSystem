using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Services.ApiResult
{/// <summary>
/// 封装自己的返回值
/// </summary>
  public class ApiResult
  {
    public int Code { get; set; }
    public string Msg { get; set; }
    public int Total { get; set; }//返回的总长度
    public dynamic Data { get; set; }
  }
}
