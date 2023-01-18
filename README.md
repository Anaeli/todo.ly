# Team B - Projects API Methods

## 1. Retrieve all items of a project.
This API feature will bring all the items of a selected project given the ID. A 200 status code will be returned with the required information in the body.

### Scenario: Retrieve all items of a project.
**Given** The user is authenticated<br>
**When** The user makes a GET request to the following URL https://todo.ly/api/projects/4053023/items.json<br>
**Then** The API will return all the items of the specified project.<br>

## 2. Retrieve all done items of a project.
This API feature will bring all the items marked as done of a selected project given the ID. A 200 status code will be returned with the required information in the body.

### Scenario: Retrieve all items of a project.
**Given** The user is authenticated<br>
**When** The user makes a GET request to the following URL https://todo.ly/api/projects/4053023/doneitems.json<br>
**Then** The API will return all the items of the specified project.<br>

## 3. Create a new item in a project.
This API feature will create a new item in a project. A 200 status code will be returned with the newly created item.

### Scenario: Create a new item in a project.
**Given** The user is authenticated<br>
**When** The user makes a POST request to the following URL https://todo.ly/api/items.json<br>
**And** Types the following text 
`{
    "Content": "This is a new item",
    "ProjectId": 4053023
}`<br>
**Then** The API will post a new item in the selected project<br>

## 4. Update an existing item to be done.
This API feature will update an item in a project to mark it as done. A 200 status code will be returned with the updated item.

### Scenario: Create a new item in a project.
**Given** The user is authenticated<br>
**When** The user makes a PUT request to the following URL https://todo.ly/api/items/11099581.json<br>
**And** Types the following text 
`{
    "Checked": "true"
}`<br>
**Then** The API will update the item in the selected project and mark it as done.<br>
