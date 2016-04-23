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
	| Clockwise        | 1     | Blue        | Yellow      | Green      | White      |
	| CounterClockwise | 1     | Green       | White       | Blue       | Yellow     |
	| Clockwise        | 2     | Yellow      | Green       | White      | Blue       |
	| CounterClockwise | 2     | Yellow      | Green       | White      | Blue       |
	| Clockwise        | 3     | Green       | White       | Blue       | Yellow     |
	| CounterClockwise | 3     | Blue        | Yellow      | Green      | White      |
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
	Then the "Front" face "Third" column is "<front_color>"
		And the "Up" face "Third" column is "<up_color>"
		And the "Back" face "Third" column is "<back_color>"
		And the "Down" face "Third" column is "<down_color>"
	
	Examples:
	| direction        | times | front_color | up_color | back_color | down_color |
	| Clockwise        | 1     | Red         | White    | Orange     | Yellow     |
	| CounterClockwise | 1     | Orange      | Yellow   | Red        | White      |
	| Clockwise        | 2     | Yellow      | Red      | White      | Orange     |
	| CounterClockwise | 2     | Yellow      | Red      | White      | Orange     |
	| Clockwise        | 3     | Orange      | Yellow   | Red        | White      |
	| CounterClockwise | 3     | Red         | White    | Orange     | Yellow     |
	| Clockwise        | 4     | White       | Orange   | Yellow     | Red        |
	| CounterClockwise | 4     | White       | Orange   | Yellow     | Red        |

Scenario Outline: Front Face Rotations
	Given a new cube with a front white face and a top orange face
	When turns the front face "<direction>" <times> times
	Then the "Left" face "Third" column is "<left_color>"
		And the "Up" face "Third" row is "<up_color>"
		And the "Right" face "First" column is "<right_color>"
		And the "Down" face "Third" row is "<down_color>"
	
	Examples:
	| direction        | times | left_color | up_color | right_color | down_color |
	| Clockwise        | 1     | Red        | Green    | Orange      | Blue       |
	| CounterClockwise | 1     | Orange     | Blue     | Red         | Green      |
	| Clockwise        | 2     | Blue       | Red      | Green       | Orange     |
	| CounterClockwise | 2     | Blue       | Red      | Green       | Orange     |
	| Clockwise        | 3     | Orange     | Blue     | Red         | Green      |
	| CounterClockwise | 3     | Red        | Green    | Orange      | Blue       |
	| Clockwise        | 4     | Green      | Orange   | Blue		 | Red        |
	| CounterClockwise | 4     | Green      | Orange   | Blue		 | Red        |

Scenario Outline: Back Face Rotations
	Given a new cube with a front white face and a top orange face
	When turns the back face "<direction>" <times> times
	Then the "Left" face "First" column is "<left_color>"
		And the "Up" face "First" row is "<up_color>"
		And the "Right" face "Third" column is "<right_color>"
		And the "Down" face "First" row is "<down_color>"
	
	Examples:
	| direction        | times | left_color | up_color | right_color | down_color |
	| Clockwise        | 1     | Orange     | Blue	   | Red		 | Green      |
	| CounterClockwise | 1     | Red		| Green    | Orange      | Blue       |
	| Clockwise        | 2     | Blue       | Red      | Green       | Orange     |
	| CounterClockwise | 2     | Blue       | Red      | Green       | Orange     |
	| Clockwise        | 3     | Red        | Green    | Orange      | Blue       |
	| CounterClockwise | 3     | Orange     | Blue     | Red         | Green      |
	| Clockwise        | 4     | Green      | Orange   | Blue		 | Red        |
	| CounterClockwise | 4     | Green      | Orange   | Blue		 | Red        |
