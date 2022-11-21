using System;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceContracts
{
	public interface IGenreService
	{
        Task<List<GenreModel>> GetAllGenres();
        Task<GenreDetailsModel> GetGenreDetails(int genreId);
        Task<PagedResultSet<ArtistModel>> GetArtistsOfGenrePaged(int genreId, int pageSize, int page);
        Task<List<GenreModel>> GetSubgenresOfGenre(int genreId);
        Task<PagedResultSet<ArtistModel>> GetArtistsOfSubgenrePaged(int subgenreId, int pageSize, int page);
    }
}

