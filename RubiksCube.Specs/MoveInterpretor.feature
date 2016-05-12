Feature: MoveInterpretor

Scenario: Interpret solver moves language into rotation list
	Given the moves "L L' R R' F F' B B' U U' D D'"
	When interpret moves 
	Then the list contains a "Left" "Clockwise" rotation
	And the list contains a "Left" "CounterClockwise" rotation 
	And the list contains a "Right" "Clockwise" rotation 
	And the list contains a "Right" "CounterClockwise" rotation 
	And the list contains a "Front" "Clockwise" rotation 
	And the list contains a "Front" "CounterClockwise" rotation 
	And the list contains a "Back" "Clockwise" rotation 
	And the list contains a "Back" "CounterClockwise" rotation 
	And the list contains a "Up" "Clockwise" rotation 
	And the list contains a "Up" "CounterClockwise" rotation 
	And the list contains a "Down" "Clockwise" rotation 
	And the list contains a "Down" "CounterClockwise" rotation 
