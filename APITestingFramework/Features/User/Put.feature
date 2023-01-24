Feature: User Update
    As an authenticated user, I want to be able to update my user account.

    Scenario: Update a user
        Given the user is authenticated
        When the user submits a PUT request to the API endpoint with a valid JSON or XML payload
        Then the API should return a OK status code and the user should be updated in the database

    Scenario: Update a user with invalid user credentials
        Given the user is authenticated
        When the user submits a PUT request to the API endpoint with an invalid "invalid@correo" user email
        Then the API should return a OK status code and an error message indicating that the user was not found

    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a PUT request to the API endpoint
        Then the API should return a OK status code and an error message indicating that the user is not authorized to access the resource.

