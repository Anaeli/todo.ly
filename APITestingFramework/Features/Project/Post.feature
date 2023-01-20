Feature: Create a project

    Scenario: Create a new project with valid parameters and valid authentication
        Given the user is authenticated
        And the request body contains the parameter "Content" with value "Project 1"
        When the user sends a POST request to the "/projects" endpoint
        Then the response should have a status code of 201
        And the response should contain the details of the newly created project

    Scenario: Attempt to create a new project without valid parameters
        Given the user is authenticated
        And the request body does not contain the parameter "Content"
        When the user sends a POST request to the "/projects" endpoint
        Then the response should have a status code of 400
        And the response should contain an error message indicating the parameter "Content" is required

    Scenario: Attempt to create a new project without authentication
        Given the user is not authenticated
        And the request body contains the parameter "Content" with value "Project 1"
        When the user sends a POST request to the "/projects" endpoint
        Then the response should have a status code of 401
        And the response should contain an error message indicating authentication is required
