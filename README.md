# ChaiTea

# Dependencies
Dependencies are included as GIT submodules.

## Chai3d
You must compile Chai3D from scratch. 
To do this you will need to open CHAI3D-VS2015.sln. 
You must edit project properties of each project in this solution. 
It may ask you to do this when you open the solution. Otherwise do as said below.
For ease of doing this, select all projects and then right click on these.
This will open a page with "General Properties", here you must select "Visual Studio 2022 (v143)" under "Platform Toolset".

Now build both Release and Debug targets with x64.

## UnityCSReference
You will also need to build this dependency. 
The C# solution is in Projects/CSharp/UnityReferenceSource.sln