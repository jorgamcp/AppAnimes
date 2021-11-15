CREATE TABLE [Animes] (
    [AnimeId] int NOT NULL IDENTITY,
    [Nombre] varchar(255) NOT NULL,
    [Genero] varchar(50) NOT NULL,
    [NombreIngles] varchar(255) NULL,
    CONSTRAINT [PK_Animes] PRIMARY KEY ([AnimeId])
);
GO


CREATE TABLE [Paginas] (
    [paginaId] int NOT NULL IDENTITY,
    [nombrePagina] nvarchar(500) NOT NULL,
    [esLegal] bit NOT NULL,
    [esFansub] bit NOT NULL,
    [estaDisponible] bit NOT NULL,
    [estaActivo] bit NOT NULL,
    [urlPagina] nvarchar(500) NULL,
    CONSTRAINT [PK_Paginas] PRIMARY KEY ([paginaId])
);
GO


CREATE TABLE [Peliculas] (
    [PeliculaId] int NOT NULL IDENTITY,
    [nombrePelicula] nvarchar(200) NOT NULL,
    [estudio] nvarchar(100) NULL,
    [AnimeId] int NULL,
    CONSTRAINT [PK_Peliculas] PRIMARY KEY ([PeliculaId]),
    CONSTRAINT [FK_Peliculas_Animes_AnimeId] FOREIGN KEY ([AnimeId]) REFERENCES [Animes] ([AnimeId]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Temporadas] (
    [TemporadaId] int NOT NULL IDENTITY,
    [NumeroTemporada] int NULL,
    [NombreTemporada] varchar(250) NULL,
    [Estado] varchar(100) NOT NULL,
    [tipo] varchar(50) NOT NULL,
    [TemporadaEstreno] varchar(200) NOT NULL,
    [AnimeId] int NULL,
    CONSTRAINT [PK_Temporadas] PRIMARY KEY ([TemporadaId]),
    CONSTRAINT [FK_Temporadas_Animes] FOREIGN KEY ([AnimeId]) REFERENCES [Animes] ([AnimeId])
);
GO


CREATE TABLE [Historial] (
    [id_historial] int NOT NULL IDENTITY,
    [TemporadaId] int NULL,
    [FechaInicio] datetime NULL,
    [FechaFin] datetime NULL,
    [VistoEn] int NOT NULL,
    [AnyoVisto] int NULL,
    [AnimeId] int NULL,
    [PeliculasPeliculaId] int NULL,
    CONSTRAINT [PK_Historial] PRIMARY KEY ([id_historial]),
    CONSTRAINT [FK_Historial_Animes_AnimeId] FOREIGN KEY ([AnimeId]) REFERENCES [Animes] ([AnimeId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Historial_Paginas_VistoEn] FOREIGN KEY ([VistoEn]) REFERENCES [Paginas] ([paginaId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Historial_Peliculas_PeliculasPeliculaId] FOREIGN KEY ([PeliculasPeliculaId]) REFERENCES [Peliculas] ([PeliculaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Historial_Temporadas] FOREIGN KEY ([TemporadaId]) REFERENCES [Temporadas] ([TemporadaId]) ON DELETE NO ACTION
);
GO


CREATE INDEX [IX_Historial_AnimeId] ON [Historial] ([AnimeId]);
GO


CREATE INDEX [IX_Historial_PeliculasPeliculaId] ON [Historial] ([PeliculasPeliculaId]);
GO


CREATE INDEX [IX_Historial_TemporadaId] ON [Historial] ([TemporadaId]);
GO


CREATE INDEX [IX_Historial_VistoEn] ON [Historial] ([VistoEn]);
GO


CREATE INDEX [IX_Peliculas_AnimeId] ON [Peliculas] ([AnimeId]);
GO


CREATE INDEX [IX_Temporadas_AnimeId] ON [Temporadas] ([AnimeId]);
GO


