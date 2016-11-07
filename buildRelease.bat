@echo off
set DEFHOMEDRIVE=d:
set DEFHOMEDIR=%DEFHOMEDRIVE%%HOMEPATH%
set HOMEDIR=
set HOMEDRIVE=%CD:~0,2%

set RELEASEDIR=d:\Users\jbb\release
set ZIP="c:\Program Files\7-zip\7z.exe"
echo Default homedir: %DEFHOMEDIR%

rem set /p HOMEDIR= "Enter Home directory, or <CR> for default: "

if "%HOMEDIR%" == "" (
set HOMEDIR=%DEFHOMEDIR%
)
echo %HOMEDIR%

SET _test=%HOMEDIR:~1,1%
if "%_test%" == ":" (
set HOMEDRIVE=%HOMEDIR:~0,2%
)

type SensiblePumpsCont.version
set /p VERSION= "Enter version: "

set d=%HOMEDIR\install
if exist %d% goto one
mkdir %d%
:one
set d=%HOMEDIR%\install\Gamedata
if exist %d% goto two
mkdir %d%
:two

rmdir /s /q %HOMEDIR%\install\Gamedata\SensiblePumpsCont

copy SensiblePumps\bin\Release\SensiblePumpsCont.dll GameData\SensiblePumpsCont\Plugins
copy  SensiblePumpsCont.version GameData\SensiblePumpsCont\SensiblePumpsCont.version
copy /Y README.md GameData\SensiblePumpsCont

xcopy /Y /E GameData\SensiblePumpsCont  %HOMEDIR%\install\Gamedata\SensiblePumpsCont\
copy /y LICENSE.md %HOMEDIR%\install\Gamedata\SensiblePumpsCont
copy /y ..\MiniAVC.dll %HOMEDIR%\install\GameData\SensiblePumpsCont

%HOMEDRIVE%
cd %HOMEDIR%\install

set FILE="%RELEASEDIR%\SensiblePumpsCont-%VERSION%.zip"
IF EXIST %FILE% del /F %FILE%
%ZIP% a -tzip %FILE% GameData\SensiblePumpsCont 
