# tests for failure of resolving dependency

this repository is tested on following environment
```
.NET Command Line Tools (2.0.0-preview1-005977)

Product Information:
 Version:            2.0.0-preview1-005977
 Commit SHA-1 hash:  414cab8a0b

Runtime Environment:
 OS Name:     Windows
 OS Version:  6.3.9600
 OS Platform: Windows
 RID:         win81-x64
 Base Path:   C:\Program Files\dotnet\sdk\2.0.0-preview1-005977\

Microsoft .NET Core Shared Framework Host

  Version  : 2.0.0-preview1-002111-00
  Build    : 1ff021936263d492539399688f46fd3827169983

```

## description of projects

* Lib.A,Lib.B
    * same assembly name
* Lib.C
    * depends on Lib.A
* App.OK
    * this project depends on Lib.A and Lib.B
    * PackageReference order is Lib.A -> Lib.B
    * compilation of net47 and netcoreapp2.0 are OK
* App.NG
    * this project depends on Lib.A and Lib.B
    * PackageReference order is Lib.B -> Lib.A
    * compilation of net47 is OK, but failed on netcoreapp2.0
* App.NG.Dep
    * this project depends on Lib.B and Lib.C
    * compilation of net47 is OK, but failed on netcoreapp2.0
    * PackageReference order is not affected to result.

## program output

|project name|output                      |
|------------|----------------------------|
|App.OK      |prop=Y(netcoreapp2.0==net47)|
|App.NG      |prop=X                      |
|App.NG.Dep  |prop=Y                      |
