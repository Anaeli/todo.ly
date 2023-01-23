Feature: Retrieve an existing user in https://todo.ly/ website. API endpoint https://todo.ly/api/user.xml
    As an authenticated user, I want to be able to retrieve the information of an existing user account.

    Scenario: Retrieve a user
        Given the user is authenticated
        When the user submits a GET request to the API endpoint with a valid user ID
        Then the API should return a 200 status code and the requested user in JSON format

    Scenario: Retrieve a user with invalid user ID
        Given the user is authenticated
        When the user submits a GET request to the API endpoint with an invalid user ID in the URL
        Then the API should return a 404 status code and an error message indicating that the user was not found

    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a GET request to the API endpoint
        Then the API should return a 401 status code and an error message indicating that the user is not authorized to access the resource.