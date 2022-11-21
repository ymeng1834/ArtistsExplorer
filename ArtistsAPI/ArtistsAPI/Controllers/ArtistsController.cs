using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtistsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;
        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetArtistDetails(string id)
        {
            var artist = await _artistService.GetArtistDetails(id);
            if (artist == null)
            {
                return NotFound(new { errorMessage = "No artist found" }); // 404
            }
            return Ok(artist);
        }

        [HttpGet]
        [Route("{id}/albums")]
        public async Task<IActionResult> GetAlbumsOfArtist(string id, [FromQuery] int pageSize = 4, [FromQuery] int page = 1)
        {
            var albums = await _artistService.GetAlbumsOfArtistPaged(id, pageSize, page);
            if (albums?.Data?.Any() == false)
            {
                return NotFound(new { errorMessage = "No albums found for search query" });
            }

            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}/singles")]
        public async Task<IActionResult> GetSinglesOfArtist(string id, [FromQuery] int pageSize = 4, [FromQuery] int page = 1)
        {
            var singles = await _artistService.GetSinglesOfArtistPaged(id, pageSize, page);
            if (singles?.Data?.Any() == false)
            {
                return NotFound(new { errorMessage = "No singles found for search query" });
            }

            return Ok(singles);
        }

    }
}

