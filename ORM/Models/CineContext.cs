using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ORM.Models;

public partial class CineContext : DbContext
{
    public CineContext()
    {
    }

    public CineContext(DbContextOptions<CineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actore> Actores { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<Cine> Cines { get; set; }

    public virtual DbSet<Critico> Criticos { get; set; }

    public virtual DbSet<Directore> Directores { get; set; }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<Festivale> Festivales { get; set; }

    public virtual DbSet<Funcione> Funciones { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaActor> PeliculaActors { get; set; }

    public virtual DbSet<PeliculaFestival> PeliculaFestivals { get; set; }

    public virtual DbSet<PeliculaPremio> PeliculaPremios { get; set; }

    public virtual DbSet<Premio> Premios { get; set; }

    public virtual DbSet<Productore> Productores { get; set; }

    public virtual DbSet<Publicidad> Publicidads { get; set; }

    public virtual DbSet<Resena> Resenas { get; set; }

    public virtual DbSet<ResenasCritico> ResenasCriticos { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Trailer> Trailers { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=cine;user=root;password=", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Actore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("actores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("boletos");

            entity.HasIndex(e => e.FuncionId, "funcion_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Asiento)
                .HasMaxLength(10)
                .HasColumnName("asiento");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.FuncionId).HasColumnName("funcion_id");
            entity.Property(e => e.Precio)
                .HasPrecision(8, 2)
                .HasColumnName("precio");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Funcion).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.FuncionId)
                .HasConstraintName("boletos_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("boletos_ibfk_2");
        });

        modelBuilder.Entity<Cine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cines");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Critico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("criticos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Afiliacion)
                .HasMaxLength(255)
                .HasColumnName("afiliacion");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Directore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("directores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnioFundacion)
                .HasColumnType("year")
                .HasColumnName("anio_fundacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Festivale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("festivales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Funcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funciones");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.HasIndex(e => e.SalaId, "sala_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.SalaId).HasColumnName("sala_id");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("funciones_ibfk_1");

            entity.HasOne(d => d.Sala).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.SalaId)
                .HasConstraintName("funciones_ibfk_2");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("generos");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("peliculas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.FechaLanzamiento).HasColumnName("fecha_lanzamiento");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .HasColumnName("idioma");
            entity.Property(e => e.Rating)
                .HasPrecision(3, 1)
                .HasDefaultValueSql("'0.0'")
                .HasColumnName("rating");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");

            entity.HasMany(d => d.Directors).WithMany(p => p.Peliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "PeliculaDirector",
                    r => r.HasOne<Directore>().WithMany()
                        .HasForeignKey("DirectorId")
                        .HasConstraintName("pelicula_director_ibfk_2"),
                    l => l.HasOne<Pelicula>().WithMany()
                        .HasForeignKey("PeliculaId")
                        .HasConstraintName("pelicula_director_ibfk_1"),
                    j =>
                    {
                        j.HasKey("PeliculaId", "DirectorId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("pelicula_director");
                        j.HasIndex(new[] { "DirectorId" }, "director_id");
                        j.IndexerProperty<int>("PeliculaId").HasColumnName("pelicula_id");
                        j.IndexerProperty<int>("DirectorId").HasColumnName("director_id");
                    });

            entity.HasMany(d => d.Estudios).WithMany(p => p.Peliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "PeliculaEstudio",
                    r => r.HasOne<Estudio>().WithMany()
                        .HasForeignKey("EstudioId")
                        .HasConstraintName("pelicula_estudio_ibfk_2"),
                    l => l.HasOne<Pelicula>().WithMany()
                        .HasForeignKey("PeliculaId")
                        .HasConstraintName("pelicula_estudio_ibfk_1"),
                    j =>
                    {
                        j.HasKey("PeliculaId", "EstudioId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("pelicula_estudio");
                        j.HasIndex(new[] { "EstudioId" }, "estudio_id");
                        j.IndexerProperty<int>("PeliculaId").HasColumnName("pelicula_id");
                        j.IndexerProperty<int>("EstudioId").HasColumnName("estudio_id");
                    });

            entity.HasMany(d => d.Generos).WithMany(p => p.Peliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "PeliculaGenero",
                    r => r.HasOne<Genero>().WithMany()
                        .HasForeignKey("GeneroId")
                        .HasConstraintName("pelicula_genero_ibfk_2"),
                    l => l.HasOne<Pelicula>().WithMany()
                        .HasForeignKey("PeliculaId")
                        .HasConstraintName("pelicula_genero_ibfk_1"),
                    j =>
                    {
                        j.HasKey("PeliculaId", "GeneroId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("pelicula_genero");
                        j.HasIndex(new[] { "GeneroId" }, "genero_id");
                        j.IndexerProperty<int>("PeliculaId").HasColumnName("pelicula_id");
                        j.IndexerProperty<int>("GeneroId").HasColumnName("genero_id");
                    });

            entity.HasMany(d => d.Productors).WithMany(p => p.Peliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "PeliculaProductor",
                    r => r.HasOne<Productore>().WithMany()
                        .HasForeignKey("ProductorId")
                        .HasConstraintName("pelicula_productor_ibfk_2"),
                    l => l.HasOne<Pelicula>().WithMany()
                        .HasForeignKey("PeliculaId")
                        .HasConstraintName("pelicula_productor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("PeliculaId", "ProductorId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("pelicula_productor");
                        j.HasIndex(new[] { "ProductorId" }, "productor_id");
                        j.IndexerProperty<int>("PeliculaId").HasColumnName("pelicula_id");
                        j.IndexerProperty<int>("ProductorId").HasColumnName("productor_id");
                    });
        });

        modelBuilder.Entity<PeliculaActor>(entity =>
        {
            entity.HasKey(e => new { e.PeliculaId, e.ActorId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pelicula_actor");

            entity.HasIndex(e => e.ActorId, "actor_id");

            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Personaje)
                .HasMaxLength(100)
                .HasColumnName("personaje");

            entity.HasOne(d => d.Actor).WithMany(p => p.PeliculaActors)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("pelicula_actor_ibfk_2");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.PeliculaActors)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("pelicula_actor_ibfk_1");
        });

        modelBuilder.Entity<PeliculaFestival>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pelicula_festival");

            entity.HasIndex(e => e.FestivalId, "festival_id");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FestivalId).HasColumnName("festival_id");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.PremioGanado)
                .HasMaxLength(100)
                .HasColumnName("premio_ganado");
            entity.Property(e => e.ScreeningDate).HasColumnName("screening_date");

            entity.HasOne(d => d.Festival).WithMany(p => p.PeliculaFestivals)
                .HasForeignKey(d => d.FestivalId)
                .HasConstraintName("pelicula_festival_ibfk_2");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.PeliculaFestivals)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("pelicula_festival_ibfk_1");
        });

        modelBuilder.Entity<PeliculaPremio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pelicula_premio");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.HasIndex(e => e.PremioId, "premio_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .HasColumnName("categoria");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.PremioId).HasColumnName("premio_id");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.PeliculaPremios)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("pelicula_premio_ibfk_1");

            entity.HasOne(d => d.Premio).WithMany(p => p.PeliculaPremios)
                .HasForeignKey(d => d.PremioId)
                .HasConstraintName("pelicula_premio_ibfk_2");
        });

        modelBuilder.Entity<Premio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("premios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Productore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Publicidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publicidad");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Campaña)
                .HasMaxLength(255)
                .HasColumnName("campaña");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.Presupuesto)
                .HasPrecision(10, 2)
                .HasColumnName("presupuesto");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.Publicidads)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("publicidad_ibfk_1");
        });

        modelBuilder.Entity<Resena>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("resenas");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasColumnType("text")
                .HasColumnName("comentario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("resenas_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("resenas_ibfk_2");
        });

        modelBuilder.Entity<ResenasCritico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("resenas_criticos");

            entity.HasIndex(e => e.CriticoId, "critico_id");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasColumnType("text")
                .HasColumnName("comentario");
            entity.Property(e => e.CriticoId).HasColumnName("critico_id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Critico).WithMany(p => p.ResenasCriticos)
                .HasForeignKey(d => d.CriticoId)
                .HasConstraintName("resenas_criticos_ibfk_2");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.ResenasCriticos)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("resenas_criticos_ibfk_1");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("salas");

            entity.HasIndex(e => e.CineId, "cine_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.CineId).HasColumnName("cine_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Cine).WithMany(p => p.Salas)
                .HasForeignKey(d => d.CineId)
                .HasConstraintName("salas_ibfk_1");
        });

        modelBuilder.Entity<Trailer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trailers");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calidad)
                .HasMaxLength(50)
                .HasColumnName("calidad");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .HasColumnName("idioma");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.Trailers)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("trailers_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
