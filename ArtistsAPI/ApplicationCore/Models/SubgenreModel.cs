using System;
namespace ApplicationCore.Models
{
	public class SubgenreModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ParentId { get; set; }

		public SubgenreModel()
		{
		}
	}
}

