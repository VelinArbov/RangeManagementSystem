

# Range Management System
The Range Management System is a web application designed to manage shooting events, weapons, and ammunition for a shooting range. It provides functionality for organizing events, tracking available weapons and ammunition, and managing participant registrations.

## Features
Event Management: Organize shooting events with details such as date, location, and participant limits.
Weapon Management: Maintain a catalog of available weapons, including type, caliber, and availability status.
Ammunition Management: Track available ammunition types, calibers, and quantities.
Participant Registration: Allow users to register for shooting events and reserve weapons and ammunition.
## Installation
Clone the repository:
bash
```git clone https://github.com/velinarbov/RangeManagementSystem.git```
## Navigate to the project directory:
bash
cd RangeManagementSystem
## Install dependencies:
bash
dotnet restore
Configure the database connection string in appsettings.json:
```{
  "ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
  }
}
```

Apply database migrations:
bash
Copy code
dotnet ef database update
## Run the application:
bash
dotnet run
Access the application in your web browser at http://localhost:5000.
Technologies Used
ASP.NET Core MVC
Entity Framework Core
Razor Pages
HTML/CSS
JavaScript
Bootstrap
License
This project is licensed under the MIT License.

Contributors
John Doe
Jane Smith
Support
For any issues or inquiries, please contact support@example.com.
