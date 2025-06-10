using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using NewsInsight.Platform.McpTools;

var builder = Host.CreateApplicationBuilder(args);

// MCP 日志
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Information;
});

// 注册 MCP Server
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();       // 自动扫描 [McpServerTool] 标记方法

var host = builder.Build();

// 启动 MCP Server（后台）
_ = host.RunAsync();  // Run MCP server

// 启动 Web API 服务器
await McpWebHost.RunWebAsync(args);  // Run ASP.NET Core API