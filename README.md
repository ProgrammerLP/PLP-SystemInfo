# PLP-SystemInfo

A C# Library for getting several SystemInfos!

# Documentation
Das Package enthält im Namespace ``PLP_SystemInfo`` zwei Klassen um Systeminformationen auszulesen, einmal ``SystemInfo`` und ``ComponentInfo``,
diese Klassen enthälten verschiedene Methoden zum Auslesen von Systeminfos.

## PLP_SystemInfo.SystemInfo
Die Klasse ``SystemInfo`` enthält hauptsächlich nur Methoden um allgemeine Systemwerte auszulesen.
Jede Methode besitzt einen Rückgabewert, welcher die Benutzung vereinfacht.

```cs
bool b = SystemInfo.IsDarkModeEnabled;
// Gibt ein bool-Wert zurück der Wiederspiegelt ob der Windows Darkmode aktiviert ist

string s = SystemInfo.GetWindowsAccentColor();
// Gibt die Windows Akzentfarbe als HEX-Wert zurück.

Color c = SystemInfo.GetAccentColor();
// Gibt die Windows Akzentfarbe als Color-Wert zurück.
```
