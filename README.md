Movie API Setup

Create the Database

Run the following command, from the MoviesApi root folder to create the database with Docker:

docker-compose up --build -d

Update the Database

To apply initial migration via entity framework, run this command from the same root folder of the API project:

dotnet ef database update

Run the API:

dotnet run


First Run - Seed Data
On the first run, the API will automatically seed the database with movies that have titles starting with "The" for easy searching.

Unit Tests

Unit tests are included to verify the logic of the application.

Pagination Metadata
The API includes pagination, with metadata in the response:

Paginantion Metadata includes

totalMovies: total number of movies in search.

totalPages: Total number of pages available

currentPage: current page returned in search.

pageSize: number of movies in each page: 


Can test api at http://localhost:5021/swagger/index.html

There are 20 movies seeded in the DB



