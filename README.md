# ChaiTea
ChaiTea is a library that exposes the haptic framework Chai3D to the game engine Unity3D. 

Examples of using ChaiTea in Unity can be found [here](https://github.com/Mads-MA/ChaiTea-Examples).

# Building
ChaiTea depends on [Chai3D](https://www.chai3d.org/) and [UnityCsReference](https://github.com/Unity-Technologies/UnityCsReference).
These are included as submodules, but still need to be built.

## Chai3d
Open CHAI3D-VS2015.sln in ./external/chai3d
For each project you may need to change the project property "Platform Toolset" to "Visual Studio 2022 (v143)" under General Properties.

Now build both Release and Debug targets with x64.

## UnityCsReference
You will also need to build this dependency. 
Open the C# solution is in Projects/CSharp/UnityReferenceSource.sln and build it. 

