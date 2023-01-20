Feature: Create a new item in a project
    This API feature will create a new item in a project. A 200 status code will be returned with the newly created item.

    @Create
    Scenario: Create a new item in a project
        Given The user is authenticated
        When The user makes a POST request to the following URL
        And Types the following text { "Content": "This is a new item", "ProjectId": 4053023 }
        Then The API will post a new item in the selected project