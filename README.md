# KharyatAPI

A RESTful API for managing a collection of video games, built with C# and .NET using Minimal APIs.

## Features

- Retrieve all video games.
- Retrieve a video game by ID.
- Create new video games.
- Validate incoming data.
- Return appropriate HTTP status codes for successful requests and errors.

## Technologies

- C#
- .NET
- ASP.NET Core Minimal APIs
- HTTP and JSON
- Git and GitHub

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

Check that the .NET SDK is installed:

```bash
dotnet --version
```

### Run the project

1. Clone the repository:

   ```bash
   git clone https://github.com/SirKaza/KharyatAPI
   ```

2. Navigate to the project directory:

   ```bash
   cd KharyatAPI
   ```

3. Run the API:

   ```bash
   dotnet run
   ```

4. Check the terminal output to find the local URL and port used by the API.

## API Endpoints

Replace `BASE_URL` with the local URL displayed when you run the application.

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/videogames` | Retrieve all video games |
| GET | `/api/videogames/{id}` | Retrieve a video game by ID |
| POST | `/api/videogames` | Create a new video game |
| PUT | `/api/videogames/{id}` | Update an existing video game |
| DELETE | `/api/videogames/{id}` | Delete a video game |

## Example Requests

Take a quick look to KharyatAPI.http file for more examples.

### Get all video games

```http
GET BASE_URL/api/videogames
```

Example response:

```json
[
  {
    "id": 1,
    "title": "Hollow Knight",
    "genre": "Metroidvania",
    "releaseYear": 2017
  },
  {
    "id": 2,
    "title": "Minecraft",
    "genre": "Sandbox",
    "releaseYear": 2011
  }
]
```

### Get a video game by ID

```http
GET BASE_URL/api/videogames/1
```

Example response:

```json
{
  "id": 1,
  "title": "Hollow Knight",
  "genre": "Metroidvania",
  "releaseYear": 2017
}
```

### Create a video game

```http
POST BASE_URL/api/videogames
Content-Type: application/json

{
  "id": 4,
  "title": "Dark Souls",
  "genre": "Action RPG",
  "releaseYear": 2011
}
```

Expected success status: `201 Created`.

## Validation and Error Handling

The API validates incoming video game data before creating a resource.

Examples of validation rules include:

- The ID must be greater than zero.
- Other fields must satisfy the rules implemented in `VideoGameValidator`.

The API uses HTTP status codes to communicate the result of each request:

| Status code | Meaning |
|---|---|
| `200 OK` | The request succeeded |
| `201 Created` | A resource was created successfully |
| `204 No Content` | The request succeeded without a response body |
| `400 Bad Request` | The request contains invalid data |
| `404 Not Found` | The requested resource was not found |
| `409 Conflict` | The request conflicts with the current state, such as a duplicate ID |
| `422 Unprocessable Entity` | Validation failed when returned by the API |
| `500 Internal Server Error` | An unexpected server error occurred |

The actual status codes depend on the endpoint implementation.

## Current Limitations

- Video game data is stored in memory and is reset when the application restarts.
- The API does not currently use a persistent database.

## Future Improvements

- Add persistent database storage.
- Improve automated testing.
- Add API documentation with OpenAPI/Swagger.
- Improve error handling and validation.

## Author

Developed as a learning project to practise C#, .NET and REST API development.