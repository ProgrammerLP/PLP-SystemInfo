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
Again, each method has a return value for simple usage.

```cs
using PLP_SystemInfo.ComponentInfo;

Board b = BoardInfo.GetMotherboard();
// Returns an object of type **Board** with manufacturer and model.

BIOS bios = BoardInfo.GetBIOSInfo();
// Returns an object of type **BIOS** with manufacturer and version.

string os = OSInfo.GetOperatingSystemInfo();
// Returns a string with OS name and architecture.

ProcessorCollection processors = ProcessorInfo.GetProcessors();
// Returns a collection of type **Processor** containing information such as name, architecture, cores, threads, cache and clock speed.

RamCollection rams = RamInfo.GetRamInfo();
// Returns a collection of type **RAM** containing information for each installed ram module such as manufacturer, frequency, voltage and capacity.

long ram = RamInfo.GetInstalledRAMSize();
// Returns a long value of the installed GB of RAM.

GraphicsCollection graphics = GraphicsInfo.GetGraphicscardInfo();
// Returns a collection of type **GraphicsCard** containing information such as name and driver version.
```

To get the information from the collections, simply use a foreach loop, e.g:
```cs
foreach (var item in ram) //ram is a **RamCollection** from the example above
{
  Console.WriteLine(item.Manufacturer);
}
```

# License
This software is released under the [Apache 2.0 license](https://github.com/ProgrammerLP/PLP-SystemInfo/blob/master/LICENSE.txt)
