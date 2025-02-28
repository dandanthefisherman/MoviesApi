using MoviesApi.Models;

namespace MoviesApi.Data;

using System;
using System.Linq;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, MoviesDbContext context)
    {
        // Check if the database is already seeded (i.e., if there are any movies)
        if (!context.Movies.Any())
        {
            var movies = new[]
            {
                new Movie
                {
                    ReleaseDate = new DateTime(2019, 5, 3),
                    Title = "The Avengers",
                    Overview = "Earth's mightiest heroes must come together to stop Loki and his alien army from subjugating Earth.",
                    Popularity = 85.0,
                    VoteCount = 8000,
                    VoteAverage = 8.0,
                    OriginalLanguage = "en",
                    Genre = "Action",
                    PosterUrl = "https://example.com/poster1.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2017, 12, 15),
                    Title = "The Last Jedi",
                    Overview = "Luke Skywalker reluctantly trains Rey in the ways of the Force while the Resistance tries to survive the First Order's attack.",
                    Popularity = 78.0,
                    VoteCount = 12000,
                    VoteAverage = 6.9,
                    OriginalLanguage = "en",
                    Genre = "Sci-Fi",
                    PosterUrl = "https://example.com/poster2.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2019, 7, 19),
                    Title = "The Lion King",
                    Overview = "After the murder of his father, a young lion prince flees his kingdom only to learn the true meaning of responsibility and bravery.",
                    Popularity = 82.0,
                    VoteCount = 15000,
                    VoteAverage = 7.0,
                    OriginalLanguage = "en",
                    Genre = "Animation",
                    PosterUrl = "https://example.com/poster3.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2017, 5, 19),
                    Title = "The Fate of the Furious",
                    Overview = "When a mysterious woman seduces Dom into the world of crime and a betrayal of those closest to him, the crew faces their greatest challenge yet.",
                    Popularity = 72.0,
                    VoteCount = 13000,
                    VoteAverage = 6.7,
                    OriginalLanguage = "en",
                    Genre = "Action",
                    PosterUrl = "https://example.com/poster4.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2019, 11, 22),
                    Title = "The Irishman",
                    Overview = "A mob hitman recalls his possible involvement with the slaying of Jimmy Hoffa.",
                    Popularity = 70.0,
                    VoteCount = 2000,
                    VoteAverage = 7.8,
                    OriginalLanguage = "en",
                    Genre = "Crime",
                    PosterUrl = "https://example.com/poster5.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2017, 7, 21),
                    Title = "The Dark Tower",
                    Overview = "The last Gunslinger, Roland Deschain, has been locked in an eternal battle with Walter o'Dim, also known as the Man in Black.",
                    Popularity = 55.0,
                    VoteCount = 4000,
                    VoteAverage = 5.6,
                    OriginalLanguage = "en",
                    Genre = "Fantasy",
                    PosterUrl = "https://example.com/poster6.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2018, 10, 12),
                    Title = "The Hate U Give",
                    Overview = "Starr Carter is a 16-year-old girl who witnesses the fatal shooting of her childhood friend by a police officer.",
                    Popularity = 60.0,
                    VoteCount = 2000,
                    VoteAverage = 7.2,
                    OriginalLanguage = "en",
                    Genre = "Drama",
                    PosterUrl = "https://example.com/poster7.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2018, 11, 2),
                    Title = "The Nutcracker and the Four Realms",
                    Overview = "A young girl is transported into a magical world where she must fight an evil ruler and save the Four Realms.",
                    Popularity = 58.0,
                    VoteCount = 2500,
                    VoteAverage = 6.0,
                    OriginalLanguage = "en",
                    Genre = "Fantasy",
                    PosterUrl = "https://example.com/poster8.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2020, 7, 10),
                    Title = "The Old Guard",
                    Overview = "A group of immortal mercenaries are suddenly exposed and must fight to keep their identity a secret.",
                    Popularity = 75.0,
                    VoteCount = 5000,
                    VoteAverage = 6.8,
                    OriginalLanguage = "en",
                    Genre = "Action",
                    PosterUrl = "https://example.com/poster9.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2019, 3, 29),
                    Title = "The Beach Bum",
                    Overview = "A rebellious stoner named Moondog lives life by his own rules and is a fan of pushing boundaries.",
                    Popularity = 50.0,
                    VoteCount = 1200,
                    VoteAverage = 5.3,
                    OriginalLanguage = "en",
                    Genre = "Comedy",
                    PosterUrl = "https://example.com/poster10.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2020, 9, 4),
                    Title = "The Conjuring: The Devil Made Me Do It",
                    Overview = "The Warrens investigate a murder case involving demonic possession as a defense for the crime.",
                    Popularity = 80.0,
                    VoteCount = 3500,
                    VoteAverage = 6.9,
                    OriginalLanguage = "en",
                    Genre = "Horror",
                    PosterUrl = "https://example.com/poster11.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2018, 9, 28),
                    Title = "The Sisters",
                    Overview = "A group of sisters reunites to confront a dark family secret.",
                    Popularity = 40.0,
                    VoteCount = 800,
                    VoteAverage = 5.1,
                    OriginalLanguage = "en",
                    Genre = "Thriller",
                    PosterUrl = "https://example.com/poster12.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2021, 5, 14),
                    Title = "The Quiet Place Part II",
                    Overview = "After the events of the first movie, the Abbott family must continue to survive in silence to avoid the alien creatures that hunt by sound.",
                    Popularity = 85.0,
                    VoteCount = 7000,
                    VoteAverage = 7.5,
                    OriginalLanguage = "en",
                    Genre = "Horror",
                    PosterUrl = "https://example.com/poster13.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2020, 11, 27),
                    Title = "The Prom",
                    Overview = "A group of Broadway stars try to help a high school student fight for her right to attend the prom with her girlfriend.",
                    Popularity = 65.0,
                    VoteCount = 2000,
                    VoteAverage = 6.0,
                    OriginalLanguage = "en",
                    Genre = "Musical",
                    PosterUrl = "https://example.com/poster14.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2020, 9, 11),
                    Title = "The Devil All the Time",
                    Overview = "A young man is tormented by the actions of his father and struggles to survive in a town filled with violence and corruption.",
                    Popularity = 70.0,
                    VoteCount = 5500,
                    VoteAverage = 7.1,
                    OriginalLanguage = "en",
                    Genre = "Crime",
                    PosterUrl = "https://example.com/poster15.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2021, 7, 23),
                    Title = "The Green Knight",
                    Overview = "A young knight embarks on a quest to face the Green Knight, a mysterious and powerful figure.",
                    Popularity = 77.0,
                    VoteCount = 2200,
                    VoteAverage = 7.3,
                    OriginalLanguage = "en",
                    Genre = "Adventure",
                    PosterUrl = "https://example.com/poster16.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2019, 5, 17),
                    Title = "The Sun is Also a Star",
                    Overview = "A teen girl and a boy fall in love, but their relationship is challenged by the harsh realities of life, including immigration.",
                    Popularity = 60.0,
                    VoteCount = 4000,
                    VoteAverage = 6.1,
                    OriginalLanguage = "en",
                    Genre = "Romance",
                    PosterUrl = "https://example.com/poster17.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2018, 8, 10),
                    Title = "The Meg",
                    Overview = "A deep-sea submersible, part of a project to retrieve a nuclear missile from the Mariana Trench, is attacked by a giant prehistoric shark.",
                    Popularity = 65.0,
                    VoteCount = 10000,
                    VoteAverage = 5.6,
                    OriginalLanguage = "en",
                    Genre = "Action",
                    PosterUrl = "https://example.com/poster18.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2017, 11, 17),
                    Title = "The Disaster Artist",
                    Overview = "A behind-the-scenes look at the making of the cult film, 'The Room'.",
                    Popularity = 69.0,
                    VoteCount = 5000,
                    VoteAverage = 7.3,
                    OriginalLanguage = "en",
                    Genre = "Comedy",
                    PosterUrl = "https://example.com/poster19.jpg"
                },
                new Movie
                {
                    ReleaseDate = new DateTime(2018, 1, 5),
                    Title = "The Post",
                    Overview = "The Washington Post uncovers a web of secrets surrounding the government’s involvement in the Vietnam War.",
                    Popularity = 71.0,
                    VoteCount = 4000,
                    VoteAverage = 7.2,
                    OriginalLanguage = "en",
                    Genre = "Drama",
                    PosterUrl = "https://example.com/poster20.jpg"
                }
            };

            await context.Movies.AddRangeAsync(movies);
            await context.SaveChangesAsync();
        }
    }
}
