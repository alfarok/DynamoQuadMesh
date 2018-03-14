# DynamoQuadMesh

This example project includes a `CustomMeshRendering` class that inherits from `IGraphicItem` to display mesh Quads with edges.  Each quad is comprised of 2 triangles in HelixToolkit (a wrapper on DirectX).

## Building
- Open solution in Visual Studio
- Build (should automatically restore Dynamo NuGet dependecies)
- Import C:\PROJECTLOCATION\CustomMeshRendering\CustomMeshRendering\bin\Debug\\`CustomMeshRendering.dll` in Dynamo 2.0

## Notes
This example is built against Dynamo 2.0.  If you would like to import the example into an older version of Dynamo you must modify the NuGet packages to match the version of Dynamo you wish to use.

Steps in Visual Studio:
- Tools
- NuGet Package Mangers
- Manage NuGet Packages for Solution
- Go to the `Installed` tab
- Modify `Dynamo Services` and `ZeroTouch` library versions
