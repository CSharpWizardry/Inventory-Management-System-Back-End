Feature: ApplicationHealth
	In order to ensure that the application is health
	As a developer
	I want to ensure the health-checks responses

Scenario: Healthy application
	Given a request must be made
	When a health-check is made
	Then a 200 http status should be returned
	And the response contains the value 'Healthy'