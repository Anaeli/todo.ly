Feature: User Creation
    As a non authenticated user, I want to be able to create a new user account so that I can access to app's features.

    Scenario: Create a new user
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a valid JSON or XML payload
        Then the API should return a OK status code and the new user should be added to the database

    Scenario: Create a new user with missing required fields
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a JSON or XML payload that is missing required fields
        Then the API should return a "OK" status code and a "Invalid Email Address" error message indicating missing fields

    Scenario: Create a new user with invalid data
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a JSON or XML payload that has invalid data
        Then the API should return a "OK" status code and a "Invalid Email Address" error message indicating invalid data

    Scenario: Create a new user with an existing email account
        Given the user is not authenticated
        When the user submits a POST request to the API endpoint with a JSON or XML payload that has an email previously used to create an account
        Then the API should return a "OK" status code and a "Account with this email address already exists" error message indicating the email already exists