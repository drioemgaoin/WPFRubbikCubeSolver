Introduction
--  
This project was started to develop a solution in the state of the art with Domain Driven Design and Behavioral Driven Design, also known as [Living Documentation] (https://leanpub.com/livingdocumentation). Our goal is to prove complex problems can be solved with simple practices.

A Rubik's cube solver seemed like a good candidate to use these practices with clear but challenging specifications in a quest to improve our craft.

As .NET developers, that also seemed like a good introduction to 3D programming to discover unexplored WPF areas. Anyhow, the model and specifications should stay agnostic of the framework to be reusable with any others technologies as we would also like to experiment.

This is a work in progress but we are aiming to continuously improve and simplify the model to let the design emerge while incrementally implementing new specifications.

Features
--  
* 3D rendering
* Keyboard controls
  * Numpad 7: rotate the first row left
  * Numpad 9: rotate the first row right
  * Numpad 4: rotate the second row left
  * Numpad 6: rotate the second row right
  * Numpad 1: rotate the third row left
  * Numpad 3: rotate the third row right
  * Arrow Left: rotate the current face left
  * Arrow Right: rotate the current face right
  * Arrow Up: rotate the current face up
  * Arrow Down: rotate the current face down
  * Q: rotate the first column left
  * Z: rotate the first column right
  * W: rotate the second column left
  * X: rotate the second column right
  * E: rotate the third column left
  * C: rotate the third column right
  * M: mix up the cube
* Mouse rotations (WIP)
* Random facies scrambling (WIP)
* Automatic solving algorithm (WIP)
