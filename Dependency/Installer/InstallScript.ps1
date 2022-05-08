# Get the ID and security principal of the current user account
if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Start-Process PowerShell -Verb RunAs "-NoProfile -ExecutionPolicy Bypass -Command `"cd '$pwd'; & '$PSCommandPath';`"";
    exit;
}
$InstallDirectory = "C:\Program Files\Note"
$StartMenuPath = "$ENV:APPDATA\Microsoft\Windows\Start Menu\Programs"
$ShortcutPath = "$StartMenuPath\Note.lnk"

Write-Output "Installing..."

Write-Output "Copy app to Program Files..."
Robocopy.exe /S '.\App' $InstallDirectory

Write-Output "Install missing dependencies..."
$IsRuntimeExist = powershell -c "get-appxpackage *appruntime*" | Select-String "WindowsAppRuntime.1.1-preview2_1000.468.658.0_x64"
if($null -eq $IsRuntimeExist)
{
    .\WindowsAppRunTimeInstall.exe
}

Write-Output "Create start menu shortcut..."
if([System.IO.File]::Exists($ShortcutPath) -eq $false)
{
    $WshShell = New-Object -comObject WScript.Shell
    $Shortcut = $WshShell.CreateShortcut($ShortcutPath)
    $Shortcut.TargetPath = "$InstallDirectory\Note.exe"
    $Shortcut.Save()
}

Write-Output "Installation complete. (Press enter to exit)"
[System.Console]::ReadKey()
