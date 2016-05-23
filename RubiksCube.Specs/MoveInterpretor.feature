Feature: MoveInterpretor

Scenario: Interpret solver moves language into rotation list
	Given the moves "L L2 L' L2' R R2 R' R2' F F2 F' F2' B B2 B' B2' U U2 U' U2' D D2 D' D2'"
	When interpret moves 
	Then the list contains a "Left" "Clockwise" rotation
	Then the list contains a "Left" twice "Clockwise" rotation
	And the list contains a "Left" "CounterClockwise" rotation 
	And the list contains a "Left" twice "CounterClockwise" rotation 
	And the list contains a "Right" "Clockwise" rotation  
	And the list contains a "Right" twice "Clockwise" rotation  
	And the list contains a "Right" "CounterClockwise" rotation  
	And the list contains a "Right" twice "CounterClockwise" rotation  
	And the list contains a "Front" "Clockwise" rotation  
	And the list contains a "Front" twice "Clockwise" rotation  
	And the list contains a "Front" "CounterClockwise" rotation
	And the list contains a "Front" twice "CounterClockwise" rotation  
	And the list contains a "Back" "Clockwise" rotation  
	And the list contains a "Back" twice "Clockwise" rotation  
	And the list contains a "Back" "CounterClockwise" rotation  
	And the list contains a "Back" twice "CounterClockwise" rotation  
	And the list contains a "Up" "Clockwise" rotation  
	And the list contains a "Up" twice "Clockwise" rotation  
	And the list contains a "Up" "CounterClockwise" rotation  
	And the list contains a "Up" twice "CounterClockwise" rotation  
	And the list contains a "Down" "Clockwise" rotation  
	And the list contains a "Down" twice "Clockwise" rotation  
	And the list contains a "Down" "CounterClockwise" rotation  
	And the list contains a "Down" twice "CounterClockwise" rotation  
