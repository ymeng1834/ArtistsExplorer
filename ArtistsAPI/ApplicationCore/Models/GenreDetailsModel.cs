using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
	public class GenreDetailsModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<GenreModel> Subgenres { get; set; }

		public GenreDetailsModel()
		{
			Subgenres = new List<GenreModel>();
		}
	}
}

