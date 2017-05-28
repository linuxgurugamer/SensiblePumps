
rem copy /Y "$(TargetDir)$(TargetFileName)" "D:\Users\jbb\github\KerbalObjectInspector\KerbalObjectInspector\Plugins\$(TargetFileName)"

rem copy /Y "D:\Users\jbb\github\KerbalObjectInspector\Source\KerbalObjectInspector\README.txt" "D:\Users\jbb\github\KerbalObjectInspector\KerbalObjectInspector\README.txt"

rem copy /Y "D:\Users\jbb\github\KerbalObjectInspector\KerbalObjectInspector\README.txt" "D:\Users\jbb\github\KerbalObjectInspector\README.md"

rem copy /Y "$(TargetDir)$(TargetFileName)" "D:\Users\jbb\github\KerbalObjectInspector\KerbalObjectInspector\Plugins\$(TargetFileName)"


set H=R:\KSP_1.3.0_dev
echo %H%

copy SensiblePumps\bin\Debug\SensiblePumps.dll D:\Users\jbb\github\SensiblePumps\GameData\SensiblePumpsCont\Plugins
copy install-sensible-pumps.cfg D:\Users\jbb\github\SensiblePumps\GameData\SensiblePumpsCont

mkdir %H%\GameData\SensiblePumpsCont
xcopy GameData\SensiblePumpsCont %H%\GameData\SensiblePumpsCont\  /E /Y
