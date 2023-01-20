Feature: Retrieve all done items of a project.
    This API feature will bring all the done items marked as done of a selected project given the ID. A 200 status code will be returned with the required information in the body.
    
    Scenario: Retrieve all done items of a project.
        Given The user is authenticated
        When The user makes a GET request to the following URL
        Then The API will return all the done items of the specified project