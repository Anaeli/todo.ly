Feature: User Deletion in https://todo.ly/ website. API endpoint https://todo.ly/api/user.xml
    As an authenticated user, I want to be able to delete my user account.

    Scenario: Delete a user
    Given the user is authenticated
    When the user submits a DELETE request to the API endpoint
    Then the API should return a 204 status code and the user should be removed from the database

    Scenario: Unauthorized access
    Given the user is not authenticated
    When the user submits a DELETE request to the API endpoint
    Then the API should return a 401 status code and an error message indicating that the user is not authorized to access the resource.



   