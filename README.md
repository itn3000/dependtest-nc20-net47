# tests for failure of resolving dependency

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