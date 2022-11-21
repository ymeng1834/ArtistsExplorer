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
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAlbumDetails(string id)
        {
            var album = await _albumService.GetAlbumDetails(id);
            if (album == null)
            {
                return NotFound(new { errorMessage = "No album found" }); // 404
            }

            return Ok(album);
        }
    }
}

