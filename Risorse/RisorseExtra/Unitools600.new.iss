; --- UniTools.iss --------------------
; Installazione programma UniTools PC propri
; -------------------------------------
;#pragma include __INCLUDE__ + ";" + ReadReg(HKLM, "Software\Mitrich Software\Inno Download Plugin", "InstallDir")
#pragma include __INCLUDE__ + ";" + "C:\Program Files\Inno Download Plugin"
#include <idp.iss>
;percorso da utilizzare per i singoli progetti addin
;#pragma include "C:\Programmi\Microsoft Visual Studio\VB98\Progetti VB\UniTools\Install\Unitools\Progetti"

[Setup]
AppName=Aggiornamento setup
AppVerName=Setup - 23 Agosto 2016
DefaultDirName=C:\ApplicazioniDirezione\UTSetup
UsePreviousAppDir=no
;disabilita la scelta della cartella di installazione
DisableDirPage=true
DisableProgramGroupPage=true
DefaultGroupName=Unitools
WizardImageFile=C:\Programmi\Microsoft Visual Studio\VB98\Progetti VB\UniTools\Install\Uniarea.bmp
WizardSmallImageFile=C:\Programmi\Microsoft Visual Studio\VB98\Progetti VB\UniTools\Install\logouniarea.bmp
OutputDir=C:\Documents and Settings\Guido\Desktop
OutputBaseFilename=Setup600.new
VersionInfoVersion=6.23.08.2016
DirExistsWarning=no
;LicenseFile=C:\Programmi\Microsoft Visual Studio\VB98\Progetti VB\UniTools\LicenzaConsorzio.rtf
;disinstallazione NO
Uninstallable=false
CreateUninstallRegKey=false
UpdateUninstallLogAppName=false
;compressione
Compression=lzma/normal
;log
;SetupLogging=yes

DisableStartupPrompt=true
AppMutex=UnitoolsLock
PrivilegesRequired=none
ShowLanguageDialog=yes
SolidCompression=true
VersionInfoCompany=Uniarea srl

[Languages]
Name: default; MessagesFile: C:\Programmi\Microsoft Visual Studio\VB98\Progetti VB\UniTools\Install\italian510.isl

[Files]
;setup
Source: "{tmp}\Setup600.exe";           DestDir: "{app}\Modelli"; Flags: external

[Components]
Name: "app"; Description: "Unitools-UniSinistri"; Types: full; Flags: fixed exclusive

[_ISTool]
Use7zip=false

[Messages]
SetupAppRunningError=E' in corso un tentativo di aggiornamento di %1.%nL'installazione dell'aggiornamento non può proseguire poiché %1 è attualmente in esecuzione.%n%nSi consiglia di chiudere adesso %1 e poi premere OK (in tal caso l'aggiornamento verrà effettuato), oppure premere Annulla per uscire (in tal caso l'aggiornamento NON verrà effettuato).
SetupAppTitle=Installazione Unitools

[InnoIDE_Settings]
LogFileOverwrite=false

[ThirdPartySettings]
CompileLogMethod=append

[ThirdParty]
CompileLogMethod=append

[Code]
procedure InitializeWizard;
begin
    //setup
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/Setup600.exe', ExpandConstant('{tmp}\Setup600.exe'), 'app');
    idpDownloadAfter(wpReady);
end;
