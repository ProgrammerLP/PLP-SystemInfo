# PLP-SystemInfo

A C# Library for getting several SystemInfos!

# Documentation
Das Package enthält im Namespace ``PLP_SystemInfo`` zwei Klassen um Systeminformationen auszulesen, einmal ``SystemInfo`` und ``ComponentInfo``,
diese Klassen enthälten verschiedene Methoden zum Auslesen von Systeminfos.

## PLP_SystemInfo.SystemInfo
Die Klasse ``SystemInfo`` enthält hauptsächlich nur Methoden um allgemeine Systemwerte auszulesen.
Jede Methode besitzt einen Rückgabewert, welcher die Benutzung vereinfacht.

```cs
using PLP_SystemInfo;

bool b = SystemInfo.IsDarkModeEnabled;
// Gibt ein bool-Wert zurück der Wiederspiegelt ob der Windows Darkmode aktiviert ist

string s = SystemInfo.GetWindowsAccentColor();
// Gibt die Windows Akzentfarbe als HEX-Wert zurück.

Color c = SystemInfo.GetAccentColor();
// Gibt die Windows Akzentfarbe als Color-Wert zurück.
```

## PLP_SystemInfo.ComponentInfo
Die Klasse ``ComponentInfo`` enthält hauptsächlich nur Methoden um die wichtigsten PC-Komponenten auszulesen.
Auch hier besitzt jede Methode einen Rückgabewert für einfache die Verwendung.

```cs
using PLP_SystemInfo;

string s = ComponentInfo.GetOperatingSystemInfo();
// Gibt einen string zurück, der den OS Namen und die Architektur beinhaltet.

string t = ComponentInfo.GetCPUName();
// Gibt einen string zurück, der den CPU Namen enthält.

int i = ComponentInfo.GetCPUThreads();
// Gibt einen Integer zurück, der die Anzahl an Prozessor-Threads benhaltet.

int j = ComponentInfo.GetCPUCores();
// Gibt einen Integer zurück, mit der Anzahl an Prozessorkernen.

long l = ComponentInfo.GetInstalledRAMSize();
// Gibt einen long-Wert zurück, mit der Anzahl an dem Total installierten RAM.

long m = ComponentInfo.GetTotalUsableRam();
// Gibt einen long-Wert zurück, der die Anzahl an insgesamt nutzbaren RAM angibt.

long n = ComponentInfo.GetRamInUse();
// Gibt einen long-Wert zurück, der den belegten Ram angibt.

long o = ComponentInfo.GetAvailableRam();
// Gibt einen long-Wert zurück, der den freien Ram zurück gibt.

string u = ComponentInfo.GetGraphicscardName();
// Gibt einen string zurück, der den Namen der Grafikkarte beinhaltet.

long p = ComponentInfo.GetGraphicscardVRAM();
// Gibt einen long-Wert zurück, der den VRAM der Grafikkarte angibt.
// ACHTUNG: Angabe nur richtig, wenn Grafikkarte mit dem WDDM 2 Treiber kompatibel ist.
```
