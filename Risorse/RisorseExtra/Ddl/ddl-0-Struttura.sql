CREATE TABLE [ARP001_TipoFile] 
(  [CodTipoFile] TEXT(3),
   [DesTipoFile] TEXT(50),
   [MatchExp] TEXT(30),
   [CodPeriodicita] SMALLINT 

);                                   


CREATE TABLE [ARP002_File] 
(   
   [Nome] TEXT(50),
   [CodTipoRecord] TEXT(2),
   [DataEstrazione] DATETIME,
   [DataCreazione] DATETIME,
   [DataImportazione] DATETIME,
   [CodTipoFile] TEXT(3),
   [NumeroRecords] INTEGER,
   PRIMARY KEY (Nome, CodTipoRecord)
);


CREATE TABLE [ARP003_TipoRecord] 
(  
   [CodTipoRecord] TEXT(2),
   [DesTipoRecord] TEXT(50)

);                                   

DELETE FROM [ARP003_TipoRecord];
INSERT INTO [ARP003_TipoRecord] VALUES('00', 'anagrafica movimenti escluso QT');
INSERT INTO [ARP003_TipoRecord] VALUES('16', 'anagrafica da QT e rinnovi RCA + ARD + Flotta');
INSERT INTO [ARP003_TipoRecord] VALUES('17', 'anagrafica da QT e rinnovi Rami Elementari');

INSERT INTO [ARP003_TipoRecord] VALUES('01', 'Automatismi, Pulizia RCA, ARD');
INSERT INTO [ARP003_TipoRecord] VALUES('02', 'Automatismi, Pulizia REL');
INSERT INTO [ARP003_TipoRecord] VALUES('05', 'Movimentazione PTF RCA, ARD');
INSERT INTO [ARP003_TipoRecord] VALUES('06', 'Movimentazioni PTF REL');
INSERT INTO [ARP003_TipoRecord] VALUES('07', 'Movimentazione PTF flotta');
INSERT INTO [ARP003_TipoRecord] VALUES('08', 'Movimentazione PTF VITA');
INSERT INTO [ARP003_TipoRecord] VALUES('70', 'Record di cancellazione PTF');
INSERT INTO [ARP003_TipoRecord] VALUES('14', 'Quietanzamento RCA, ARD');
INSERT INTO [ARP003_TipoRecord] VALUES('15', 'Quietanzamento REL');
INSERT INTO [ARP003_TipoRecord] VALUES('21', 'Titolo stornato');
INSERT INTO [ARP003_TipoRecord] VALUES('22', 'Titolo Emesso non da quietanzamento');
INSERT INTO [ARP003_TipoRecord] VALUES('23', 'Titolo incassato con IT o CO o SC');                
INSERT INTO [ARP003_TipoRecord] VALUES('24', 'Sospesi');
INSERT INTO [ARP003_TipoRecord] VALUES('25', 'Chiusura di Scoperto di Cassa');
INSERT INTO [ARP003_TipoRecord] VALUES('26', 'Cancellazione titolo emesso in giorni precedenti');
INSERT INTO [ARP003_TipoRecord] VALUES('27', 'Chiusura Scoperto NON di Cassa');
INSERT INTO [ARP003_TipoRecord] VALUES('28', 'Titolo Emesso da quietanzamento RCA');
INSERT INTO [ARP003_TipoRecord] VALUES('29', 'Titolo Emesso da quietanzamento R.E');
INSERT INTO [ARP003_TipoRecord] VALUES('30', 'Titolo VITA Emesso da quietanzamento');
INSERT INTO [ARP003_TipoRecord] VALUES('31', 'Titolo VITA Emesso da altre procedure serali');

INSERT INTO [ARP003_TipoRecord] VALUES('89', 'Sinistri invio settimanale vecchio tracciato');
INSERT INTO [ARP003_TipoRecord] VALUES('90', 'Sinistri invio mensile vecchio tracciato');
INSERT INTO [ARP003_TipoRecord] VALUES('91', 'Sinistri elaborazione settimanale nuovo tracciato');
INSERT INTO [ARP003_TipoRecord] VALUES('92', 'Sinistri elaborazione mensile nuovo tracciato');


