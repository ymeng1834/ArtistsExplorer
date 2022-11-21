using System;
namespace ApplicationCore.Models
{
	public class AlbumDetailsModel
	{
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string CoverUrl { get; set; }
        public List<ArtistModel> Artists { get; set; }
        public string ReleaseDate { get; set; }
        public string Type { get; set; }
        public int NumOfTracks { get; set; }
        public int Popoularity { get; set; }

        public AlbumDetailsModel()
        {
            Artists = new List<ArtistModel>();
        }
    }
}

