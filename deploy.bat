
set H=R:\KSP_1.3.1_dev
echo %H%

copy SensiblePumps\bin\Debug\SensiblePumps.dll D:\Users\jbb\github\SensiblePumps\GameData\SensiblePumpsCont\Plugins
copy install-sensible-pumps.cfg D:\Users\jbb\github\SensiblePumps\GameData\SensiblePumpsCont

mkdir %H%\GameData\SensiblePumpsCont
xcopy GameData\SensiblePumpsCont %H%\GameData\SensiblePumpsCont\  /E /Y
