using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtistsAPI.Controllers
{
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenres();
            if (genres == null || !genres.Any())
            {
                return NotFound(new { errorMessage = "No genres found" }); // 404
            }
            return Ok(genres);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var genre = await _genreService.GetGenreDetails(id);
            if (genre == null)
            {
                return NotFound(new { errorMessage = "No genre found" }); // 404
            }
            return Ok(genre);
        }

        [HttpGet]
        [Route("{id}/subgenres")]
        public async Task<IActionResult> GetSubgenres(int id)
        {
            var subgenres = await _genreService.GetSubgenresOfGenre(id);
            if (subgenres == null || !subgenres.Any())
            {
                return NotFound(new { errorMessage = "No subgenres found" }); // 404
            }
            return Ok(subgenres);
        }

        [HttpGet]
        [Route("{id}/artists")]
        public async Task<IActionResult> GetArtists(int id, [FromQuery] int pageSize = 8, [FromQuery] int page = 1)
        {
            var artists = await _genreService.GetArtistsOfGenrePaged(id, pageSize, page);
            if (artists?.Data?.Any() == false)
            {
                return NotFound(new { errorMessage = "No artists found for search query" });
            }

            return Ok(artists);
        }

        [HttpGet]
        [Route("subgenres/{subgenreId}/artists")]
        public async Task<IActionResult> GetSubgenreArtists(int subgenreId, [FromQuery] int pageSize = 8, [FromQuery] int page = 1)
        {
            var artists = await _genreService.GetArtistsOfSubgenrePaged(subgenreId, pageSize, page);
            if (artists?.Data?.Any() == false)
            {
                return NotFound(new { errorMessage = "No artists found for search query" });
            }
            return Ok(artists);
        }
    }
}

