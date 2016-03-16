Feature: Rotations

Scenario: Face Rotations
	Given a cube with a visible "White" face
	When the cube turns "Right" 1 times
	Then then the "Green" face is visible
	