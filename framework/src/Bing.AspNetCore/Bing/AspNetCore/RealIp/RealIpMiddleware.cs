﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bing.AspNetCore.RealIp
{
    /// <summary>
    /// 真实IP中间件
    /// </summary>
    public class RealIpMiddleware : IMiddleware
    {
        /// <summary>
        /// 方法
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 真实IP选项
        /// </summary>
        private readonly RealIpOptions _options;

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<RealIpMiddleware> _logger;

        /// <summary>
        /// 初始化一个<see cref="RealIpMiddleware"/>类型的实例
        /// </summary>
        /// <param name="next">方法</param>
        /// <param name="options">真实IP选项</param>
        /// <param name="logger">日志</param>
        public RealIpMiddleware(RequestDelegate next, IOptions<RealIpOptions> options, ILogger<RealIpMiddleware> logger)
        {
            _next = next;
            _options = options.Value;
            _logger = logger;
        }

        /// <summary>
        /// 执行中间件拦截逻辑
        /// </summary>
        /// <param name="context">Http上下文</param>
        public async Task InvokeAsync(HttpContext context)
        {
            var headers = context.Request.Headers;
            try
            {
                if (headers.ContainsKey(_options.HeaderKey))
                {
                    context.Connection.RemoteIpAddress = IPAddress.Parse(
                        _options.HeaderKey.Equals("x-forwarded-for", StringComparison.CurrentCultureIgnoreCase)
                            ? headers["X-Forwarded-For"].ToString().Split(',')[0]
                            : headers[_options.HeaderKey].ToString());
                    _logger.LogDebug($"解析真实IP成功: {context.Connection.RemoteIpAddress}");
                }
            }
            finally
            {
                await _next(context);
            }
        }
    }

    /// <summary>
    /// 真实IP选项
    /// </summary>
    public class RealIpOptions
    {
        /// <summary>
        /// 请求头键名
        /// </summary>
        public string HeaderKey { get; set; }
    }

    /// <summary>
    /// 真实IP过滤器
    /// </summary>
    public class RealIpFilter : IStartupFilter
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="next">方法</param>
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
        {
            app.UseMiddleware<RealIpMiddleware>();
            next(app);
        };
    }
}
