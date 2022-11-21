﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ArtistsDbContext))]
    [Migration("20221118045457_UpdateSubgenre")]
    partial class UpdateSubgenre
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.Property<string>("SpotifyId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Popularity");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ApplicationCore.Entities.GenreArtist", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("GenreArtists", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Entities.Subgenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("ParentGenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentGenreId");

                    b.ToTable("Subgenres");
                });

            modelBuilder.Entity("ApplicationCore.Entities.SubgenreArtist", b =>
                {
                    b.Property<int>("SubgenreId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("SubgenreId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("SubgenreArtists", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.Entities.GenreArtist", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Artist", "Artist")
                        .WithMany("GenresOfArtist")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Genre", "Genre")
                        .WithMany("ArtistsOfGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Subgenre", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Genre", "ParentGenre")
                        .WithMany("SubgenresOfGenre")
                        .HasForeignKey("ParentGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentGenre");
                });

            modelBuilder.Entity("ApplicationCore.Entities.SubgenreArtist", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Artist", "Artist")
                        .WithMany("SubgenresOfArtist")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Subgenre", "Subgenre")
                        .WithMany("ArtistsOfSubgenre")
                        .HasForeignKey("SubgenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Subgenre");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Artist", b =>
                {
                    b.Navigation("GenresOfArtist");

                    b.Navigation("SubgenresOfArtist");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Genre", b =>
                {
                    b.Navigation("ArtistsOfGenre");

                    b.Navigation("SubgenresOfGenre");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Subgenre", b =>
                {
                    b.Navigation("ArtistsOfSubgenre");
                });
#pragma warning restore 612, 618
        }
    }
}
