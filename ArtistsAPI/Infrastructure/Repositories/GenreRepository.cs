using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ArtistsDbContext _artistsDbContext;

        public GenreRepository(ArtistsDbContext artistsDbContext)
        {
            _artistsDbContext = artistsDbContext;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            var genres = await _artistsDbContext.Genres.ToListAsync();
            return genres;
        }

        public async Task<PagedResultSet<Artist>> GetArtistsOfGenrePaged(int genreId, int pageSize, int page)
        {
            var totalCount = await _artistsDbContext.GenreArtists.Where(ga => ga.GenreId == genreId).CountAsync();
            var artists = await _artistsDbContext.GenreArtists.Where(ga => ga.GenreId == genreId)
                .Include(ga => ga.Artist).OrderByDescending(ga => ga.Artist.Popularity)
                .Select(ga => new Artist { Id = ga.ArtistId, SpotifyId = ga.Artist.SpotifyId})
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var pagedArtists = new PagedResultSet<Artist>(artists, page, pageSize, totalCount);
            return pagedArtists;
        }


        public async Task<PagedResultSet<Artist>> GetArtistsOfSubgenrePaged(int subgenreId, int pageSize, int page)
        {
            var totalCount = await _artistsDbContext.SubgenreArtists.Where(sa => sa.SubgenreId == subgenreId).CountAsync();
            var artists = await _artistsDbContext.SubgenreArtists.Where(sa => sa.SubgenreId == subgenreId)
                .Include(sa => sa.Artist).OrderByDescending(sa => sa.Artist.Popularity)
                .Select(sa => new Artist { Id = sa.ArtistId, SpotifyId = sa.Artist.SpotifyId })
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var pagedArtists = new PagedResultSet<Artist>(artists, page, pageSize, totalCount);
            return pagedArtists;
        }

        public async Task<Genre> GetById(int genreId)
        {
            var genre = await _artistsDbContext.Genres.Include(g => g.SubgenresOfGenre)
                .FirstOrDefaultAsync(g => g.Id == genreId);
            return genre;
        }

        public async Task<Artist> GetSubgenresOfArtist(string spotifyId)
        {
            var artistWithGenres = await _artistsDbContext.Artists.Include(a => a.SubgenresOfArtist)
                .ThenInclude(sa => sa.Subgenre)
                .FirstOrDefaultAsync(a => a.SpotifyId == spotifyId);
            return artistWithGenres;
        }

        public async Task<List<Subgenre>> GetSubgenresOfGenre(int genreId)
        {
            var subgenres = await _artistsDbContext.Subgenres.Where(s => s.ParentGenreId == genreId).ToListAsync();
            return subgenres;
        }
    }
}

