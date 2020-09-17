Feature: CategoryController
	In order to ensure that categories can be processed
	As a requester
	I want to be able to get and send categories to the software

Scenario: Should consume categories
	Given a request must be made
	When the request is made to the 'Category' endpoint
	Then a 200 http status should be returned