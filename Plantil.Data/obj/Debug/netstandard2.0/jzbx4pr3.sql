IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Taxonomys] (
    [Id] int NOT NULL IDENTITY,
    [Genus] nvarchar(max) NULL,
    [Family] nvarchar(max) NULL,
    CONSTRAINT [PK_Taxonomys] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Plants] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [PlantingDate] datetime2 NOT NULL,
    [Multiplication] int NOT NULL,
    [TaxonomyId] int NULL,
    CONSTRAINT [PK_Plants] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plants_Taxonomys_TaxonomyId] FOREIGN KEY ([TaxonomyId]) REFERENCES [Taxonomys] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Experiments] (
    [Id] int NOT NULL IDENTITY,
    [PlantId] int NOT NULL,
    [ExperimentDate] datetime2 NOT NULL,
    [Location] int NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Experiments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Experiments_Plants_PlantId] FOREIGN KEY ([PlantId]) REFERENCES [Plants] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Experiments_PlantId] ON [Experiments] ([PlantId]);

GO

CREATE INDEX [IX_Plants_TaxonomyId] ON [Plants] ([TaxonomyId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200630145808_init', N'3.1.5');

GO

