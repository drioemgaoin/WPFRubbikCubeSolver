Introduction
--  
This project was started to develop a solution in the state of the art with Domain Driven Design and Behavioral Driven Design, also known as [Living Documentation] (https://leanpub.com/livingdocumentation). In a quest to master our craft, our goal is to prove complex problems can be solved with simple practices.

A Rubik's cube solver seemed like a good candidate to use these practices with clear but challenging specifications.

As .NET developers, that also seemed like a good introduction to 3D programming to discover unexplored WPF areas. Anyhow, the model and specifications will stay agnostic of the framework to be reusable as we would also like to repeat this exercise with other languages.

This is a work in progress but we are aiming to continuously improve and simplify the solution and let the design emerge while incrementally implementing new specifications.

Features
--  
* 3D rendering
* Keyboard controls
  * Ctrl+M: Mixup the cube
  * L: rotate the left face
  * Shift+L: rotate the left face counter-clockwise
  * R: rotate the left face
  * Shift+R: rotate the left face counter-clockwise
  * U: rotate the up face
  * Shift+U: rotate the up face counter-clockwise
  * D: rotate the down face
  * Shift+D: rotate the down face counter-clockwise
  * F: rotate the front face
  * Shift+F: rotate the front face counter-clockwise
  * B: rotate the back face
  * Shift+B: rotate the back face counter-clockwise
  * X: X axis rotation
  * Shift+X: X axis counter-clockwise rotation
  * Y: Y axis rotation
  * Shift+Y: Y axis counter-clockwise rotation
  * Z: Z axis rotation
  * Shift+Z: Z axis counter-clockwise rotation
* Automatic solving algorithm (WIP)
