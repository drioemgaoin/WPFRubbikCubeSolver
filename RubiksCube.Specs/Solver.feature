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
	Then the "Front" face "MiddleUp" facie is "White"
	And the "Front" face "LeftMiddle" facie is "White"
	And the "Front" face "RightMiddle" facie is "White"
	And the "Front" face "MiddleDown" facie is "White"
	And the "Left" face "RightMiddle" facie is "Green"
	And the "Right" face "LeftMiddle" facie is "Blue"
	And the "Up" face "MiddleDown" facie is "Orange"
	And the "Down" face "MiddleDown" facie is "Red"