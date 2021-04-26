Demo project how to create your own scene, camera and display it on the screen

Main render loop & the most important part is in CameraProjectionDemo.cs

In the project you can find the "virtual" scene. Here you can stage your scene and camera.
Here there's no rendering logic needed, you can even remove the mesh renderer component.

![](https://i.imgur.com/FtZOPVX.gif)


For each Virtual object, the mesh vertices then will be projected onto ortographic camera surface then triangles will be rebuild and drawn onto the surface of ortho camera.

![](https://i.imgur.com/Aup3XXy.gif)

You can even preview the result in game window!
Do not forget to enable the Gizmos rendering in game otherwise the screen will be black!

![](https://i.imgur.com/v31kJx2.gif)
