Feature: User Deletion
    As an authenticated user, I want to be able to delete my user account.

    Scenario: Delete a user
        Given the user is authenticated
        When the user submits a DELETE request to the API endpoint
        Then the API should return a OK status code and the user should be removed from the database

    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a DELETE request to the API endpoint
        Then the API should return a "OK" status code and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.
