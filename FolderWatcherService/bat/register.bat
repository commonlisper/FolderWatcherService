@echo OFF

set DOTNET = %SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\
set PATH = %PATH%;%DOTNET%

echo register FolderWatcher Service...
echo ------------------------------------------------------
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil /i "%~dp0FolderWatcherService.exe"
net start FolderWatcherService
services.msc
echo ------------------------------------------------------

echo Done!	