using System;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceContracts
{
	public interface IArtistService
	{
		Task<ArtistDetailsModel> GetArtistDetails(string spotifyId);
		Task<PagedResultSet<AlbumModel>> GetAlbumsOfArtistPaged(string spotifyId, int pageSize, int page);
        Task<PagedResultSet<AlbumModel>> GetSinglesOfArtistPaged(string spotifyId, int pageSize, int page);
    }
}

