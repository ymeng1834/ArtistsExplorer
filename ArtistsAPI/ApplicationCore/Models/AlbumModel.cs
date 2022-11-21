using System;
namespace ApplicationCore.Models
{
	public class AlbumModel
	{
		public string SpotifyId { get; set; }
		public string Name { get; set; }
		public string CoverUrl { get; set; }
		public string ReleaseDate { get; set; }

		public AlbumModel()
		{
		}
	}
}

