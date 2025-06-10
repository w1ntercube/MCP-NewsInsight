using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCP.NET;

namespace NewsInsight.MCPServer
{
    public static class ServerStartup
    {
        private static MCPServer _server;

        public static void Start(Func<string, string> summarizeFunc)
        {
            _server = new MCPServer();
            _server.AddToolProvider(new NewsToolProvider(summarizeFunc));
            _server.Start(11000); // 默认监听11000端口
            Console.WriteLine("[MCP] MCP Server started on port 11000");
        }
    }
}
