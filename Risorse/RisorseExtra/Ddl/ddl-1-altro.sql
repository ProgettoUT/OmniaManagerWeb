CREATE TABLE SubagenziaProduttore
(
    DataElaborazione                             DATE,
    CodicePuntoVendita                           CHAR(5),
    Progressivo                                  CHAR(2),
    TipoElaborazione                             CHAR(2),
    Ramo                                         CHAR(3),
    Polizza                                      VARCHAR(9),
    CodiceSubagenziaOld                          CHAR(3),
    CodiceProduttoreOld                          VARCHAR(7),
    CodiceSubagenziaNew                          CHAR(3),
    CodiceProduttoreNew                          VARCHAR(7),
    NumeroVeicolo                                VARCHAR(7),
    Archivio                                     VARCHAR(11),
    NumeroVariazione                             CHAR(3),
    DataVariazione                               DATE
);

CREATE TABLE TitoloPNA
(
    DataElaborazione                             DATE,
    CodicePuntoVendita                           CHAR(5),
    Progressivo                                  CHAR(2),
    TipoElaborazione                             CHAR(2),
    DataRegMovimento                             DATE,
    ImportoMovimento                             CURRENCY,
    CodiceSegno                                  CHAR(1),
    CodiceMovimento                              CHAR(3),
    CodoceTipoMovimento                          CHAR(3),
    FlagOperazione                               CHAR(1),
    DataModifica                                 DATE,
    Descrizione                                  VARCHAR(40),
    DataRegistrazioneDecade                      DATE,
    ProgressivoElaborazione                      VARCHAR(9)
);

CREATE TABLE Liquidatori
(
    ProgressivoFile                              INTEGER,
    DataElaborazione                             DATE,
    CodicePuntoVendita                           CHAR(5),
    Progressivo                                  CHAR(2),
    TipoElaborazione                             CHAR(2),
    Codice                                       INTEGER,
    Cognome                                      VARCHAR(20),
    Nome                                         VARCHAR(20),
    CslLavoro                                    INTEGER,
    Localita                                     VARCHAR(50),
    Provincia                                    CHAR(3),
    Telefono                                     VARCHAR(20),
    TelefonoCsl                                  VARCHAR(20),
    Email                                        VARCHAR(50),
    PRIMARY KEY(Codice)
);
