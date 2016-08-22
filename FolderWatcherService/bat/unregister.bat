@echo OFF

set DOTNET = %SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\
set PATH = %PATH%;%DOTNET%

echo unregister FolderWatcher Service...
echo ------------------------------------------------------
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil /u "%~dp0FolderWatcherService.exe"
services.msc
echo ------------------------------------------------------

echo Done!