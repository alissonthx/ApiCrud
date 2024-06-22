# Students API

This API allows you to manage students in a database. It provides endpoints to create, read, update, and delete student records.

## Table of Contents

- [Setup](#setup)
- [Endpoints](#endpoints)
  - [Create Student](#create-student)
  - [Get All Students](#get-all-students)
  - [Update Student](#update-student)
  - [Delete Student](#delete-student)
- [Models](#models)

## Setup

1. Clone the repository:

    ```bash
    git clone https://github.com/alissonthx/ApiCrud.git
    ```

2. Navigate to the project directory:

    ```bash
    cd ApiCrud
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

5. Open Swagger UI in your browser to interact with the API:

    ```
    http://localhost:5000/swagger
    ```

## Endpoints

### Create Student

- **URL:** `/students`
- **Method:** `POST`
- **Request Body:**

    ```json
    {
      "name": "string"
    }
    ```

- **Responses:**
  - `200 OK`: Successfully created the student.
  - `409 Conflict`: Name already exists.

#### Example Request

```bash
curl -X POST "http://localhost:5000/students" -H "Content-Type: application/```json" -d '{
  "name": "John Doe"
}'
```

## Get All Students
- URL: /students
- Method: GET
- Responses:
  - 200 OK: Returns a list of active students.

Example Request

```bash
curl -X GET "http://localhost:5000/students"
```

## Update Student
- URL: /students/{id}

- Method: PUT

- Request Body:

```json
{
  "name": "string"
}
```

- Responses:

  - 200 OK: Successfully updated the student's name.
  - 404 Not Found: Student not found.
    
Example Request
```bash
curl -X PUT "http://localhost:5000/students/{id}" -H "Content-Type: application/```json" -d '{
  "name": "Jane Doe"
}'
```

## Soft Delete Student
- URL: /students/{id}
- Method: DELETE
- Responses:
  -200 OK: Successfully deleted (soft delete) the student.
  -404 Not Found: Student not found.
  
Example Request
```bash
curl -X DELETE "http://localhost:5000/students/{id}"
```

Models

AddStudentRequest
```json
{
  "name": "string"
}
```

UpdateStudentRequest
```json
{
  "name": "string"
}
```

## StudentDto
```json
{
  "id": "string",
  "name": "string"
}
```
