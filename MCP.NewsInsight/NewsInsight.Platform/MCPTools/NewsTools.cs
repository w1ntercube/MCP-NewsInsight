using ModelContextProtocol.Server;
using System.ComponentModel;

namespace NewsInsight.Platform.McpTools;

[McpServerToolType]
public static class NewsTools
{
    [McpServerTool(Name = "summarize_news")]
    [Description("根据新闻ID返回摘要")]
    public static string Summarize(string newsId)
    {
        return $"这是新闻 {newsId} 的摘要（模拟）";
    }

    [McpServerTool(Name = "extract_keywords")]
    [Description("根据新闻ID，提取关键词")]
    public static string ExtractKeywords(int newsId)
    {
        return $"关键词：{newsId.ToString()}, 示例关键词1, 示例关键词2";
    }

    [McpServerTool(Name = "categorize_news")]
    [Description("返回新闻的分类")]
    public static string Categorize(int newsId)
    {
        if (newsId.ToString().Contains("100"))
            return "Sports";

        return "Unknown";
    }
}
