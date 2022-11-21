using System;
using ApplicationCore.Models;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Data;
using SpotifyAPI.Web;

namespace Infrastructure.Services
{
	public class ArtistService : IArtistService
	{
        private readonly IGenreRepository _genreRepository;
        private readonly SpotifyClientBuilder _spotifyClientBuilder;

        public ArtistService(IGenreRepository genreRepository, SpotifyClientBuilder spotifyClientBuilder)
		{
            _genreRepository = genreRepository;
            _spotifyClientBuilder = spotifyClientBuilder;
		}

        public async Task<PagedResultSet<AlbumModel>> GetAlbumsOfArtistPaged(string spotifyId, int pageSize, int page)
        {
            var spotify = _spotifyClientBuilder.BuildClient();
            var albums = await spotify.Artists.GetAlbums(spotifyId, new ArtistsAlbumsRequest
            {
                IncludeGroupsParam = ArtistsAlbumsRequest.IncludeGroups.Album,
                Market = "US",
                Limit = pageSize,
                Offset = (page-1) * pageSize
            });

            var albumList = new List<AlbumModel>();
            albumList.AddRange(albums.Items.Select(a => new AlbumModel
            {
                SpotifyId = a.Id,
                Name = a.Name,
                CoverUrl = a.Images[0].Url,
                ReleaseDate = a.ReleaseDate
            }));

            return new PagedResultSet<AlbumModel>(albumList, page, pageSize, albums.Total.Value);
        }

        public async Task<ArtistDetailsModel> GetArtistDetails(string spotifyId)
        {
            var spotify = _spotifyClientBuilder.BuildClient();
            var artist = await spotify.Artists.Get(spotifyId);

            var artistWithGenres = await _genreRepository.GetSubgenresOfArtist(spotifyId);

            var fullArtist = new ArtistDetailsModel
            {
                SpotifyId = artist.Id,
                Name = artist.Name,
                ImageUrl = artist.Images[0].Url,
                Followers = artist.Followers.Total
            };
            fullArtist.Genres.AddRange(artistWithGenres.SubgenresOfArtist
                .Select(sa => new GenreModel { Id = sa.SubgenreId, Name = sa.Subgenre.Name }));

            return fullArtist;
        }

        public async Task<PagedResultSet<AlbumModel>> GetSinglesOfArtistPaged(string spotifyId, int pageSize, int page)
        {
            var spotify = _spotifyClientBuilder.BuildClient();
            var albums = await spotify.Artists.GetAlbums(spotifyId, new ArtistsAlbumsRequest
            {
                IncludeGroupsParam = ArtistsAlbumsRequest.IncludeGroups.Single,
                Market = "US",
                Limit = pageSize,
                Offset = (page-1) * pageSize
            });

            var albumList = new List<AlbumModel>();
            albumList.AddRange(albums.Items.Select(a => new AlbumModel
            {
                SpotifyId = a.Id,
                Name = a.Name,
                CoverUrl = a.Images[0].Url,
                ReleaseDate = a.ReleaseDate
            }));

            return new PagedResultSet<AlbumModel>(albumList, page, pageSize, albums.Total.Value);
        }
    }
}

