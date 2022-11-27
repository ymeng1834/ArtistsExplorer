using System;
namespace ApplicationCore.Models
{
	public class ArtistDetailsModel
	{
		public string SpotifyId { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public int Followers { get; set; }
		public List<SubgenreModel> Genres { get; set; }

		public ArtistDetailsModel()
		{
			Genres = new List<SubgenreModel>();
		}
	}
}

