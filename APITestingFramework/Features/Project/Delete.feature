Feature: Delete a project by ID

Scenario: User deletes a project    
    Given the user has a valid project ID 4054429
    When the user sends a DELETE request to the API endpoint
    Then the project should be removed from the list of projects

Scenario: Attempt to delete an non-existent project
    Given the user has an invalid project ID 40547
    When the user sends a DELETE request for the non-existent project to the API endpoint and return a 402 status code with the message: You don't have access to this Project
    Then the API should return a 301 status code and an error message indicating Invalid Id to access the resource


