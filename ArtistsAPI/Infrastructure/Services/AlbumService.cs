using System;
using ApplicationCore.Models;
using ApplicationCore.ServiceContracts;
using Infrastructure.Data;

namespace Infrastructure.Services
{
	public class AlbumService : IAlbumService
	{
        private readonly SpotifyClientBuilder _spotifyClientBuilder;

        public AlbumService(SpotifyClientBuilder spotifyClientBuilder)
		{
            _spotifyClientBuilder = spotifyClientBuilder;
		}

        public async Task<AlbumDetailsModel> GetAlbumDetails(string id)
        {
            var spotify = _spotifyClientBuilder.BuildClient();
            var album = await spotify.Albums.Get(id);

            var fullAlbum = new AlbumDetailsModel
            {
                SpotifyId = album.Id,
                Name = album.Name,
                CoverUrl = album.Images[0].Url,
                ReleaseDate = album.ReleaseDate,
                Type = album.Type,
                NumOfTracks = album.TotalTracks,
                Popoularity = album.Popularity
            };
            fullAlbum.Artists.AddRange(album.Artists.Select(a => new ArtistModel
            {
                SpotifyId = a.Id,
                Name = a.Name
            }));

            return fullAlbum;
        }
    }
}

