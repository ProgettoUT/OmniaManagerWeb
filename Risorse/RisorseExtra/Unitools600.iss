; --- UniTools.iss --------------------
; Installazione programma UniTools
; -------------------------------------
;#pragma include __INCLUDE__ + ";" + ReadReg(HKLM, "Software\Mitrich Software\Inno Download Plugin", "InstallDir")
#pragma include __INCLUDE__ + ";" + "C:\Program Files (x86)\Inno Download Plugin"
#include <idp.iss>

[Setup]
AppName=Unitools-UniSinistri
AppVerName=Unitools-UniSinistri 6.0.0 - 22 gennaio 2018
DefaultDirName=C:\ApplicazioniDirezione\Unitools
UsePreviousAppDir=no
;disabilita la scelta della cartella di installazione
DisableDirPage=true
DisableProgramGroupPage=true
DisableReadyMemo=true
DisableReadyPage=true
DisableStartupPrompt=true
DefaultGroupName=Unitools
WizardImageFile=C:\Users\guido\Documents\Visual Studio 2013\UniProjects\Risorse\RisorseExtra\uniarea.bmp
WizardSmallImageFile=C:\Users\guido\Documents\Visual Studio 2013\UniProjects\Risorse\RisorseExtra\logouniarea.bmp
OutputDir=C:\Documents and Settings\Guido\Desktop
OutputBaseFilename=Setup600
VersionInfoVersion=6.19.01.2017
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

; VB6
PrivilegesRequired=none
ShowLanguageDialog=yes
SolidCompression=true
VersionInfoCompany=Uniarea srl

[Languages]
Name: default; MessagesFile: C:\Users\guido\Documents\Visual Studio 2013\UniProjects\Risorse\RisorseExtra\Italian510.isl

