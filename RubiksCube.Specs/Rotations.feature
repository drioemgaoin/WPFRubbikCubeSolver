Feature: Rotations

Scenario Outline: Face Rotations
	Given a cube with a visible "<initial_color>" face
	When the cube turns "<direction>" <times> times
	Then then the "<expected_color>" face is visible
	
	Examples:
	| initial_color | direction | times | expected_color |
	| White         | Right     | 1     | Green          |