Feature: Retrieve an existing user
    As an authenticated user, I want to be able to retrieve the information of an existing user account.

    Scenario: Retrieve a user
        Given the user is authenticated
        When the user submits a GET request to the API endpoint with a valid user ID
        Then the API should return a OK status code and the requested user in JSON format

    Scenario: Retrieve a user with invalid user email
        Given the user is authenticated
        When the user submits a GET request to the API endpoint with an invalid user email in the URL
        Then the API should return a "OK" status code and a "Account doesn't exist" error message indicating that the user was not found

    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a GET request to the API endpoint
        Then the API should return a "OK" status code and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.