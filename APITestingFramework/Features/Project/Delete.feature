Feature: Delete a project by ID

Scenario: User deletes a project    
    Given the user has a valid project ID
    When the user sends a DELETE request to the "https://todo.ly/api/projects/{id}.json" endpoint
    Then the project should be removed from the list of projects
    Then the user should receive a response with the removed project's information



    
