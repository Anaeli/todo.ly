Feature: Update a Project by ID

Scenario: User updates a project's information 
    Given the user is authenticated
    When the user sends a PUT request for the project with ID 4054352 to the API endpoint 
    Then includes the updated project content, items count, icon, item type, parent id, collapsed, and item order in the request body 
    Then the project's information should be updated in the projects 
    Then the user should receive a response with the updated project's information

  
  
  
  