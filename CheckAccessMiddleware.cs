using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace middleware {

  public class CheckAcessMiddleware {
    private readonly RequestDelegate _next;
    public CheckAcessMiddleware (RequestDelegate next) => _next = next;
    public async Task Invoke (HttpContext httpContext) {
      if (httpContext.Request.Path == "/testxxx") {

        Console.WriteLine ("CheckAcessMiddleware: Cấm truy cập");
        await Task.Run (
          async () => {
            string html = "<h1>CAM KHONG DUOC TRUY CAP</h1>";
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            await httpContext.Response.WriteAsync (html);
          }
        );

      } else {
        httpContext.Response.Headers.Add ("throughCheckAcessMiddleware", new [] { DateTime.Now.ToString () });

        Console.WriteLine ("CheckAcessMiddleware: Cho truy cập");

        await _next (httpContext);

      }

    }
  }

}