using System;
namespace ApplicationCore.Entities
{
	public class Subgenre
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ParentGenreId { get; set; }

		public Genre ParentGenre { get; set; }
		public ICollection<SubgenreArtist> ArtistsOfSubgenre { get; set; }

		public Subgenre()
		{
		}
	}
}

