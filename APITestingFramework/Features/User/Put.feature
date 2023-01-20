Feature: User Update in https://todo.ly/ website. API endpoint https://todo.ly/api/user.xml
    As an authenticated user, I want to be able to update my user account.

    Scenario: Update a user
        Given the user is authenticated and has permission to update a user
        When the user submits a PUT request to the API endpoint with a valid JSON or XML payload
        Then the API should return a 200 status code and the user should be updated in the database

    Scenario: Update a user with invalid user credentials
        Given the user is authenticated and has permission to update a user
        When the user submits a PUT request to the API endpoint with an invalid user ID in the URL
        Then the API should return a 404 status code and an error message indicating that the user was not found

    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a PUT request to the API endpoint
        Then the API should return a 401 status code and an error message indicating that the user is not authorized to access the resource.

    Scenario: Create a new item in a project.
        Given The user is authenticated
        When The user makes a PUT request to the following URL
        And Types the following text { "Checked": "true" }
        Then The API will update the item in the selected project and mark it as done.