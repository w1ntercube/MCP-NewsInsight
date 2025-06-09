using Microsoft.AspNetCore.Mvc;
using NewsInsight.Platform.Data;
using NewsInsight.Shared.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}