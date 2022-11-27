using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Data;
using SpotifyAPI.Web;

namespace Infrastructure.Services
{
	public class GenreService : IGenreService
	{
        private readonly IGenreRepository _genreRepository;
        private readonly SpotifyClientBuilder _spotifyClientBuilder;

        public GenreService(IGenreRepository genreRepository, SpotifyClientBuilder spotifyClientBuilder)
		{
            _genreRepository = genreRepository;
            _spotifyClientBuilder = spotifyClientBuilder;
        }

        public async Task<List<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenres();
            var genresList = new List<GenreModel>();
            genresList.AddRange(genres.Select(g => new GenreModel { Id = g.Id, Name = g.Name, Icon = g.Icon }));
            return genresList;
        }

        public async Task<PagedResultSet<ArtistModel>> GetArtistsOfGenrePaged(int genreId, int pageSize, int page)
        {
            var artists = await _genreRepository.GetArtistsOfGenrePaged(genreId, pageSize, page);

            var spotify = _spotifyClientBuilder.BuildClient();
            List<string> artistIds = new List<string>();
            artistIds.AddRange(artists.Data.Select(a => a.SpotifyId));
            var fullArtists = await spotify.Artists.GetSeveral(new ArtistsRequest(artistIds));

            var artistsList = new List<ArtistModel>();
            artistsList.AddRange(fullArtists.Artists.Select(a => new ArtistModel
            {
                SpotifyId = a.Id,
                Name = a.Name,
                ImageUrl = a.Images[0].Url
            }));

            return new PagedResultSet<ArtistModel>(artistsList, page, pageSize, artists.TotalRowCount);
        }

        public async Task<PagedResultSet<ArtistModel>> GetArtistsOfSubgenrePaged(int subgenreId, int pageSize, int page)
        {
            var artists = await _genreRepository.GetArtistsOfSubgenrePaged(subgenreId, pageSize, page);

            var spotify = _spotifyClientBuilder.BuildClient();
            List<string> artistIds = new List<string>();
            artistIds.AddRange(artists.Data.Select(a => a.SpotifyId));
            var fullArtists = await spotify.Artists.GetSeveral(new ArtistsRequest(artistIds));

            var artistsList = new List<ArtistModel>();
            artistsList.AddRange(fullArtists.Artists.Select(a => new ArtistModel
            {
                SpotifyId = a.Id,
                Name = a.Name,
                ImageUrl = a.Images[0].Url
            }));

            return new PagedResultSet<ArtistModel>(artistsList, page, pageSize, artists.TotalRowCount);
        }

        public async Task<GenreDetailsModel> GetGenreDetails(int genreId)
        {
            var genre = await _genreRepository.GetById(genreId);
            var genreDetails = new GenreDetailsModel {
                Id = genre.Id,
                Name = genre.Name,
                Icon = genre.Icon,
                Overview = genre.Overview,
                ExternalUrl = genre.ExternalUrl
            };
            genreDetails.Subgenres.AddRange(genre.SubgenresOfGenre.Select(s => new SubgenreModel { Id = s.Id, Name = s.Name, ParentId = s.ParentGenreId }));
            return genreDetails;
        }

        public async Task<List<GenreModel>> GetSubgenresOfGenre(int genreId)
        {
            var subgenres = await _genreRepository.GetSubgenresOfGenre(genreId);
            var subgenresList = new List<GenreModel>();
            subgenresList.AddRange(subgenres.Select(s => new GenreModel { Id = s.Id, Name = s.Name }));
            return subgenresList;
        }
    }
}