[Files]
;chiusura delle app aperte
;#include <ChiudiProcessi.iss>
;setup
Source: "{tmp}\Setup600.new.exe";       DestDir: "{app}\Modelli"; Flags: external
;exe
Source: "{tmp}\ARemota.exe";            DestDir: "{app}\Modelli"; Flags: external
Source: "{tmp}\ARemota.idc2q52jcz.exe"; DestDir: "{app}\Modelli"; Flags: external
Source: "{tmp}\Assistenza.exe";         DestDir: "{app}";         Flags: external
Source: "{tmp}\BackupArchivi.exe";      DestDir: "{app}";         Flags: external
Source: "{tmp}\BridgeCom2.exe";         DestDir: "{app}";         Flags: external
Source: "{tmp}\Comunicazioni.exe";      DestDir: "{app}";         Flags: external
Source: "{tmp}\InfoUt.exe";             DestDir: "{app}";         Flags: external
Source: "{tmp}\LiveUpdate.exe";         DestDir: "{app}";         Flags: external
Source: "{tmp}\Notifica.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\ProDoc.exe";             DestDir: "{app}";         Flags: external
Source: "{tmp}\RemunerazioneRca.exe";   DestDir: "{app}";         Flags: external
Source: "{tmp}\UniAggio.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\UniCover.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\Unidocs.exe";            DestDir: "{app}";         Flags: external
Source: "{tmp}\UniEsplo.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\UniEstra.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\UniQuota.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\Unitools.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\UtLoader.exe";           DestDir: "{app}";         Flags: external
Source: "{tmp}\Utwitt.exe";             DestDir: "{app}";         Flags: external
;dll
Source: "{tmp}\Adempimenti.dll";                    DestDir: "{app}"; Flags: external
Source: "{tmp}\Anag.dll";                           DestDir: "{app}"; Flags: external
Source: "{tmp}\Anax.dll";                           DestDir: "{app}"; Flags: external
Source: "{tmp}\AxInterop.AcroPDFLib.dll";           DestDir: "{app}"; Flags: external
Source: "{tmp}\AxInterop.SHDocVw.dll";              DestDir: "{app}"; Flags: external
Source: "{tmp}\Budget.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\Centralino.dll";                     DestDir: "{app}"; Flags: external
Source: "{tmp}\ChiusuraCassa.dll";                  DestDir: "{app}"; Flags: external
Source: "{tmp}\Consap.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\DynamicDotNetTWAIN.dll";             DestDir: "{app}"; Flags: external
Source: "{tmp}\Export.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\GestioneDocumenti.dll";              DestDir: "{app}"; Flags: external
Source: "{tmp}\IDati.dll";                          DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.AcroPDFLib.dll";             DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.AcroPDFLib.dll";             DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.ADODB.dll";                  DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.ADOX.dll";                   DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.CGZipLibrary.dll";           DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.JRO.dll";                    DestDir: "{app}"; Flags: external
Source: "{tmp}\Interop.SHDocVw.dll";                DestDir: "{app}"; Flags: external
Source: "{tmp}\Microsoft.Office.Interop.Excel.dll"; DestDir: "{app}"; Flags: external
Source: "{tmp}\Microsoft.Web.Services3.dll";        DestDir: "{app}"; Flags: external
Source: "{tmp}\Microsoft.mshtml.dll";               DestDir: "{app}"; Flags: external
Source: "{tmp}\MonitorQT.dll";                      DestDir: "{app}"; Flags: external
Source: "{tmp}\NuovaProduzione.dll";                DestDir: "{app}"; Flags: external
Source: "{tmp}\Patto.dll";                          DestDir: "{app}"; Flags: external
Source: "{tmp}\Referenti.dll";                      DestDir: "{app}"; Flags: external
Source: "{tmp}\Risorse.dll";                        DestDir: "{app}"; Flags: external
Source: "{tmp}\Sinistri.dll";                       DestDir: "{app}"; Flags: external
Source: "{tmp}\Select.HtmlToPdf.dll";               DestDir: "{app}"; Flags: external
Source: "{tmp}\Select.Html.dep.zip";                DestDir: "{app}"; DestName: "Select.Html.dep"; Flags: external
Source: "{tmp}\Telerik.WinControls.ChartView.dll";  DestDir: "{app}"; Flags: external
Source: "{tmp}\Telerik.WinControls.dll";            DestDir: "{app}"; Flags: external
Source: "{tmp}\Telerik.WinControls.UI.dll";         DestDir: "{app}"; Flags: external
Source: "{tmp}\Telerik.Windows.Zip.dll";            DestDir: "{app}"; Flags: external
Source: "{tmp}\TelerikCommon.dll";                  DestDir: "{app}"; Flags: external
Source: "{tmp}\UMenu.dll";                          DestDir: "{app}"; Flags: external
Source: "{tmp}\UniCai.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\UniCom.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\UniFeed.dll";                        DestDir: "{app}"; Flags: external
Source: "{tmp}\UnigestUp.dll";                      DestDir: "{app}"; Flags: external
Source: "{tmp}\UniSql.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\Ut.dll";                             DestDir: "{app}"; Flags: external
Source: "{tmp}\UtControls.dll";                     DestDir: "{app}"; Flags: external
Source: "{tmp}\Utwitt.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\Visure.dll";                         DestDir: "{app}"; Flags: external
Source: "{tmp}\Kennedy.ManagedHooks.dll";           DestDir: "{app}"; Flags: external
Source: "{tmp}\SystemHookCore.dll";                 DestDir: "{app}"; Flags: external
;mdb comuni
Source: "{tmp}\Sms.mdb.zip";        DestDir: "{app}\Modelli\Dati\Comuni"; DestName: "Sms.mdb";      Flags: external
Source: "{tmp}\Supporto.mdb.zip";   DestDir: "{app}\Modelli\Dati\Comuni"; DestName: "Supporto.mdb"; Flags: external
;mdb agenzia  
Source: "{tmp}\Anag.mdb.zip";       DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Anag.mdb";      Flags: external
Source: "{tmp}\Andamenti.mdb.zip";  DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Andamenti.mdb"; Flags: external
Source: "{tmp}\Budget.mdb.zip";     DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Budget.mdb";    Flags: external
Source: "{tmp}\Cassa.mdb.zip";      DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Cassa.mdb";     Flags: external
Source: "{tmp}\Clienti.mdb.zip";    DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Clienti.mdb";   Flags: external
Source: "{tmp}\Evidenze.mdb.zip";   DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Evidenze.mdb";  Flags: external
Source: "{tmp}\Incassi.mdb.zip";    DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Incassi.mdb";   Flags: external
Source: "{tmp}\Info.mdb.zip";       DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Info.mdb";      Flags: external
Source: "{tmp}\Liste.mdb.zip";      DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Liste.mdb";     Flags: external
Source: "{tmp}\Note.mdb.zip";       DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Note.mdb";      Flags: external
Source: "{tmp}\Polizze.mdb.zip";    DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Polizze.mdb";   Flags: external
Source: "{tmp}\Replica.mdb.zip";    DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Replica.mdb";   Flags: external
Source: "{tmp}\Sinistri.mdb.zip";   DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Sinistri.mdb";  Flags: external
Source: "{tmp}\Titoli.mdb.zip";     DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Titoli.mdb";    Flags: external
Source: "{tmp}\Unicoop.mdb.zip";    DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "Unicoop.mdb";   Flags: external
Source: "{tmp}\UtStorico.mdb.zip";  DestDir: "{app}\Modelli\Dati\Agenzia"; DestName: "UtStorico.mdb"; Flags: external
;mdb vari
Source: "{tmp}\Vuoto.mdb.zip";          DestDir: "{app}\Modelli"; DestName: "Vuoto.mdb";          Flags: external
Source: "{tmp}\BackupLog.mdb.zip";      DestDir: "{app}\Modelli"; DestName: "BackupLog.mdb";      Flags: external
Source: "{tmp}\DbLink.mdb.zip";         DestDir: "{app}\Modelli"; DestName: "DbLink.mdb";         Flags: external
Source: "{tmp}\DbUno.mdb.zip";          DestDir: "{app}\Modelli"; DestName: "DbUno.mdb";          Flags: external
Source: "{tmp}\DbUt.mdb.zip";           DestDir: "{app}\Modelli"; DestName: "DbUt.mdb";           Flags: external
Source: "{tmp}\Comunicazioni.mdb.zip";  DestDir: "{app}\Modelli"; DestName: "Comunicazioni.mdb";  Flags: external
;help
Source: "{tmp}\P01201.chm";   DestDir: "{app}"; Flags: external
Source: "{tmp}\P01204.chm";   DestDir: "{app}"; Flags: external
Source: "{tmp}\P04226.chm";   DestDir: "{app}"; Flags: external
Source: "{tmp}\P07201.chm";   DestDir: "{app}"; Flags: external
Source: "{tmp}\P07260.chm";   DestDir: "{app}"; Flags: external
Source: "{tmp}\P07261.chm";   DestDir: "{app}"; Flags: external
Source: "{tmp}\Unitools.chm"; DestDir: "{app}"; Flags: external
;layout
Source: "{tmp}\Clienti.layout.xml.zip";         DestDir: "{app}\Modelli\Setting"; DestName: "Clienti.layout.xml";         Flags: external
Source: "{tmp}\ClientiIncassi.layout.xml.zip";  DestDir: "{app}\Modelli\Setting"; DestName: "ClientiIncassi.layout.xml";  Flags: external
Source: "{tmp}\ClientiPolizze.layout.xml.zip";  DestDir: "{app}\Modelli\Setting"; DestName: "ClientiPolizze.layout.xml";  Flags: external
Source: "{tmp}\Sinistri.layout.xml.zip";        DestDir: "{app}\Modelli\Setting"; DestName: "Sinistri.layout.xml";        Flags: external
Source: "{tmp}\Sopravvenienze.layout.xml.zip";  DestDir: "{app}\Modelli\Setting"; DestName: "Sopravvenienze.layout.xml";  Flags: external
Source: "{tmp}\Perizie.layout.xml.zip";         DestDir: "{app}\Modelli\Setting"; DestName: "Perizie.layout.xml";         Flags: external
;viste
Source: "{tmp}\vista_andamenti.txt";  DestDir: "{app}\Modelli\Setting"; Flags: external
Source: "{tmp}\vista_clienti.txt";    DestDir: "{app}\Modelli\Setting"; Flags: external
Source: "{tmp}\vista_incarichi.txt";  DestDir: "{app}\Modelli\Setting"; Flags: external
Source: "{tmp}\vista_sinistri.txt";   DestDir: "{app}\Modelli\Setting"; Flags: external
Source: "{tmp}\vista_polizze.txt";    DestDir: "{app}\Modelli\Setting"; Flags: external
Source: "{tmp}\vista_PTFcanc.txt";    DestDir: "{app}\Modelli\Setting"; Flags: external
;varie
Source: "{tmp}\specifica-tutti.xml.zip";          DestDir: "{app}\Modelli\Setting"; DestName: "specifica-tutti.xml";          Flags: external
Source: "{tmp}\IndicatoreCliente.layout.xml.zip"; DestDir: "{app}\Modelli\Setting"; DestName: "IndicatoreCliente.layout.xml"; Flags: external
Source: "{tmp}\IndicatoreCliente.stp.zip";        DestDir: "{app}\Modelli\Setting"; DestName: "IndicatoreCliente.stp";        Flags: external
Source: "{tmp}\ut_no_login.html";                 DestDir: "{app}\Modelli";                                                   Flags: external
Source: "{tmp}\RichiestaConsap.rtf";              DestDir: "{app}\Modelli\Setting";                                           Flags: external
Source: "{tmp}\RichiestaConsapDelega.rtf";        DestDir: "{app}\Modelli\Setting";                                           Flags: external
Source: "{tmp}\ut_wait.html";                     DestDir: "{app}\Modelli";                                                   Flags: external
Source: "{tmp}\ut_wait.gif";                      DestDir: "{app}\Modelli";                                                   Flags: external
Source: "{tmp}\ut_no_login.html";                 DestDir: "{app}\Modelli";                                                   Flags: external
;assegni
Source: "{tmp}\4Cheque.dll";            DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\4cheque.ini.zip";        DestDir: "{app}\"; DestName: "4cheque.ini";         Flags: external
Source: "{tmp}\4cheque.mdk.zip";        DestDir: "{app}\"; DestName: "4cheque.mdk";         Flags: external
Source: "{tmp}\4ChequeE.mdk.zip";       DestDir: "{app}\"; DestName: "4ChequeE.mdk";        Flags: external
Source: "{tmp}\4Cheques.mdk.zip";       DestDir: "{app}\"; DestName: "4Cheques.mdk";        Flags: external
Source: "{tmp}\ASLoader.exe";           DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\Assegni.exe";            DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\Assegni.exe.config.zip"; DestDir: "{app}\"; DestName: "Assegni.exe.config";  Flags: external
Source: "{tmp}\C4Cheque.dll";           DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\Export32.dll";           DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\Export33.dll";           DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\Export34.dll";           DestDir: "{app}\";                                  Flags: external
Source: "{tmp}\IfWs4ChequeLicense.dll"; DestDir: "{app}\";                                  Flags: external
;Source: "{tmp}\Interop.MSHTML.dll";           DestDir: "{app}\";                                 Flags: external
Source: "{tmp}\joinimg.dll";                  DestDir: "{app}\"; Flags: external
Source: "{tmp}\mfc80.dll";                    DestDir: "{app}\"; Flags: external
Source: "{tmp}\Microsoft.VC80.CRT.manifest";  DestDir: "{app}\"; Flags: external
Source: "{tmp}\Microsoft.VC80.MFC.manifest";  DestDir: "{app}\"; Flags: external
Source: "{tmp}\msvcm80.dll";                  DestDir: "{app}\"; Flags: external
Source: "{tmp}\msvcp80.dll";                  DestDir: "{app}\"; Flags: external
Source: "{tmp}\msvcr80.dll";                  DestDir: "{app}\"; Flags: external
Source: "{tmp}\scandeco.dll";                 DestDir: "{app}\"; Flags: external
Source: "{tmp}\UtNetUtility32.dll";           DestDir: "{app}\"; Flags: external
Source: "{tmp}\UtNetUtility33.dll";           DestDir: "{app}\"; Flags: external

