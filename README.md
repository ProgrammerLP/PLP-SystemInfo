# PLP-SystemInfo

A C# Library for getting several SystemInfos!
<img alt="NuGet Downloads" src="https://img.shields.io/nuget/dt/PLP-SystemInfo">


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
The package contains in the namespace ``PLP_SystemInfo`` one class for reading system information, ``SystemInfo.cs`` and 3 more namespaces: ``Collections``, ``ComponentInfo`` and ``Models``,
The namespaces ``Collections`` and ``Models`` are largely ignored for use. They only provide the corresponding classes for the outputs.

## PLP_SystemInfo.SystemInfo
The class ``SystemInfo`` contains mainly methods to read general system values.
Each method has a return value which simplifies the usage.

```cs
using PLP_SystemInfo;

string userName = SystemInfo.UserName;
//Retruns the username of the current user

string machineName = SystemInfo.MachineName;
//Retruns the name of the machine.

bool b = SystemInfo.IsDarkModeEnabled;
// Returns a bool value that reflects whether the Windows darkmode is enabled

string s = SystemInfo.GetWindowsAccentColor();
// Returns the Windows accent color as HEX value.

Color c = SystemInfo.GetAccentColor();
// Returns the Windows accent color as a Color value.
```

## PLP_SystemInfo.ComponentInfo.*
The namespace ``PLP_SystemInfo.ComponentInfo`` contains different classes to read out the most important PC components.

### BoardInfo.cs
```cs
using PLP_SystemInfo.ComponentInfo;
using PLP_SystemInfo.Models;

Board b = BoardInfo.GetMotherboard();
// Returns an object of type **Board** with manufacturer and model.

BIOS bios = BoardInfo.GetBIOSInfo();
// Returns an object of type **BIOS** with manufacturer and version.
```


### OSInfo.cs
```cs
using PLP_SystemInfo.ComponentInfo;

string os = OSInfo.GetOperatingSystemInfo();
// Returns a string with OS name and architecture.
```

### ProcessorInfo.cs
```cs
using PLP_SystemInfo.ComponentInfo;
using PLP_SystemInfo.Collections;

ProcessorCollection processors = ProcessorInfo.GetProcessors();
// Returns a collection of type **Processor** containing information such as name, architecture, cores, threads, cache and clock speed.
```

### RamInfo.cs
```cs
using PLP_SystemInfo.ComponentInfo;
using PLP_SystemInfo.Collections;

RamCollection ram = RamInfo.GetRamInfo();
// Returns a collection of type **RAM** containing information for each installed ram module such as manufacturer, frequency, voltage and capacity.

long totalRam = RamInfo.GetInstalledRAMSize();
// Returns a long value of the installed GB of RAM.

double d1 = RamInfo.GetTotalUsableRam();
// Returns the total useable ram in GB.

double d2 = RamInfo.GetHardwareReservedRam();
// Returns the harware reserved ram in MB.

double d3 = RamInfo.GetRamInUse();
// Returns the used ram in GB.

double  d4 = RamInfo.GetAvailableRam();
// Returns the available ram.
```

### GraphicsInfo.cs
```cs
using PLP_SystemInfo.ComponentInfo;
using PLP_SystemInfo.Collections;

GraphicsCollection graphics = GraphicsInfo.GetGraphicscardInfo();
// Returns a collection of type **GraphicsCard** containing information such as name and driver version.
```

To get the information from the collections, simply use a foreach loop, e.g:
```cs
foreach (var item in <yourCollection>)
{
  Console.WriteLine(item.<Property>);
}
```

# License
This software is released under the [Apache 2.0 license](https://github.com/ProgrammerLP/PLP-SystemInfo/blob/master/LICENSE.txt)
