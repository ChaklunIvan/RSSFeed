using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Pagination;
using RSSFeed.Services.Interfaces;

namespace RSSFeed.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeedService _service;

        public FeedController(IFeedService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> SubscribeFeed([FromBody] string url, CancellationToken cancellationToken)
        {
            await _service.AddArticleAsync(url, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetActiveFeeds([FromQuery] PagingSettings pagingSettings, CancellationToken cancellationToken)
        {
            var articles = await _service.GetArticleListAsync(pagingSettings, cancellationToken);

            return Ok(articles);
        }

        [HttpGet("{date}")]

        public async Task<ActionResult<IEnumerable<Article>>> GetUnreadFeedsByDate([FromRoute] DateTime date, [FromQuery] PagingSettings pagingSettings, CancellationToken cancellationToken)
        {
            var articles = await _service.GetArticleListByDateAsync(date, pagingSettings, cancellationToken);

            return Ok(articles);
        }

        [HttpPatch]
        public async Task<ActionResult> ReadFeed([FromQuery] int id, CancellationToken cancellationToken)
        {
            await _service.ReadArticleAsync(id, cancellationToken);

            return Ok();
        }
    }
}
