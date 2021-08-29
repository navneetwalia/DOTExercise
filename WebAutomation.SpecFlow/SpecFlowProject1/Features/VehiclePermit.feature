Feature: Vehicle Permit Registration
Unregistered vehicle registration
@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@Browser:Chrome
Scenario: Verify Unregistered vehicle permit registration page has select permit type is displayed
	Given the user is on unregistered vehicle permit registration page