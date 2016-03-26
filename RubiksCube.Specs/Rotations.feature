Feature: Rotations

Scenario Outline: Face Rotations
	Given a cube with a visible "White" face
	When the cube turns "<direction>" <times> times
	Then the "<expected_color>" face is visible
	
	Examples:
	| direction | times | expected_color |
	| Right     | 1     | Green          |
	| Up        | 1     | Red            |
	| Left      | 1     | Blue           |
	| Down      | 1     | Orange         |
	| Right     | 2     | Yellow         |
	| Up        | 2     | Yellow         |
	| Left      | 2     | Yellow         |
	| Down      | 2     | Yellow         |
	| Right     | 3     | Blue           |
	| Up        | 3     | Orange         |
	| Left      | 3     | Green          |
	| Down      | 3     | Red            |
	| Right     | 4     | White          |
	| Up        | 4     | White          |
	| Left      | 4     | White          |
	| Down      | 4     | White          |

Scenario Outline: Top Face Rotations
	Given a cube with a visible "White" face
	When turns the top face in "<direction>" <times> times
	Then top row is "<expected_color>"
	
	Examples:
	| direction			| times | expected_color |
	| Clockwise			| 1     | Blue		     |
	| CounterClockwise	| 1     | Green          |
	| Clockwise			| 2     | Yellow         |
	| CounterClockwise	| 2     | Yellow         |
	| Clockwise			| 3     | Green          |
	| CounterClockwise	| 3     | Blue           |
	| Clockwise			| 4     | White          |
	| CounterClockwise	| 4     | White          |

Scenario Outline: Bottom Face Rotations
	Given a cube with a visible "White" face
	When turns the bottom face in "<direction>" <times> times
	Then bottom row is "<expected_color>"
	
	Examples:
	| direction			| times | expected_color |
	| Clockwise			| 1     | Blue		     |
	| CounterClockwise	| 1     | Green          |
	| Clockwise			| 2     | Yellow         |
	| CounterClockwise	| 2     | Yellow         |
	| Clockwise			| 3     | Green          |
	| CounterClockwise	| 3     | Blue           |
	| Clockwise			| 4     | White          |
	| CounterClockwise	| 4     | White          |

Scenario Outline: Left Face Rotations
	Given a cube with a visible "White" face
	When turns the left face in "<direction>" <times> times
	Then left column is "<expected_color>"
	
	Examples:
	| direction			| times | expected_color |
	| Clockwise			| 1     | Orange		 |
	| CounterClockwise	| 1     | Red			 |
	| Clockwise			| 2     | Yellow         |
	| CounterClockwise	| 2     | Yellow         |
	| Clockwise			| 3     | Red			 |
	| CounterClockwise	| 3     | Orange         |
	| Clockwise			| 4     | White          |
	| CounterClockwise	| 4     | White          |

Scenario Outline: Right Face Rotations
	Given a cube with a visible "White" face
	When turns the right face in "<direction>" <times> times
	Then right column is "<expected_color>"
	
	Examples:
	| direction			| times | expected_color |
	| Clockwise			| 1     | Orange		 |
	| CounterClockwise	| 1     | Red			 |
	| Clockwise			| 2     | Yellow         |
	| CounterClockwise	| 2     | Yellow         |
	| Clockwise			| 3     | Red			 |
	| CounterClockwise	| 3     | Orange         |
	| Clockwise			| 4     | White          |
	| CounterClockwise	| 4     | White          |