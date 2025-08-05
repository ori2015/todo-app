# todo-app

This project is a simple Todo application built with a .NET Core backend connected to MariaDB and a Svelte frontend. 

## Project Structure

```
todo-app
├── api                # .NET Core backend
│   ├── Controllers    # API controllers
│   ├── Data           # Database context
│   ├── Migrations     # Entity Framework migrations
│   ├── Models         # Data models
│   ├── Services       # Service interfaces
│   ├── Program.cs     # Application entry point
│   ├── Startup.cs     # Application configuration
│   ├── appsettings.json # Configuration settings
│   └── todo-app.csproj # Project file
├── app                # Svelte frontend
│   ├── src            # Source files
│   ├── static         # Static assets
│   ├── package.json    # Project metadata and dependencies
│   ├── svelte.config.js # Svelte configuration
│   └── vite.config.js  # Vite configuration
├── .gitignore         # Git ignore file
└── README.md          # Project documentation
```

## Database Configuration

The application now uses MariaDB as the database. The connection string is read from the environment variable `DB_CSTR`. 

Default connection string: `Server=mariadb;Database=sampledb;User=admin;Password=Aa1234561!;`

## API Endpoints

- `GET /api/todo` - Get all todos
- `POST /api/todo` - Create a new todo
- `PUT /api/todo/{id}` - Update an existing todo
- `DELETE /api/todo/{id}` - Delete a todo

## Getting Started

### Prerequisites

- .NET Core SDK
- Node.js and npm

### Setup Instructions

1. **Clone the repository:**

   ```
   git clone <repository-url>
   cd todo-app
   ```

2. **Set up the backend:**

   Navigate to the `api` directory and restore the dependencies:

   ```
   cd api
   dotnet restore
   ```

   You can run the backend using:

   ```
   dotnet run
   ```

3. **Set up the frontend:**

   Navigate to the `app` directory and install the dependencies:

   ```
   cd app
   npm install
   ```

   You can run the frontend using:

   ```
   npm run dev
   ```

### Usage

- The backend API will be available at `http://localhost:5000` (or the port specified in `appsettings.json`).
- The frontend application will be available at `http://localhost:3000` (or the port specified in `vite.config.js`).

### Contributing

Feel free to submit issues or pull requests for any improvements or features you would like to see!

### License

This project is licensed under the MIT License.