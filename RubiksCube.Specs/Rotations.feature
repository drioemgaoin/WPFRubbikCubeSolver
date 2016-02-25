Feature: Cube Rotation

Scenario: Face Rotations
	Given a cube with a visable "white" face
	When the cube turns "right" 1
	Then then the "green" face is visible
	