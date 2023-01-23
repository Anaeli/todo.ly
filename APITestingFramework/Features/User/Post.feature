Feature: User Creation
    As a non authenticated user, I want to be able to create a new user account so that I can access to app's features.

    Scenario: Create a new user
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a valid JSON or XML payload
        Then the API should return a 201 status code and the new user should be added to the database

    Scenario: Create a new user with missing required fields
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a JSON or XML payload that is missing required fields
        Then the API should return a 400 status code and an error message indicating that the required fields are missing

    Scenario: Create a new user with invalid data
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a JSON or XML payload that has invalid data
        Then the API should return a 400 status code and an error message indicating that the data is invalid

    Scenario: Create a new user with an existing email account
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a JSON or XML payload that has an email previously used to create an account
        Then the API should return a 400 status code and an error message indicating that an account with the email provided already exists