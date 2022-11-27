using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
	public class GenreDetailsModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Overview { get; set; }
		public string ExternalUrl { get; set; }
		
		public List<SubgenreModel> Subgenres { get; set; }

		public GenreDetailsModel()
		{
			Subgenres = new List<SubgenreModel>();
		}
	}
}

