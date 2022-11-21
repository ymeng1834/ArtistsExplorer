using System;
namespace ApplicationCore.Entities
{
	public class SubgenreArtist
	{
        public int SubgenreId { get; set; }
        public int ArtistId { get; set; }

        public Subgenre Subgenre { get; set; }
        public Artist Artist { get; set; }

        public SubgenreArtist()
		{
		}
	}
}

