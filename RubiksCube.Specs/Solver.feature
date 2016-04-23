Feature: Solver
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: White Cross
	Given a solver
	And a scrambled cube 
	And the "Up" center facie is "Orange"
	And the "Front" center facie is "White"
	When ask the solver to resolve the cube
	Then the "Front" face facie #2 is "White"
	And the "Front" face facie #4 is "White"
	And the "Front" face facie #6 is "White"
	And the "Front" face facie #8 is "White"
	And the "Left" face facie #6 is "Green"
	And the "Right" face facie #4 is "Blue"
	And the "Up" face facie #8 is "Orange"
	And the "Down" face facie #8 is "Red"