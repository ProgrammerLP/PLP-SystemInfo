# PLP-SystemInfo

A C# Library for getting several SystemInfos!

PLP-SystemInfo is compatible with the following frameworks:
- .NET 5 or higher
- .Net Core 2 - 3.1
- .Net Standard 2.0 & 2.1
- .Net Framework 4.6.1 or higher

Dependencies:
- System.Management
- System.Win32

# Download
PLP-SystemInfo is available as a [NuGet Package](https://www.nuget.org/packages/PLP-SystemInfo)

# Documentation
The package contains in the namespace ``PLP_SystemInfo`` two classes for reading system information, ``SystemInfo`` and ``ComponentInfo``,
these classes contain different methods for reading system information.

## PLP_SystemInfo.SystemInfo
The class ``SystemInfo`` contains mainly methods to read general system values.
Each method has a return value which simplifies the usage.

``cs
using PLP_SystemInfo;

bool b = SystemInfo.IsDarkModeEnabled;
// Returns a bool value that reflects whether the Windows darkmode is enabled

string s = SystemInfo.GetWindowsAccentColor();
// Returns the Windows accent color as HEX value.

Color c = SystemInfo.GetAccentColor();
// Returns the Windows accent color as a Color value.
```

## PLP_SystemInfo.ComponentInfo
The class ``ComponentInfo`` contains mainly only methods to read out the most important PC components.
Again, each method has a return value for simple usage.

``cs
using PLP_SystemInfo;

string s = ComponentInfo.GetOperatingSystemInfo();
// Returns a string containing the OS name and architecture.

string t = ComponentInfo.GetCPUName();
// Returns a string containing the CPU name.

int i = ComponentInfo.GetCPUThreads();
// Returns an integer containing the number of processor threads.

int j = ComponentInfo.GetCPUCores();
// Returns an integer containing the number of processor cores.

long l = ComponentInfo.GetInstalledRAMSize();
// Returns a long value with the number of the total installed RAM.

long m = ComponentInfo.GetTotalUsableRam();
// Returns a long value with the total amount of usable RAM.

long n = ComponentInfo.GetRamInUse();
// Returns a long value that indicates the amount of used RAM.

long o = ComponentInfo.GetAvailableRam();
// Returns a long value indicating the free Ram.

string u = ComponentInfo.GetGraphicscardName();
// Returns a string containing the name of the graphics card.

long p = ComponentInfo.GetGraphicscardVRAM();
// Returns a long value that specifies the VRAM of the graphics card.
// ATTENTION: Only correct if the graphics card is compatible with the WDDM 2 driver.
```

# License
This software is released under the [Apache 2.0 license](https://github.com/ProgrammerLP/PLP-SystemInfo/blob/master/LICENSE.txt)
