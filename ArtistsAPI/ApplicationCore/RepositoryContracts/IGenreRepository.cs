using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.RepositoryContracts
{
	public interface IGenreRepository
	{
        Task<Genre> GetById(int genreId);
        Task<List<Genre>> GetAllGenres();
        Task<PagedResultSet<Artist>> GetArtistsOfGenrePaged(int genreId, int pageSize, int page);
        Task<List<Subgenre>> GetSubgenresOfGenre(int genreId);
        Task<PagedResultSet<Artist>> GetArtistsOfSubgenrePaged(int subgenreId, int pageSize, int page);
        Task<Artist> GetSubgenresOfArtist(string spotifyId);
    }
}

