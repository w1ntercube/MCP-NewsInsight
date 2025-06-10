using MCP.NET;
using NewsInsight.Shared.Models;

namespace NewsInsight.MCPServer
{
    public class NewsToolProvider : IToolProvider
    {
        private readonly Func<string, string> _summarizeFunc;

        public NewsToolProvider(Func<string, string> summarizeFunc)
        {
            _summarizeFunc = summarizeFunc;
        }

        public IEnumerable<Tool> GetTools()
        {
            yield return new Tool
            {
                Name = "summarize_news",
                Description = "对指定新闻ID生成摘要",
                Parameters = new[] { "newsId" },
                Invoke = async (parameters) =>
                {
                    string newsId = parameters["newsId"];
                    return _summarizeFunc(newsId);
                }
            };
        }
    }
}
