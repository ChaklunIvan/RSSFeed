using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSSFeed.Models.Entities;
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
        public async Task<ActionResult<IEnumerable<Article>>> GetActiveFeeds(CancellationToken cancellationToken)
        {
            var articles = await _service.GetArticleListAsync(cancellationToken);

            return Ok(articles);
        }

        [HttpGet("date")]

        public async Task<ActionResult<IEnumerable<Article>>> GetUnreadFeedsByDate([FromQuery] DateTime date, CancellationToken cancellationToken)
        {
            var articles = await _service.GetArticleListByDateAsync(date, cancellationToken);

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
