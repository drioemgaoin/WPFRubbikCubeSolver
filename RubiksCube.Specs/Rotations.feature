Feature: Rotations

Scenario Outline: Cube Rotations
	Given a new cube with a front white face and a top orange face
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

Scenario Outline: Up Face Rotations
	Given a new cube with a front white face and a top orange face
	When turns the up face "<direction>" <times> times
	Then the "Front" face "First" row is "<front_color>"
		And the "Right" face "First" row is "<right_color>"
		And the "Back" face "First" row is "<back_color>"
		And the "Left" face "First" row is "<left_color>"
	
	Examples:
	| direction        | times | front_color | right_color | back_color | left_color |
	| Clockwise        | 1     | Green       | White       | Blue       | Yellow     |
	| CounterClockwise | 1     | Blue        | Yellow      | Green      | White      |
	| Clockwise        | 2     | Yellow      | Green       | White      | Blue       |
	| CounterClockwise | 2     | Yellow      | Green       | White      | Blue       |
	| Clockwise        | 3     | Blue        | Yellow      | Green      | White      |
	| CounterClockwise | 3     | Green       | White       | Blue       | Yellow     |
	| Clockwise        | 4     | White       | Blue        | Yellow     | Green      |
	| CounterClockwise | 4     | White       | Blue        | Yellow     | Green      |

Scenario Outline: Down Face Rotations
	Given a new cube with a front white face and a top orange face
	When turns the down face "<direction>" <times> times
	Then the "Front" face "Third" row is "<front_color>"
		And the "Right" face "Third" row is "<right_color>"
		And the "Back" face "Third" row is "<back_color>"
		And the "Left" face "Third" row is "<left_color>"
	
	Examples:
	| direction        | times | front_color | right_color | back_color | left_color |
	| Clockwise        | 1     | Green       | White       | Blue       | Yellow     |
	| CounterClockwise | 1     | Blue        | Yellow      | Green      | White      |
	| Clockwise        | 2     | Yellow      | Green       | White      | Blue       |
	| CounterClockwise | 2     | Yellow      | Green       | White      | Blue       |
	| Clockwise        | 3     | Blue        | Yellow      | Green      | White      |
	| CounterClockwise | 3     | Green       | White       | Blue       | Yellow     |
	| Clockwise        | 4     | White       | Blue        | Yellow     | Green      |
	| CounterClockwise | 4     | White       | Blue        | Yellow     | Green      |

Scenario Outline: Left Face Rotations
	Given a new cube with a front white face and a top orange face
	When turns the left face "<direction>" <times> times
	Then the "Front" face "First" column is "<front_color>"
		And the "Up" face "First" column is "<up_color>"
		And the "Back" face "First" column is "<back_color>"
		And the "Down" face "First" column is "<down_color>"
	
	Examples:
	| direction        | times | front_color | up_color | back_color | down_color |
	| Clockwise        | 1     | Orange      | Yellow   | Red        | White      |
	| CounterClockwise | 1     | Red         | White    | Orange     | Yellow     |
	| Clockwise        | 2     | Yellow      | Red      | White      | Orange     |
	| CounterClockwise | 2     | Yellow      | Red      | White      | Orange     |
	| Clockwise        | 3     | Red         | White    | Orange     | Yellow     |
	| CounterClockwise | 3     | Orange      | Yellow   | Red        | White      |
	| Clockwise        | 4     | White       | Orange   | Yellow     | Red        |
	| CounterClockwise | 4     | White       | Orange   | Yellow     | Red        |

Scenario Outline: Right Face Rotations
	Given a new cube with a front white face and a top orange face
	When turns the right face "<direction>" <times> times
	Then the "Front" face "Third" column is "<expected_color>"
	
	Examples:
	| direction			| times | expected_color |
	| Clockwise			| 1     | Red			 |
	| CounterClockwise	| 1     | Orange		 |
	| Clockwise			| 2     | Yellow         |
	| CounterClockwise	| 2     | Yellow         |
	| Clockwise			| 3     | Orange		 |
	| CounterClockwise	| 3     | Red	         |
	| Clockwise			| 4     | White          |
	| CounterClockwise	| 4     | White          |