[Components]
Name: "app"; Description: "Unitools-UniSinistri"; Types: full; Flags: fixed exclusive

[Icons]
Name: "{userdesktop}\Unitools"; Filename: "{app}\Unitools.exe"; IconFilename: "{app}\Unitools.exe"
Name: "{userdesktop}\Assistenza Unitools"; Filename: "{app}\Assistenza.exe"

[_ISTool]
Use7zip=false

[InstallDelete]
Type: files; Name: "{app}\RenameFile.exe"

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
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/Setup600.new.exe', ExpandConstant('{tmp}\Setup600.new.exe'), 'app');
    //exe
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/ARemota.exe',            ExpandConstant('{tmp}\ARemota.exe'            ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/ARemota.idc2q52jcz.exe', ExpandConstant('{tmp}\ARemota.idc2q52jcz.exe' ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/Assistenza.exe',         ExpandConstant('{tmp}\Assistenza.exe'         ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/BackupArchivi.exe',      ExpandConstant('{tmp}\BackupArchivi.exe'      ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/BridgeCom2.exe',         ExpandConstant('{tmp}\BridgeCom2.exe'         ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/Comunicazioni.exe',      ExpandConstant('{tmp}\Comunicazioni.exe'      ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/InfoUt.exe',             ExpandConstant('{tmp}\InfoUt.exe'             ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/LiveUpdate.exe',         ExpandConstant('{tmp}\LiveUpdate.exe'         ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/Notifica.exe',           ExpandConstant('{tmp}\Notifica.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/ProDoc.exe',             ExpandConstant('{tmp}\ProDoc.exe'             ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/RemunerazioneRca.exe',   ExpandConstant('{tmp}\RemunerazioneRca.exe'   ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/UniAggio.exe',           ExpandConstant('{tmp}\UniAggio.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/UniCover.exe',           ExpandConstant('{tmp}\UniCover.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/Unidocs.exe',            ExpandConstant('{tmp}\Unidocs.exe'            ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/UniEsplo.exe',           ExpandConstant('{tmp}\UniEsplo.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/UniEstra.exe',           ExpandConstant('{tmp}\UniEstra.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/UniQuota.exe',           ExpandConstant('{tmp}\UniQuota.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/Unitools.exe',           ExpandConstant('{tmp}\Unitools.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/UtLoader.exe',           ExpandConstant('{tmp}\UtLoader.exe'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/EXE/Utwitt.exe',             ExpandConstant('{tmp}\Utwitt.exe'             ), 'app');
    //dll
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/4Cheque.dll',                        ExpandConstant('{tmp}\4Cheque.dll'              ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Adempimenti.dll',                    ExpandConstant('{tmp}\Adempimenti.dll'          ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Anag.dll',                           ExpandConstant('{tmp}\Anag.dll'                 ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Anax.dll',                           ExpandConstant('{tmp}\Anax.dll'                 ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/AxInterop.AcroPDFLib.dll',           ExpandConstant('{tmp}\AxInterop.AcroPDFLib.dll' ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/AxInterop.SHDocVw.dll',              ExpandConstant('{tmp}\AxInterop.SHDocVw.dll'    ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Budget.dll',                         ExpandConstant('{tmp}\Budget.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Centralino.dll',                     ExpandConstant('{tmp}\Centralino.dll'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/ChiusuraCassa.dll',                  ExpandConstant('{tmp}\ChiusuraCassa.dll'        ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Consap.dll',                         ExpandConstant('{tmp}\Consap.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/DynamicDotNetTWAIN.dll',             ExpandConstant('{tmp}\DynamicDotNetTWAIN.dll'   ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Export.dll',                         ExpandConstant('{tmp}\Export.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/GestioneDocumenti.dll',              ExpandConstant('{tmp}\GestioneDocumenti.dll'    ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/IDati.dll',                          ExpandConstant('{tmp}\IDati.dll'                ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.AcroPDFLib.dll',             ExpandConstant('{tmp}\Interop.AcroPDFLib.dll'   ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.AcroPDFLib.dll',             ExpandConstant('{tmp}\Interop.AcroPDFLib.dll'   ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.ADODB.dll',                  ExpandConstant('{tmp}\Interop.ADODB.dll'        ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.ADOX.dll',                   ExpandConstant('{tmp}\Interop.ADOX.dll'         ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.CGZipLibrary.dll',           ExpandConstant('{tmp}\Interop.CGZipLibrary.dll' ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.JRO.dll',                    ExpandConstant('{tmp}\Interop.JRO.dll'          ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Interop.SHDocVw.dll',                ExpandConstant('{tmp}\Interop.SHDocVw.dll'      ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Microsoft.Office.Interop.Excel.dll', ExpandConstant('{tmp}\Microsoft.Office.Interop.Excel.dll'), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Microsoft.Web.Services3.dll',        ExpandConstant('{tmp}\Microsoft.Web.Services3.dll'), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Microsoft.mshtml.dll',               ExpandConstant('{tmp}\Microsoft.mshtml.dll'     ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/MonitorQT.dll',                      ExpandConstant('{tmp}\MonitorQT.dll'            ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/NuovaProduzione.dll',                ExpandConstant('{tmp}\NuovaProduzione.dll'      ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Patto.dll',                          ExpandConstant('{tmp}\Patto.dll'                ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Referenti.dll',                      ExpandConstant('{tmp}\Referenti.dll'            ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Risorse.dll',                        ExpandConstant('{tmp}\Risorse.dll'              ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Sinistri.dll',                       ExpandConstant('{tmp}\Sinistri.dll'             ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Select.Html.dep.zip',                ExpandConstant('{tmp}\Select.Html.dep.zip'      ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Select.HtmlToPdf.dll',               ExpandConstant('{tmp}\Select.HtmlToPdf.dll'     ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Telerik.WinControls.ChartView.dll',  ExpandConstant('{tmp}\Telerik.WinControls.ChartView.dll'), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Telerik.WinControls.dll',            ExpandConstant('{tmp}\Telerik.WinControls.dll'  ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Telerik.WinControls.UI.dll',         ExpandConstant('{tmp}\Telerik.WinControls.UI.dll'), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Telerik.Windows.Zip.dll',            ExpandConstant('{tmp}\Telerik.Windows.Zip.dll'  ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/TelerikCommon.dll',                  ExpandConstant('{tmp}\TelerikCommon.dll'        ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UMenu.dll',                          ExpandConstant('{tmp}\UMenu.dll'                ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UniCai.dll',                         ExpandConstant('{tmp}\UniCai.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UniCom.dll',                         ExpandConstant('{tmp}\UniCom.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UniFeed.dll',                        ExpandConstant('{tmp}\UniFeed.dll'              ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UnigestUp.dll',                      ExpandConstant('{tmp}\UnigestUp.dll'            ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UniSql.dll',                         ExpandConstant('{tmp}\UniSql.dll '              ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Ut.dll',                             ExpandConstant('{tmp}\Ut.dll'                   ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/UtControls.dll',                     ExpandConstant('{tmp}\UtControls.dll'           ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Utwitt.dll',                         ExpandConstant('{tmp}\Utwitt.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Visure.dll',                         ExpandConstant('{tmp}\Visure.dll'               ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/Kennedy.ManagedHooks.dll',           ExpandConstant('{tmp}\Kennedy.ManagedHooks.dll' ), 'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DLL/SystemHookCore.dll',                 ExpandConstant('{tmp}\SystemHookCore.dll'       ), 'app');
    //mdb
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Sms.mdb.zip',           ExpandConstant('{tmp}\Sms.mdb.zip'      ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Supporto.mdb.zip',      ExpandConstant('{tmp}\Supporto.mdb.zip' ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Anag.mdb.zip',          ExpandConstant('{tmp}\Anag.mdb.zip'     ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Andamenti.mdb.zip',     ExpandConstant('{tmp}\Andamenti.mdb.zip'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Budget.mdb.zip',        ExpandConstant('{tmp}\Budget.mdb.zip'   ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Cassa.mdb.zip',         ExpandConstant('{tmp}\Cassa.mdb.zip'    ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Clienti.mdb.zip',       ExpandConstant('{tmp}\Clienti.mdb.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Evidenze.mdb.zip',      ExpandConstant('{tmp}\Evidenze.mdb.zip' ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Incassi.mdb.zip',       ExpandConstant('{tmp}\Incassi.mdb.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Info.mdb.zip',          ExpandConstant('{tmp}\Info.mdb.zip'     ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Liste.mdb.zip',         ExpandConstant('{tmp}\Liste.mdb.zip'    ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Note.mdb.zip',          ExpandConstant('{tmp}\Note.mdb.zip'     ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Polizze.mdb.zip',       ExpandConstant('{tmp}\Polizze.mdb.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Sinistri.mdb.zip',      ExpandConstant('{tmp}\Sinistri.mdb.zip' ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Replica.mdb.zip',       ExpandConstant('{tmp}\Replica.mdb.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Titoli.mdb.zip',        ExpandConstant('{tmp}\Titoli.mdb.zip'   ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Unicoop.mdb.zip',       ExpandConstant('{tmp}\Unicoop.mdb.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/UtStorico.mdb.zip',     ExpandConstant('{tmp}\UtStorico.mdb.zip'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Vuoto.mdb.zip',         ExpandConstant('{tmp}\Vuoto.mdb.zip'    ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/BackupLog.mdb.zip',     ExpandConstant('{tmp}\BackupLog.mdb.zip'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/DbLink.mdb.zip',        ExpandConstant('{tmp}\DbLink.mdb.zip'   ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/DbUno.mdb.zip',         ExpandConstant('{tmp}\DbUno.mdb.zip'    ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/DbUt.mdb.zip',          ExpandConstant('{tmp}\DbUt.mdb.zip'     ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/DB/Comunicazioni.mdb.zip', ExpandConstant('{tmp}\Comunicazioni.mdb.zip'     ),  'app');
    //help
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/P01201.chm',   ExpandConstant('{tmp}\P01201.chm'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/P01204.chm',   ExpandConstant('{tmp}\P01204.chm'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/P04226.chm',   ExpandConstant('{tmp}\P04226.chm'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/P07201.chm',   ExpandConstant('{tmp}\P07201.chm'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/P07260.chm',   ExpandConstant('{tmp}\P07260.chm'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/P07261.chm',   ExpandConstant('{tmp}\P07261.chm'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/HELP/Unitools.chm', ExpandConstant('{tmp}\Unitools.chm'),  'app');
    //layout
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/Clienti.layout.xml.zip',        ExpandConstant('{tmp}\Clienti.layout.xml.zip'       ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/ClientiIncassi.layout.xml.zip', ExpandConstant('{tmp}\ClientiIncassi.layout.xml.zip'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/ClientiPolizze.layout.xml.zip', ExpandConstant('{tmp}\ClientiPolizze.layout.xml.zip'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/Sinistri.layout.xml.zip',       ExpandConstant('{tmp}\Sinistri.layout.xml.zip'      ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/Sopravvenienze.layout.xml.zip', ExpandConstant('{tmp}\Sopravvenienze.layout.xml.zip'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/Perizie.layout.xml.zip',        ExpandConstant('{tmp}\Perizie.layout.xml.zip'       ),  'app');
    //viste
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/vista_andamenti.txt',       ExpandConstant('{tmp}\vista_andamenti.txt'      ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/vista_clienti.txt',         ExpandConstant('{tmp}\vista_clienti.txt'        ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/vista_incarichi.txt',       ExpandConstant('{tmp}\vista_incarichi.txt'      ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/vista_sinistri.txt',        ExpandConstant('{tmp}\vista_sinistri.txt'       ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/vista_polizze.txt',         ExpandConstant('{tmp}\vista_polizze.txt'        ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/vista_PTFcanc.txt',         ExpandConstant('{tmp}\vista_PTFcanc.txt'        ),  'app');
    //varie
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/specifica-tutti.xml.zip',   ExpandConstant('{tmp}\specifica-tutti.xml.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/IndicatoreCliente.layout.xml.zip',   ExpandConstant('{tmp}\IndicatoreCliente.layout.xml.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/IndicatoreCliente.stp.zip',          ExpandConstant('{tmp}\IndicatoreCliente.stp.zip'  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/RichiestaConsap.rtf',       ExpandConstant('{tmp}\RichiestaConsap.rtf'      ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/RichiestaConsapDelega.rtf', ExpandConstant('{tmp}\RichiestaConsapDelega.rtf'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/UniDocs.xml.zip',           ExpandConstant('{tmp}\UniDocs.xml.zip'          ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/ut_wait.html',              ExpandConstant('{tmp}\ut_wait.html'             ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/ut_no_login.html',          ExpandConstant('{tmp}\ut_no_login.html'         ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/VARIE/ut_wait.gif',               ExpandConstant('{tmp}\ut_wait.gif'              ),  'app');
    //assegni
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/4Cheque.dll',                 ExpandConstant('{tmp}\4Cheque.dll'                ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/4cheque.ini.zip',             ExpandConstant('{tmp}\4cheque.ini.zip'            ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/4cheque.mdk.zip',             ExpandConstant('{tmp}\4cheque.mdk.zip'            ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/4ChequeE.mdk.zip',            ExpandConstant('{tmp}\4ChequeE.mdk.zip'           ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/4Cheques.mdk.zip',            ExpandConstant('{tmp}\4Cheques.mdk.zip'           ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/ASLoader.exe',                ExpandConstant('{tmp}\ASLoader.exe'               ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Assegni.exe',                 ExpandConstant('{tmp}\Assegni.exe'                ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Assegni.exe.config.zip ',     ExpandConstant('{tmp}\Assegni.exe.config.zip'     ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/C4Cheque.dll',                ExpandConstant('{tmp}\C4Cheque.dll'               ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Export32.dll',                ExpandConstant('{tmp}\Export32.dll'               ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Export33.dll',                ExpandConstant('{tmp}\Export33.dll'               ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Export34.dll',                ExpandConstant('{tmp}\Export34.dll'               ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/IfWs4ChequeLicense.dll',      ExpandConstant('{tmp}\IfWs4ChequeLicense.dll'     ),  'app');
    //idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Interop.MSHTML.dll',          ExpandConstant('{tmp}\Interop.MSHTML.dll'         ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/joinimg.dll',                 ExpandConstant('{tmp}\joinimg.dll'                ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/mfc80.dll',                   ExpandConstant('{tmp}\mfc80.dll'                  ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Microsoft.VC80.CRT.manifest', ExpandConstant('{tmp}\Microsoft.VC80.CRT.manifest'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/Microsoft.VC80.MFC.manifest', ExpandConstant('{tmp}\Microsoft.VC80.MFC.manifest'),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/msvcm80.dll',                 ExpandConstant('{tmp}\msvcm80.dll'                ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/msvcp80.dll',                 ExpandConstant('{tmp}\msvcp80.dll'                ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/msvcr80.dll',                 ExpandConstant('{tmp}\msvcr80.dll'                ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/scandeco.dll',                ExpandConstant('{tmp}\scandeco.dll'               ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/UtNetUtility32.dll',          ExpandConstant('{tmp}\UtNetUtility32.dll'         ),  'app');
    idpAddFileComp('http://www.utools.it/Unitools/Update/Versioni/600/PROD/ASSEGNI/UtNetUtility33.dll',          ExpandConstant('{tmp}\UtNetUtility33.dll'         ),  'app');

    idpDownloadAfter(wpReady);
end;
