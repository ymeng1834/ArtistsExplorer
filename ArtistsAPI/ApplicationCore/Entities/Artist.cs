using System;
namespace ApplicationCore.Entities
{
	public class Artist
	{
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public int Popularity { get; set; }

        public ICollection<GenreArtist> GenresOfArtist { get; set; }
        public ICollection<SubgenreArtist> SubgenresOfArtist { get; set; }

        public Artist()
		{
		}
	}
}

