IDController API Documentation
The IDController is an ASP.NET Core Web API controller responsible for handling CRUD (Create, Read, Update, Delete) operations for the ID resource. This resource represents entities with an Id and a Name.

Endpoints
1. Get an ID entity by ID
HTTP Method: GET
URL: /api/ID/{id}
Description: Retrieves an ID entity by its unique id from the database.
Request Parameters:
id (integer): The unique identifier of the ID entity.
Response:
200 OK: Returns the ID entity if found.
404 Not Found: If no ID entity is found with the specified id.
500 Internal Server Error: If an unexpected error occurs during execution.
2. Create a new ID entity
HTTP Method: POST
URL: /api/ID/
Description: Creates a new ID entity with the provided Name.
Request Body:
IdRequest object containing Name (string): The name of the new ID entity.
Response:
200 OK: Returns the newly created ID entity.
500 Internal Server Error: If an unexpected error occurs during execution.
3. Update an ID entity by ID
HTTP Method: PUT
URL: /api/ID/{id}
Description: Updates an existing ID entity with the provided Id and Name.
Request Parameters:
id (integer): The unique identifier of the ID entity to be updated.
Request Body:
ID object containing Id (integer) and Name (string): The updated values for the ID entity.
Response:
200 OK: Returns the updated ID entity.
400 Bad Request: If the provided id in the URL does not match the Id in the request body.
404 Not Found: If no ID entity is found with the specified id.
500 Internal Server Error: If an unexpected error occurs during execution.
4. Delete an ID entity by ID
HTTP Method: DELETE
URL: /api/ID/{id}
Description: Deletes an ID entity by its unique id.
Request Parameters:
id (integer): The unique identifier of the ID entity to be deleted.
Response:
200 OK: Returns the deleted ID entity.
404 Not Found: If no ID entity is found with the specified id.
500 Internal Server Error: If an unexpected error occurs during execution.
Notes
The controller uses an IDContext to interact with the database.
Error handling is implemented to return appropriate HTTP status codes and error messages in case of failures.
This API provides basic CRUD functionality for managing ID entities.
Swagger Link = https://localhost:7021/swagger/index.html
