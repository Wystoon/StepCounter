StepCounter
StepCounter is a project developed in C# for tracking and managing step counts. It provides a foundation for recording daily steps and offers basic APIs to manage and retrieve this data.

Features
Step Tracking: Records and manages daily step counts for users.
RESTful API: Includes endpoints for adding, updating, and retrieving step data.
Modular Architecture: Built with a modular structure to separate core functionality, API, and infrastructure.
Project Structure
StepCounter.Api: Contains the RESTful API logic and controllers.
StepCounter.Core: Core logic and business models.
StepCounter.Infrastructure: Database interactions and configuration.
Prerequisites
.NET Core 6.0 or later
SQLite (or other supported databases) for data storage
Getting Started
Clone the Repository:

bash
Copy code
git clone https://github.com/Wystoon/StepCounter.git
cd StepCounter
Build the Solution:

bash
Copy code
dotnet build
Run the Application:

bash
Copy code
dotnet run --project StepCounter.Api
API Endpoints
POST /steps: Add a new step entry.
GET /steps/{id}: Retrieve step data by ID.
PUT /steps/{id}: Update step entry.
DELETE /steps/{id}: Delete step data.
Future Improvements
Add user authentication.
Implement data analytics features.
Enable data export capabilities.
Contributing
Contributions are welcome! Feel free to open issues and submit pull requests.

License
This project is licensed under the MIT License.
