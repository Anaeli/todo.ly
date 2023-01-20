Feature: Update an existing item to be done.
    This API feature will update an item in a project to mark it as done. A 200 status code will be returned with the updated item.

    Scenario: Create a new item in a project.
        Given The user is authenticated
        When The user makes a PUT request to the following URL
        And Types the following text { "Checked": "true" }
        Then The API will update the item in the selected project and mark it as done