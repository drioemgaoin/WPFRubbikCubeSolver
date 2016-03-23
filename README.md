# WPFRubbikCubeSolverOverview
--  
The project was started to develop a solution in state of the art with DDD and SpecFlow for BDD. Our goal is to prove complex problems can be solved with simple practices.

A Rubik's cube solvers a seemed like a good candidate to implement these practices with clear but still complex specifications.

As enterprise .NET and WPF developers, that also seemed like a good introduction to 3D programming for discovering unexplored WPF areas. Anyhow, the model and specifications should stay agnostic of the technologies so it could be reused with any others ones as we would also like to experiment.

This is a work in progress but we are aiming to incrementally improve and simplify the implementation while incrementally developing new specifications.

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
* Random facies scrambling (WIP)
* Automatic solving algorithm (WIP)
