Feature: Vehicle Permit Registration
Unregistered vehicle registration

@Browser:Chrome
Scenario Outline: Verify Unregistered vehicle permit registration step two page has select permit type displayed 
	Given the user is on unregistered vehicle permit registration page
	When the user enters the <Vehicle Type> and other details
	And the user is able to view permit date based on permit duration and calculate fees
	And the user navigates to step two of permit registration
	Then the select permit type is displayed on step two of vehicle registration

	Examples:
		| Vehicle Type           |
		| Passenger vehicle      |
		| Goods carrying vehicle |
		| Prime Mover            |
		| Motorcycle             |
		| Trailer/Caravan        |