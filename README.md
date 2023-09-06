# MyRevitPlugin
sample project for a revit plugin using the RevitAPI

# Manifest file
Read automatically by Revit when they are placed in one of two locations
All files named .addin in these locations will be read and processed by Revit during startup.

In a non-user-specific location in "ProgramData":
```
C:\ProgramData\Autodesk\Revit\Addins\{VERSION}\
```
In a user-specific location in "AppData":
```
C:\Users\{USER}\AppData\Roaming\Autodesk\Revit\Addins\{VERSION}\
```
# Build
Set the assembly location inside the Manifest file
(If put in the same Directory the relative path from the Manifest file is sufficient)
```
<Assembly>MyRevitPlugin/MyRevitPlugin.dll</Assembly>
```
Set the output path to the location specified in the addin Manifest

# Debug
Set Start external program to
```
C:\Program Files\Autodesk\Revit {VERSION}\Revit.exe
```
(optional)
Set command line arguments:
```
/nosplash
..\MyDebugProject.rvt
```
