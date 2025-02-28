Movie API Setup

Create the Database
Run the following command to create the database with Docker:

docker-compose up --build -d

Update the Database
To apply migrations, run this command from the root folder of the API project:

dotnet ef database update

Run the API
Start the API server with:

dotnet run

The API will be available at http://localhost:5000.

First Run - Seed Data
On the first run, the API will automatically seed the database with movies that have titles starting with "The" for easy searching.

Unit Tests
Unit tests are included to verify the logic of the application.

Pagination Metadata
The API includes pagination, with metadata in the response:

Page Size: Number of items per page.
Page Number: Current page.
Total Movies: Total number of movies in the database.
Total Pages: Total pages based on page size.Pages: The total number of pages, calculated based on the page size and total number of movies. size, page number, total movies, total pages