using Microsoft.AspNetCore.Mvc;
using NewsInsight.Platform.Data;
using NewsInsight.Shared.Models;
using Microsoft.EntityFrameworkCore;
using NewsInsight.Platform.Services;
using NewsInsight.Platform.McpTools;

namespace NewsInsight.Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly NewsDbContext _context;

        public NewsController(NewsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetAll()
        {
            return await _context.News
                .OrderByDescending(n => n.NewsId)
                .Take(20)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetById(string id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
                return NotFound();

            return news;
        }

        // 示例：模拟调用 MCP 工具（现在使用直接方法）
        [HttpGet("summarize/{id}")]
        public async Task<ActionResult<object>> SummarizeNews(string id)
        {
            var news = await _context.News.FirstOrDefaultAsync(n => n.NewsId == id);
            if (news == null)
                return NotFound($"未找到新闻 ID：{id}");

            // 调用摘要方法（未来可换成 DLL 封装）
            var summary = NewsSummarizer.SummarizeNews(news.NewsBody);

            return Ok(new
            {
                newsId = news.NewsId,
                headline = news.Headline,
                summary
            });
        }

        [HttpGet("keywords/{id}")]
        public async Task<ActionResult<string>> GetKeywords(string id)
        {
            // 可直接使用工具类调用，后期可封装标准 MCP 请求
            return Ok(NewsTools.ExtractKeywords(id));
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<string>>> SearchNews([FromQuery] string keyword)
        {
            var results = await _context.News
                .Where(n => n.Headline.Contains(keyword) || n.NewsBody.Contains(keyword))
                .Select(n => n.Headline)
                .Take(10)
                .ToListAsync();

            return Ok(results);
        }
    }
}