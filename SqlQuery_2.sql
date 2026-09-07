-- =========================================
-- 0. CREATE DATABASE
-- =========================================


SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

CREATE DATABASE ObracunZaradaDB1;
GO

USE ObracunZaradaDB1;
GO

-- =========================================
-- 1. RACUNOVODJA
-- =========================================
CREATE TABLE dbo.Racunovodja (
    idRacunovodja INT IDENTITY(1,1) NOT NULL,
    korisnickoIme NVARCHAR(50) NOT NULL,
    sifra NVARCHAR(100) NOT NULL,
    ime NVARCHAR(50) NOT NULL,
    prezime NVARCHAR(50) NOT NULL,

    imePrezime AS (ime + ' ' + prezime) PERSISTED,

    CONSTRAINT PK_Racunovodja PRIMARY KEY (idRacunovodja),
    CONSTRAINT UQ_Racunovodja UNIQUE (korisnickoIme),
    CONSTRAINT CHK_Racunovodja_sifra CHECK (LEN(sifra) > 6)
);
GO

-- =========================================
-- 2. VRSTA ZARADE
-- =========================================
CREATE TABLE dbo.VrstaZarade (
    idVrstaZarade INT IDENTITY(1,1) NOT NULL,
    imeVrste NVARCHAR(100) NOT NULL,
    zaradaPoSatu DECIMAL(10,2) NOT NULL DEFAULT 0,
    opis NVARCHAR(255),

    CONSTRAINT PK_VrstaZarade PRIMARY KEY (idVrstaZarade)
);
GO

-- =========================================
-- 3. POZICIJA
-- =========================================
CREATE TABLE dbo.Pozicija (
    idPozicija INT IDENTITY(1,1) NOT NULL,
    naziv NVARCHAR(100) NOT NULL,
    sektor NVARCHAR(100),

    CONSTRAINT PK_Pozicija PRIMARY KEY (idPozicija)
);
GO

-- =========================================
-- 4. AGENCIJA
-- =========================================
CREATE TABLE dbo.Agencija (
    idAgencija INT IDENTITY(1,1) NOT NULL,
    naziv NVARCHAR(150) NOT NULL,
    datumOsnivanja DATE,
    direktor NVARCHAR(100),
    brojTelefona NVARCHAR(30),
    adresa NVARCHAR(200),
    email NVARCHAR(100),
    PIB NVARCHAR(20) NOT NULL,

    CONSTRAINT PK_Agencija PRIMARY KEY (idAgencija)
);
GO

-- =========================================
-- 5. ZAPOSLENI
-- =========================================
CREATE TABLE dbo.Zaposleni (
    idZaposleni INT IDENTITY(1,1) NOT NULL,
    ime NVARCHAR(50) NOT NULL,
    prezime NVARCHAR(50) NOT NULL,

    imePrezime AS (ime + ' ' + prezime) PERSISTED,

    brojTekucegRacuna BIGINT NOT NULL,
    datumRodjenja DATE NOT NULL,
    datumZaposlenja DATE NOT NULL,
    email NVARCHAR(100),
    brojTelefona NVARCHAR(30) NOT NULL,

    idPozicija INT NOT NULL,

    CONSTRAINT PK_Zaposleni PRIMARY KEY (idZaposleni),
    CONSTRAINT CHK_Zaposleni_tel CHECK (LEN(brojTelefona) > 7),

    -- Pozicija: RESTRICT
    CONSTRAINT FK_Zaposleni_Pozicija
        FOREIGN KEY (idPozicija)
        REFERENCES dbo.Pozicija(idPozicija)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);
GO

-- =========================================
-- 6. OBRACUN ZARADE
-- =========================================
CREATE TABLE dbo.ObracunZarade (
    idObracunZarade INT IDENTITY(1,1) NOT NULL,

    datumOd DATE NOT NULL,
    datumDo DATE NOT NULL,

    storniran BIT DEFAULT 0,
    napomena NVARCHAR(255) DEFAULT '',

    ukupnaZarada DECIMAL(12,2) NOT NULL,

    idZaposleni INT NOT NULL,
    idRacunovodja INT NOT NULL,

    CONSTRAINT PK_Obracun PRIMARY KEY (idObracunZarade),

    CONSTRAINT CHK_datum CHECK (datumDo > datumOd),
    CONSTRAINT CHK_zarada CHECK (ukupnaZarada >= 0),

    -- Zaposleni: RESTRICT
    CONSTRAINT FK_Obracun_Zaposleni
        FOREIGN KEY (idZaposleni)
        REFERENCES dbo.Zaposleni(idZaposleni)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,

    -- Racunovodja: RESTRICT + UPDATE CASCADE (iz modela)
    CONSTRAINT FK_Obracun_Racunovodja
        FOREIGN KEY (idRacunovodja)
        REFERENCES dbo.Racunovodja(idRacunovodja)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- =========================================
-- 7. STAVKA OBRACUNA
-- =========================================
CREATE TABLE dbo.StavkaObracunaZarade (
    idObracunZarade INT NOT NULL,
    rb INT NOT NULL,

    brojSati INT NULL,

    ukupnaZaradaStavka DECIMAL(12,2) NOT NULL,
    napomena NVARCHAR(255),

    idVrstaZarade INT NOT NULL,

    CONSTRAINT PK_Stavka PRIMARY KEY (idObracunZarade, rb),

    CONSTRAINT CHK_rb CHECK (rb > 0),
    CONSTRAINT CHK_sati CHECK (brojSati IS NULL OR brojSati >= 0),
    CONSTRAINT CHK_iznos CHECK (ukupnaZaradaStavka >= 0),

    -- ObracunZarade: CASCADE UPDATE + RESTRICT DELETE
    CONSTRAINT FK_Stavka_Obracun
        FOREIGN KEY (idObracunZarade)
        REFERENCES dbo.ObracunZarade(idObracunZarade)
        ON UPDATE CASCADE
        ON DELETE NO ACTION,

    -- VrstaZarade: RESTRICT
    CONSTRAINT FK_Stavka_Vrsta
        FOREIGN KEY (idVrstaZarade)
        REFERENCES dbo.VrstaZarade(idVrstaZarade)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);
GO

-- =========================================
-- 8. RACUNOVODJA - AGENCIJA
-- =========================================
CREATE TABLE dbo.Racunovodja_Agencija (
    idRacunovodja INT NOT NULL,
    idAgencija INT NOT NULL,
    brojUgovora INT NOT NULL,

    CONSTRAINT PK_RA PRIMARY KEY (idRacunovodja, idAgencija),

    -- Racunovodja: RESTRICT
    CONSTRAINT FK_RA_Racunovodja
        FOREIGN KEY (idRacunovodja)
        REFERENCES dbo.Racunovodja(idRacunovodja)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,

    -- Agencija: RESTRICT
    CONSTRAINT FK_RA_Agencija
        FOREIGN KEY (idAgencija)
        REFERENCES dbo.Agencija(idAgencija)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);
GO