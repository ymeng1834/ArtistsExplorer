using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
	public class ArtistsDbContext : DbContext
	{
		public ArtistsDbContext(DbContextOptions<ArtistsDbContext> options) : base(options)
		{
		}

		public DbSet<Artist> Artists { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Subgenre> Subgenres { get; set; }
		public DbSet<GenreArtist> GenreArtists { get; set; }
		public DbSet<SubgenreArtist> SubgenreArtists { get; set; }

		private void ConfigureArtist(EntityTypeBuilder<Artist> builder)
		{
			builder.Property(m => m.SpotifyId).HasMaxLength(32);
			builder.HasIndex(m => m.Popularity);
		}

		private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
		{
			builder.Property(g => g.Name).HasMaxLength(32);
		}

		private void ConfigureSubgenre(EntityTypeBuilder<Subgenre> builder)
		{
			builder.Property(s => s.Name).HasMaxLength(64);
		}

		private void ConfigureGenreArtist(EntityTypeBuilder<GenreArtist> builder)
		{
			builder.ToTable("GenreArtists"); 
			builder.HasKey(ga => new { ga.GenreId, ga.ArtistId }); 
		}

		private void ConfigureSubgenreArtist(EntityTypeBuilder<SubgenreArtist> builder)
		{
			builder.ToTable("SubgenreArtists");
			builder.HasKey(sa => new { sa.SubgenreId, sa.ArtistId });
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Artist>(ConfigureArtist);
			modelBuilder.Entity<Genre>(ConfigureGenre);
			modelBuilder.Entity<Subgenre>(ConfigureSubgenre);
			modelBuilder.Entity<GenreArtist>(ConfigureGenreArtist);
			modelBuilder.Entity<SubgenreArtist>(ConfigureSubgenreArtist);
		}


	}
}

