Feature: CategoryController
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Should consume the temporary weather forecast endpoint
	Given a request must be made
	When the request is made to the endpoint
	Then a 200 http status should be returned