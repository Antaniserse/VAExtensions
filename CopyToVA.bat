@echo off
echo Copying plugin...
xcopy "VAExtensions\bin\Release" "%PROGRAMFILES(x86)%\VoiceAttack\Apps\VAExtensions" /C /F /Y /S /I
echo -=-=-=-=-=-=-=-=-=-=-=-
echo Copying sample profiles...
xcopy "VAExtensions\Profiles\*.*" "%PROGRAMFILES(x86)%\VoiceAttack\Apps\VAExtensions\Profiles" /C /F /Y
echo -=-=-=-=-=-=-=-=-=-=-=-
echo Launching VoiceAttack...
pause
start "" "%PROGRAMFILES(x86)%\VoiceAttack\VoiceAttack.exe" -listeningoff -joysticksoff