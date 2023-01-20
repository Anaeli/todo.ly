Feature: Retrieve a project by id

    Scenario: Retrieve a specific project with valid ID and valid authentication
        Given the user is authenticated
        And the project with ID "1" exists
        When the user sends a GET request to the "/projects/1" endpoint
        Then the response should have a status code of 200
        And the response should contain the details of the project with ID "1"

    Scenario: Attempt to retrieve a project with invalid ID
        Given the user is authenticated
        When the user sends a GET request to the "/projects/9999" endpoint
        Then the response should have a status code of 404
        And the response should contain an error message indicating the project was not found

    Scenario: Attempt to retrieve a specific project with valid ID but without authentication
        Given the user is not authenticated
        And the project with ID "1" exists
        When the user sends a GET request to the "/projects/1" endpoint
        Then the response should have a status code of 401
        And the response should contain an error message indicating authentication is required
