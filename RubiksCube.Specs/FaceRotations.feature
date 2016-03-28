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

Scenario Outline: Top Layer Rotations
	Given a cube with a visible "White" face
	When turns the "First" 'X' layer "<direction>" <times> times
	Then the "Front" face "First" 'X' layer is "<expected_color>"
	
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

Scenario Outline: Bottom Layer Rotations
	Given a cube with a visible "White" face
	When turns the "Third" 'X' layer "<direction>" <times> times
	Then the "Front" face "Third" 'X' layer is "<expected_color>"
	
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

Scenario Outline: Left Layer Rotations
	Given a cube with a visible "White" face
	When turns the "First" 'Y' layer "<direction>" <times> times
	Then the "Front" face "First" 'Y' layer is "<expected_color>"
	
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

Scenario Outline: Right Layer Rotations
	Given a cube with a visible "White" face
	When turns the "Third" 'Y' layer "<direction>" <times> times
	Then the "Front" face "Third" 'Y' layer is "<expected_color>"
	
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

