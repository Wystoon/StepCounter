StepCounter

A C# project for tracking and managing step counts with a RESTful API interface.

Features:

- Track daily step counts.
- RESTful API for adding, updating, and retrieving steps.
- Modular structure separating API, core logic, and database interactions.

Project Structure:

- StepCounter.Api - API logic and controllers.
- StepCounter.Core - Core logic and models.
- StepCounter.Infrastructure - Database setup and configuration.

Setup:

- Clone: git clone https://github.com/Wystoon/StepCounter.git
- Build: dotnet build
- Run: dotnet run --project StepCounter.Api

Endpoints:

Counter API

- POST /v1/counter - Creates a new counter and returns it.
- GET /v1/counter/{counterId} - Retrieves a counter by ID.
- PUT /v1/counter/{counterId} - Updates the counter with the given ID.

Global Score API

- GET /v1/global-score - Retrieves the total global step count.

Team API

- POST /v1/team - Creates a new team and returns it.
- GET /v1/team/{teamId} - Retrieves a team by ID.
- PUT /v1/team/{teamId} - Updates the team with the given ID.
- DELETE /v1/team/{teamId} - Deletes the team with the specified ID.

Additional Features:

Future enhancements may include authentication, analytics, logging, validation, tests and export features.
Contributing: Contributions are welcome.

License: MIT License
