[Setup]
SignTool=signtool
AppName=ScannerRDP
AppVerName=Scanner RDP - 04 ottobre 2022
DefaultDirName=C:\ApplicazioniDirezione\Unitools
UsePreviousAppDir=no
;disabilita la scelta della cartella di installazione
DisableDirPage=true
DisableProgramGroupPage=true
DisableReadyMemo=true
DisableReadyPage=true
DisableStartupPrompt=true
DefaultGroupName=Unitools
WizardSmallImageFile=C:\Users\guido\Documents\Visual Studio 2013\UniProjects\OmniaManager\Risorse\RisorseExtra\logo_aua_small.bmp
OutputDir=C:\Documents and Settings\Guido\Desktop
OutputBaseFilename=ScannerRDP
VersionInfoVersion=7.04.10.2022
DirExistsWarning=no
Uninstallable=false
CreateUninstallRegKey=false
UpdateUninstallLogAppName=false
;compressione
Compression=lzma/normal
;log
;SetupLogging=yes

AppMutex=UnitoolsLock

; VB6
PrivilegesRequired=none
ShowLanguageDialog=yes
SolidCompression=true
VersionInfoCompany=AUA Soluzioni

[Languages]
Name: default; MessagesFile: C:\Program Files (x86)\Inno Setup 5\Languages\Italian.isl

[Files]
;scanner RDP
Source: "C:\ApplicazioniDirezione\UT\SETUP\ScannerRDP.exe"; DestDir: C:\ApplicazioniDirezione\Unitools; 
Source: "C:\ApplicazioniDirezione\UT\SETUP\DynamicDotNetTWAIN.dll"; DestDir: C:\ApplicazioniDirezione\Unitools; 

[Icons]
Name: "{userdesktop}\ScannerRDP"; Filename: "{app}\ScannerRDP.exe"; IconFilename: "{app}\ScannerRDP.exe"
