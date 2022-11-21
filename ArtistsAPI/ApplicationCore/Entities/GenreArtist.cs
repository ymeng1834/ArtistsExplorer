using System;
namespace ApplicationCore.Entities
{
	public class GenreArtist
	{
        public int GenreId { get; set; }
        public int ArtistId { get; set; }

        public Genre Genre { get; set; }
        public Artist Artist { get; set; }

        public GenreArtist()
		{
		}
	}
}

