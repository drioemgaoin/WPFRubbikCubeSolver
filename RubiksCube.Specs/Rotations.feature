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

Scenario Outline: Row Rotations
	Given a cube with a visible "White" face
	When row <position> turns "<direction>" <times> times
	Then row <position> is "<expected_color>"
	
	Examples:
	| position	| direction | times | expected_color |
	| 1			| Right     | 1     | Green          |
	| 1			| Left      | 1     | Blue           |
	| 2			| Right		| 1     | Green			 |
	| 2			| Left		| 1     | Blue			 |
	| 3			| Right     | 1     | Green          |
	| 3			| Left      | 1	    | Blue           |
	| 1			| Right     | 2     | Yellow         |
	| 1			| Left      | 2     | Yellow         |
	| 2			| Right		| 2     | Yellow		 |
	| 2			| Left		| 2     | Yellow		 |
	| 3			| Right     | 2     | Yellow         |
	| 3			| Left      | 2	    | Yellow         |
	| 1			| Right     | 3     | Blue			 |
	| 1			| Left      | 3     | Green          |
	| 2			| Right		| 3     | Blue			 |
	| 2			| Left		| 3     | Green			 |
	| 3			| Right     | 3     | Blue			 |
	| 3			| Left      | 3	    | Green          |
	| 1			| Right     | 4     | White			 |
	| 1			| Left      | 4     | White          |
	| 2			| Right		| 4     | White			 |
	| 2			| Left		| 4     | White			 |
	| 3			| Right     | 4     | White			 |
	| 3			| Left      | 4	    | White          |