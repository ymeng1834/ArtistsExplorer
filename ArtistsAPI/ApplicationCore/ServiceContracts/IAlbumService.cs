using System;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceContracts
{
	public interface IAlbumService
	{
		Task<AlbumDetailsModel> GetAlbumDetails(string id);
	}
}

