; --- UniTools.iss --------------------
; Installazione programma UniTools PC propri
; -------------------------------------
#pragma include __INCLUDE__ + ";" + "C:\Program Files (x86)\Inno Download Plugin"
#include <idp.iss>

[Setup]
AppName=Unitools scanner RDP
AppVerName=Unitools scanner RDP - 7 febbraio 2020
DefaultDirName=C:\ApplicazioniDirezione\Unitools
UsePreviousAppDir=no
;disabilita la scelta della cartella di installazione
DisableDirPage=true
DisableProgramGroupPage=true
DisableReadyMemo=true
DisableReadyPage=true
DisableStartupPrompt=true
DefaultGroupName=Unitools
WizardImageFile=C:\Users\guido\Documents\Visual Studio 2013\UniProjects\OmniaManager\Risorse\RisorseExtra\uniarea.bmp
WizardSmallImageFile=C:\Users\guido\Documents\Visual Studio 2013\UniProjects\OmniaManager\Risorse\RisorseExtra\logouniarea.bmp
OutputDir=C:\Documents and Settings\Guido\Desktop
OutputBaseFilename=SetupRDP
VersionInfoVersion=7.07.02.2020
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

AppMutex=UnitoolsLock

;percorso da utilizzare per i singoli progetti addin
;#pragma include "C:\Programmi\Microsoft Visual Studio\VB98\Progetti VB\UniTools\Install\Unitools\Progetti"

[Languages]
Name: default; MessagesFile: C:\Program Files (x86)\Inno Setup 5\Languages\Italian.isl

[Files]
Source: "{tmp}\ScannerRDP.exe"; DestDir: "{app}"; Flags: external
Source: "{tmp}\DynamicDotNetTWAIN.dll"; DestDir: "{app}"; Flags: external onlyifdoesntexist

[Components]
Name: "app"; Description: "OmniaManager"; Types: full; Flags: fixed exclusive

[Icons]
Name: "{commondesktop}\ScannerRDP"; Filename: "C:\ApplicazioniDirezione\Unitools\ScannerRDP.exe"; WorkingDir: "C:\ApplicazioniDirezione\Unitools"; Comment: "Scanner RDP"

[_ISTool]
Use7zip=false

[Messages]
SetupAppRunningError=E' in corso un tentativo di aggiornamento di %1.%nL'installazione dell'aggiornamento non può proseguire poiché %1 è attualmente in esecuzione.%n%nSi consiglia di chiudere adesso %1 e poi premere OK (in tal caso l'aggiornamento verrà effettuato), oppure premere Annulla per uscire (in tal caso l'aggiornamento NON verrà effettuato).
SetupAppTitle=Installazione Unitools

[InnoIDE_Settings]
LogFileOverwrite=false

[ThirdParty]
CompileLogMethod=append

[Dirs]
Name: "{app}\Logs"
Name: "{app}\Modelli"

[Code]
procedure InitializeWizard;
begin
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/OM/PROD/EXE/ScannerRDP.exe',          ExpandConstant('{tmp}\ScannerRDP.exe'          ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/OM/PROD/DLL/DynamicDotNetTWAIN.dll',  ExpandConstant('{tmp}\DynamicDotNetTWAIN.dll'  ), 'app');

    idpDownloadAfter(wpReady);
end;
