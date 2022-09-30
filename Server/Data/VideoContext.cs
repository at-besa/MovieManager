using Microsoft.EntityFrameworkCore;
using MovieManager.Shared.Models;
using Version = MovieManager.Shared.Models.Version;

namespace MovieManager.Server.Data
{
    public partial class VideoContext : DbContext
    {
        public VideoContext()
        {
        }

        public VideoContext(DbContextOptions<VideoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<ActorLink> ActorLink { get; set; }
        public virtual DbSet<Art> Art { get; set; }
        public virtual DbSet<Bookmark> Bookmark { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryLink> CountryLink { get; set; }
        public virtual DbSet<DirectorLink> DirectorLink { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }
        public virtual DbSet<EpisodeView> EpisodeView { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<GenreLink> GenreLink { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieView> MovieView { get; set; }
        public virtual DbSet<Movielinktvshow> Movielinktvshow { get; set; }
        public virtual DbSet<Musicvideo> Musicvideo { get; set; }
        public virtual DbSet<MusicvideoView> MusicvideoView { get; set; }
        public virtual DbSet<Path> Path { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<SeasonView> SeasonView { get; set; }
        public virtual DbSet<Seasons> Seasons { get; set; }
        public virtual DbSet<Sets> Sets { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Stacktimes> Stacktimes { get; set; }
        public virtual DbSet<Streamdetails> Streamdetails { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<StudioLink> StudioLink { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagLink> TagLink { get; set; }
        public virtual DbSet<Tvshow> Tvshow { get; set; }
        public virtual DbSet<TvshowView> TvshowView { get; set; }
        public virtual DbSet<Tvshowcounts> Tvshowcounts { get; set; }
        public virtual DbSet<Tvshowlinkpath> Tvshowlinkpath { get; set; }
        public virtual DbSet<TvshowlinkpathMinview> TvshowlinkpathMinview { get; set; }
        public virtual DbSet<Uniqueid> Uniqueid { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<WriterLink> WriterLink { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_actor_1")
                    .IsUnique();

                entity.Property(e => e.ActorId)
                    .HasColumnName("actor_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtUrls)
                    .HasColumnName("art_urls")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ActorLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("actor_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_actor_link_3");

                entity.HasIndex(e => new { e.ActorId, e.MediaType, e.MediaId })
                    .HasName("ix_actor_link_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.ActorId })
                    .HasName("ix_actor_link_2")
                    .IsUnique();

                entity.Property(e => e.ActorId)
                    .HasColumnName("actor_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CastOrder)
                    .HasColumnName("cast_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Art>(entity =>
            {
                entity.ToTable("art");

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.Type })
                    .HasName("ix_art");

                entity.Property(e => e.ArtId)
                    .HasColumnName("art_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.HasKey(e => e.IdBookmark)
                    .HasName("PRIMARY");

                entity.ToTable("bookmark");

                entity.HasIndex(e => new { e.IdFile, e.Type })
                    .HasName("ix_bookmark");

                entity.Property(e => e.IdBookmark)
                    .HasColumnName("idBookmark")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Player)
                    .HasColumnName("player")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlayerState)
                    .HasColumnName("playerState")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ThumbNailImage)
                    .HasColumnName("thumbNailImage")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TimeInSeconds).HasColumnName("timeInSeconds");

                entity.Property(e => e.TotalTimeInSeconds).HasColumnName("totalTimeInSeconds");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_country_1")
                    .IsUnique();

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CountryLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("country_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_country_link_3");

                entity.HasIndex(e => new { e.CountryId, e.MediaType, e.MediaId })
                    .HasName("ix_country_link_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.CountryId })
                    .HasName("ix_country_link_2")
                    .IsUnique();

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DirectorLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("director_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_director_link_3");

                entity.HasIndex(e => new { e.ActorId, e.MediaType, e.MediaId })
                    .HasName("ix_director_link_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.ActorId })
                    .HasName("ix_director_link_2")
                    .IsUnique();

                entity.Property(e => e.ActorId)
                    .HasColumnName("actor_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.HasKey(e => e.IdEpisode)
                    .HasName("PRIMARY");

                entity.ToTable("episode");

                entity.HasIndex(e => e.C17)
                    .HasName("ix_episode_bookmark");

                entity.HasIndex(e => e.C19)
                    .HasName("ixEpisodeBasePath");

                entity.HasIndex(e => new { e.C12, e.C13 })
                    .HasName("ix_episode_season_episode");

                entity.HasIndex(e => new { e.IdEpisode, e.IdFile })
                    .HasName("ix_episode_file_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdEpisode, e.IdShow })
                    .HasName("ix_episode_show1");

                entity.HasIndex(e => new { e.IdFile, e.IdEpisode })
                    .HasName("id_episode_file_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdShow, e.IdEpisode })
                    .HasName("ix_episode_show2");

                entity.Property(e => e.IdEpisode)
                    .HasColumnName("idEpisode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSeason)
                    .HasColumnName("idSeason")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<EpisodeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("episode_view");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("varchar(24)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdEpisode)
                    .HasColumnName("idEpisode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSeason)
                    .HasColumnName("idSeason")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastPlayed)
                    .HasColumnName("lastPlayed")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mpaa)
                    .HasColumnName("mpaa")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlayCount)
                    .HasColumnName("playCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PlayerState)
                    .HasColumnName("playerState")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Premiered)
                    .HasColumnName("premiered")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingType)
                    .HasColumnName("rating_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResumeTimeInSeconds).HasColumnName("resumeTimeInSeconds");

                entity.Property(e => e.StrFileName)
                    .HasColumnName("strFileName")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrPath)
                    .HasColumnName("strPath")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrTitle)
                    .HasColumnName("strTitle")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Studio)
                    .HasColumnName("studio")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalTimeInSeconds).HasColumnName("totalTimeInSeconds");

                entity.Property(e => e.UniqueidType)
                    .HasColumnName("uniqueid_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UniqueidValue)
                    .HasColumnName("uniqueid_value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Votes)
                    .HasColumnName("votes")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PRIMARY");

                entity.ToTable("files");

                entity.HasIndex(e => new { e.IdPath, e.StrFilename })
                    .HasName("ix_files");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdPath)
                    .HasColumnName("idPath")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastPlayed)
                    .HasColumnName("lastPlayed")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlayCount)
                    .HasColumnName("playCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrFilename)
                    .HasColumnName("strFilename")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_genre_1")
                    .IsUnique();

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<GenreLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("genre_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_genre_link_3");

                entity.HasIndex(e => new { e.GenreId, e.MediaType, e.MediaId })
                    .HasName("ix_genre_link_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.GenreId })
                    .HasName("ix_genre_link_2")
                    .IsUnique();

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie)
                    .HasName("PRIMARY");

                entity.ToTable("movie");

                entity.HasIndex(e => e.C23)
                    .HasName("ixMovieBasePath");

                entity.HasIndex(e => new { e.IdFile, e.IdMovie })
                    .HasName("ix_movie_file_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdMovie, e.IdFile })
                    .HasName("ix_movie_file_2")
                    .IsUnique();

                entity.Property(e => e.IdMovie)
                    .HasColumnName("idMovie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSet)
                    .HasColumnName("idSet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Premiered)
                    .HasColumnName("premiered")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MovieView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("movie_view");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMovie)
                    .HasColumnName("idMovie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSet)
                    .HasColumnName("idSet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastPlayed)
                    .HasColumnName("lastPlayed")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlayCount)
                    .HasColumnName("playCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PlayerState)
                    .HasColumnName("playerState")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Premiered)
                    .HasColumnName("premiered")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingType)
                    .HasColumnName("rating_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResumeTimeInSeconds).HasColumnName("resumeTimeInSeconds");

                entity.Property(e => e.StrFileName)
                    .HasColumnName("strFileName")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrPath)
                    .HasColumnName("strPath")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrSet)
                    .HasColumnName("strSet")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrSetOverview)
                    .HasColumnName("strSetOverview")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalTimeInSeconds).HasColumnName("totalTimeInSeconds");

                entity.Property(e => e.UniqueidType)
                    .HasColumnName("uniqueid_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UniqueidValue)
                    .HasColumnName("uniqueid_value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Votes)
                    .HasColumnName("votes")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Movielinktvshow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movielinktvshow");

                entity.HasIndex(e => new { e.IdMovie, e.IdShow })
                    .HasName("ix_movielinktvshow_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdShow, e.IdMovie })
                    .HasName("ix_movielinktvshow_1")
                    .IsUnique();

                entity.Property(e => e.IdMovie)
                    .HasColumnName("idMovie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Musicvideo>(entity =>
            {
                entity.HasKey(e => e.IdMvideo)
                    .HasName("PRIMARY");

                entity.ToTable("musicvideo");

                entity.HasIndex(e => e.C14)
                    .HasName("ixMusicVideoBasePath");

                entity.HasIndex(e => new { e.IdFile, e.IdMvideo })
                    .HasName("ix_musicvideo_file_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdMvideo, e.IdFile })
                    .HasName("ix_musicvideo_file_1")
                    .IsUnique();

                entity.Property(e => e.IdMvideo)
                    .HasColumnName("idMVideo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Premiered)
                    .HasColumnName("premiered")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MusicvideoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("musicvideo_view");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMvideo)
                    .HasColumnName("idMVideo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastPlayed)
                    .HasColumnName("lastPlayed")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlayCount)
                    .HasColumnName("playCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PlayerState)
                    .HasColumnName("playerState")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Premiered)
                    .HasColumnName("premiered")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResumeTimeInSeconds).HasColumnName("resumeTimeInSeconds");

                entity.Property(e => e.StrFileName)
                    .HasColumnName("strFileName")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrPath)
                    .HasColumnName("strPath")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalTimeInSeconds).HasColumnName("totalTimeInSeconds");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Path>(entity =>
            {
                entity.HasKey(e => e.IdPath)
                    .HasName("PRIMARY");

                entity.ToTable("path");

                entity.HasIndex(e => e.IdParentPath)
                    .HasName("ix_path2");

                entity.HasIndex(e => e.StrPath)
                    .HasName("ix_path");

                entity.Property(e => e.IdPath)
                    .HasColumnName("idPath")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Exclude).HasColumnName("exclude");

                entity.Property(e => e.IdParentPath)
                    .HasColumnName("idParentPath")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NoUpdate).HasColumnName("noUpdate");

                entity.Property(e => e.ScanRecursive)
                    .HasColumnName("scanRecursive")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrContent)
                    .HasColumnName("strContent")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrHash)
                    .HasColumnName("strHash")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrPath)
                    .HasColumnName("strPath")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrScraper)
                    .HasColumnName("strScraper")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrSettings)
                    .HasColumnName("strSettings")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UseFolderNames).HasColumnName("useFolderNames");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.HasIndex(e => new { e.MediaId, e.MediaType })
                    .HasName("ix_rating");

                entity.Property(e => e.RatingId)
                    .HasColumnName("rating_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rating1).HasColumnName("rating");

                entity.Property(e => e.RatingType)
                    .HasColumnName("rating_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Votes)
                    .HasColumnName("votes")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SeasonView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("season_view");

                entity.Property(e => e.Aired)
                    .HasColumnName("aired")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Episodes)
                    .HasColumnName("episodes")
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdSeason)
                    .HasColumnName("idSeason")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mpaa)
                    .HasColumnName("mpaa")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlayCount)
                    .HasColumnName("playCount")
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.Plot)
                    .HasColumnName("plot")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Premiered)
                    .HasColumnName("premiered")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Season)
                    .HasColumnName("season")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShowTitle)
                    .HasColumnName("showTitle")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrPath)
                    .HasColumnName("strPath")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Studio)
                    .HasColumnName("studio")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Seasons>(entity =>
            {
                entity.HasKey(e => e.IdSeason)
                    .HasName("PRIMARY");

                entity.ToTable("seasons");

                entity.HasIndex(e => new { e.IdShow, e.Season })
                    .HasName("ix_seasons");

                entity.Property(e => e.IdSeason)
                    .HasColumnName("idSeason")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Season)
                    .HasColumnName("season")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Sets>(entity =>
            {
                entity.HasKey(e => e.IdSet)
                    .HasName("PRIMARY");

                entity.ToTable("sets");

                entity.Property(e => e.IdSet)
                    .HasColumnName("idSet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrOverview)
                    .HasColumnName("strOverview")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrSet)
                    .HasColumnName("strSet")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("settings");

                entity.HasIndex(e => e.IdFile)
                    .HasName("ix_settings")
                    .IsUnique();

                entity.Property(e => e.AudioStream).HasColumnType("int(11)");

                entity.Property(e => e.CenterMixLevel).HasColumnType("int(11)");

                entity.Property(e => e.DeinterlaceMode).HasColumnType("int(11)");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Orientation).HasColumnType("int(11)");

                entity.Property(e => e.ResumeTime).HasColumnType("int(11)");

                entity.Property(e => e.ScalingMethod).HasColumnType("int(11)");

                entity.Property(e => e.StereoMode).HasColumnType("int(11)");

                entity.Property(e => e.SubtitleStream).HasColumnType("int(11)");

                entity.Property(e => e.TonemapMethod).HasColumnType("int(11)");

                entity.Property(e => e.VideoStream).HasColumnType("int(11)");

                entity.Property(e => e.ViewMode).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Stacktimes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stacktimes");

                entity.HasIndex(e => e.IdFile)
                    .HasName("ix_stacktimes")
                    .IsUnique();

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Times)
                    .HasColumnName("times")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Streamdetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("streamdetails");

                entity.HasIndex(e => e.IdFile)
                    .HasName("ix_streamdetails");

                entity.Property(e => e.FVideoAspect).HasColumnName("fVideoAspect");

                entity.Property(e => e.IAudioChannels)
                    .HasColumnName("iAudioChannels")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IStreamType)
                    .HasColumnName("iStreamType")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IVideoDuration)
                    .HasColumnName("iVideoDuration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IVideoHeight)
                    .HasColumnName("iVideoHeight")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IVideoWidth)
                    .HasColumnName("iVideoWidth")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrAudioCodec)
                    .HasColumnName("strAudioCodec")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrAudioLanguage)
                    .HasColumnName("strAudioLanguage")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrStereoMode)
                    .HasColumnName("strStereoMode")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrSubtitleLanguage)
                    .HasColumnName("strSubtitleLanguage")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrVideoCodec)
                    .HasColumnName("strVideoCodec")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrVideoLanguage)
                    .HasColumnName("strVideoLanguage")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.ToTable("studio");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_studio_1")
                    .IsUnique();

                entity.Property(e => e.StudioId)
                    .HasColumnName("studio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<StudioLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("studio_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_studio_link_3");

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.StudioId })
                    .HasName("ix_studio_link_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.StudioId, e.MediaType, e.MediaId })
                    .HasName("ix_studio_link_1")
                    .IsUnique();

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StudioId)
                    .HasColumnName("studio_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.HasIndex(e => e.Name)
                    .HasName("ix_tag_1")
                    .IsUnique();

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TagLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tag_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_tag_link_3");

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.TagId })
                    .HasName("ix_tag_link_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.TagId, e.MediaType, e.MediaId })
                    .HasName("ix_tag_link_1")
                    .IsUnique();

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tvshow>(entity =>
            {
                entity.HasKey(e => e.IdShow)
                    .HasName("PRIMARY");

                entity.ToTable("tvshow");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TvshowView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tvshow_view");

                entity.Property(e => e.C00)
                    .HasColumnName("c00")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C01)
                    .HasColumnName("c01")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C02)
                    .HasColumnName("c02")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C03)
                    .HasColumnName("c03")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C04)
                    .HasColumnName("c04")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C05)
                    .HasColumnName("c05")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C06)
                    .HasColumnName("c06")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C07)
                    .HasColumnName("c07")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C08)
                    .HasColumnName("c08")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C09)
                    .HasColumnName("c09")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C10)
                    .HasColumnName("c10")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C11)
                    .HasColumnName("c11")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C12)
                    .HasColumnName("c12")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C13)
                    .HasColumnName("c13")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C14)
                    .HasColumnName("c14")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C15)
                    .HasColumnName("c15")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C16)
                    .HasColumnName("c16")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C17)
                    .HasColumnName("c17")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C18)
                    .HasColumnName("c18")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C19)
                    .HasColumnName("c19")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C20)
                    .HasColumnName("c20")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C21)
                    .HasColumnName("c21")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C22)
                    .HasColumnName("c22")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.C23)
                    .HasColumnName("c23")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdParentPath)
                    .HasColumnName("idParentPath")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastPlayed)
                    .HasColumnName("lastPlayed")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingType)
                    .HasColumnName("rating_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StrPath)
                    .HasColumnName("strPath")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalCount)
                    .HasColumnName("totalCount")
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.TotalSeasons)
                    .HasColumnName("totalSeasons")
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.UniqueidType)
                    .HasColumnName("uniqueid_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UniqueidValue)
                    .HasColumnName("uniqueid_value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userrating)
                    .HasColumnName("userrating")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Votes)
                    .HasColumnName("votes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Watchedcount)
                    .HasColumnName("watchedcount")
                    .HasColumnType("bigint(21)");
            });

            modelBuilder.Entity<Tvshowcounts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tvshowcounts");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastPlayed)
                    .HasColumnName("lastPlayed")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalCount)
                    .HasColumnName("totalCount")
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.TotalSeasons)
                    .HasColumnName("totalSeasons")
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.Watchedcount)
                    .HasColumnName("watchedcount")
                    .HasColumnType("bigint(21)");
            });

            modelBuilder.Entity<Tvshowlinkpath>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tvshowlinkpath");

                entity.HasIndex(e => new { e.IdPath, e.IdShow })
                    .HasName("ix_tvshowlinkpath_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdShow, e.IdPath })
                    .HasName("ix_tvshowlinkpath_1")
                    .IsUnique();

                entity.Property(e => e.IdPath)
                    .HasColumnName("idPath")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TvshowlinkpathMinview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tvshowlinkpath_minview");

                entity.Property(e => e.IdPath)
                    .HasColumnName("idPath")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdShow)
                    .HasColumnName("idShow")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Uniqueid>(entity =>
            {
                entity.ToTable("uniqueid");

                entity.HasIndex(e => new { e.MediaType, e.Value })
                    .HasName("ix_uniqueid2");

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.Type })
                    .HasName("ix_uniqueid1");

                entity.Property(e => e.UniqueidId)
                    .HasColumnName("uniqueid_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("version");

                entity.Property(e => e.ICompressCount)
                    .HasColumnName("iCompressCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVersion)
                    .HasColumnName("idVersion")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<WriterLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("writer_link");

                entity.HasIndex(e => e.MediaType)
                    .HasName("ix_writer_link_3");

                entity.HasIndex(e => new { e.ActorId, e.MediaType, e.MediaId })
                    .HasName("ix_writer_link_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MediaId, e.MediaType, e.ActorId })
                    .HasName("ix_writer_link_2")
                    .IsUnique();

                entity.Property(e => e.ActorId)
                    .HasColumnName("actor_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
