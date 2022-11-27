using System;
namespace ApplicationCore.Entities
{
	public class Genre
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Icon { get; set; }
		public string Overview { get; set; }
		public string ExternalUrl { get; set; }

        public ICollection<Subgenre> SubgenresOfGenre { get; set; }
		public ICollection<GenreArtist> ArtistsOfGenre { get; set; }

        public Genre()
		{
		}
	}
}

