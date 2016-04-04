@echo off
echo Copying plugin...
xcopy "VAExtensions\bin\Release\*.dll" "%PROGRAMFILES(x86)%\VoiceAttack\Apps\VAExtensions" /C /F /Y
xcopy "VAExtensions\bin\Release\*.xml" "%PROGRAMFILES(x86)%\VoiceAttack\Apps\VAExtensions" /C /F /Y
echo -=-=-=-=-=-=-=-=-=-=-=-
echo Copying sample data...
xcopy "VAExtensions\bin\Release\TestData\*.*" "%PROGRAMFILES(x86)%\VoiceAttack\Apps\VAExtensions\TestData" /C /F /Y
echo -=-=-=-=-=-=-=-=-=-=-=-
echo Copying sample profiles...
xcopy "VAExtensions\Profiles\*.*" "%PROGRAMFILES(x86)%\VoiceAttack\Apps\VAExtensions\Profiles" /C /F /Y
echo -=-=-=-=-=-=-=-=-=-=-=-
echo Launching VoiceAttack...
pause
start "" "%PROGRAMFILES(x86)%\VoiceAttack\VoiceAttack.exe" -listeningoff -joysticksoff