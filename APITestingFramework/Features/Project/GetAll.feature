Feature: Retrieve all projects

    Scenario: Retrieve all projects with valid authentication
        Given the user is authenticated
        When the user sends a GET request to the "/projects" endpoint
        Then the response should have a status code of 200
        And the response should contain a list of all projects

    Scenario: Attempt to retrieve all projects without authentication
        Given the user is not authenticated
        When the user sends a GET request to the "/projects" endpoint
        Then the response should have a status code of 401
        And the response should contain an error message indicating authentication is required
